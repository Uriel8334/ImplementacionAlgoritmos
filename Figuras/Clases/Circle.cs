using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ImplementacionAlgoritmos
{
    internal class Circle
    {
        //datos miembro (circulo)

        //radio del circulo
        private float mRadius;
        //perimetro del circulo
        private float mPerimeter;
        //area del circulo
        private float mArea;
        //objeto que activa el modo grafico
        private Graphics mGraph;
        //constante scale factor (zoom in/out)
        private const float SF = 20;
        //Objeto boligrafo que dibuja o escribe en un lienzo (canvas)
        private Pen mPen;
        //lienzo (canvas) donde se dibuja el circulo
        private PictureBox picCanvas;

        // Agregar estos campos al inicio de la clase
        private Timer mTimer;
        private Timer mFillTimer; // Timer separado para el relleno
        private Bitmap mBitmap;
        private int mCurrentStep;
        private List<Point> mPoints; // Para almacenar los puntos a dibujar
        private Color mFillColor = Color.LightBlue; // Color para el relleno
        private Queue<Point> mFillQueue; // Cola para los puntos de relleno
        private Color mTargetColor; // Color objetivo para el relleno

        // Referencia al DataGridView para actualización en tiempo real
        private DataGridView mDataGridView;

        //constructor sin parametros
        public Circle()
        {
            //inicializacion de los datos
            mRadius = 0.0f;
            mPerimeter = 0.0f;
            mArea = 0.0f;
            mFillQueue = new Queue<Point>();
        }
        //funcion que lee los datos de entrada del circulo
        public void ReadData(TextBox txtRadius)
        {
            try
            {
                //leer el radio
                mRadius = float.Parse(txtRadius.Text);
            }
            catch
            {
                MessageBox.Show("Ingreso no válido...", "Mensaje de error");
            }
        }
        //funcion que inicializa los datos y controles
        public void InitializeData(TextBox txtRadius, TextBox txtPerimeter, TextBox txtArea, PictureBox canCanvas)
        {
            //inicializacion de los datos
            mRadius = 0.0f;
            mPerimeter = 0.0f;
            mArea = 0.0f;
            //inicializacion de los controles
            txtRadius.Text = "";
            txtPerimeter.Text = "";
            txtArea.Text = "";

            //mantiene el cursor titilando en una caja de texto
            txtRadius.Focus();
            //limpia el lienzo (canvas)
            picCanvas = canCanvas;

            // Detener timers si están activos
            if (mTimer != null && mTimer.Enabled)
                mTimer.Stop();
            
            if (mFillTimer != null && mFillTimer.Enabled)
                mFillTimer.Stop();

            // Limpiar la cola de relleno
            mFillQueue?.Clear();

            // Limpiar el bitmap existente
            if (mBitmap != null)
            {
                mBitmap.Dispose();
                mBitmap = null;
            }

            // Crear un nuevo bitmap
            mBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            using (mGraph = Graphics.FromImage(mBitmap))
            {
                mGraph.Clear(Color.PapayaWhip);
            }

            picCanvas.Image = mBitmap;

            // Limpiar la lista de puntos
            mPoints?.Clear();
        }
        //funcion que calcula el perimetro del circulo
        public void PerimeterCircle()
        {
            //calculo del perimetro
            mPerimeter = 2 * (float)Math.PI * mRadius;
        }
        //funcion que calcula el area del circulo
        public void AreaCircle()
        {
            //calculo del area
            mArea = (float)Math.PI * mRadius * mRadius;
        }
        //metodo que grafica el circulo
        public void PlotShape(PictureBox picCanvas)
        {
            this.picCanvas = picCanvas;

            // Verificar si el círculo excede el tamaño del PictureBox
            if (2 * mRadius * SF > picCanvas.Width || 2 * mRadius * SF > picCanvas.Height)
            {
                MessageBox.Show("El tamaño del círculo excede el tamaño del área de dibujo.",
                    "Tamaño excesivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear un nuevo bitmap si no existe o si cambió el tamaño del PictureBox
            if (mBitmap == null || mBitmap.Width != picCanvas.Width || mBitmap.Height != picCanvas.Height)
            {
                mBitmap?.Dispose();
                mBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
                using (Graphics g = Graphics.FromImage(mBitmap))
                {
                    g.Clear(Color.PapayaWhip);
                }
            }

            // Obtener el objeto Graphics del bitmap
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                mPen = new Pen(Color.Blue, 3);

                // Calcular las coordenadas para centrar el círculo
                int x = (picCanvas.Width - (int)(2 * mRadius * SF)) / 2;
                int y = (picCanvas.Height - (int)(2 * mRadius * SF)) / 2;

                // Dibujar el círculo en el bitmap
                g.DrawEllipse(mPen, x, y, 2 * mRadius * SF, 2 * mRadius * SF);
            }

            // Asignar el bitmap actualizado al PictureBox
            picCanvas.Image = mBitmap;
        }
        // metodo que imprime el perimetro y el area del circulo
        public void PrintData(TextBox txtPerimeter, TextBox txtArea)
        {
            txtPerimeter.Text = mPerimeter.ToString();
            txtArea.Text = mArea.ToString();
        }
        //metodo que cierra el formulario
        public void CloseForm(Form form)
        {
            //cierre del formulario
            form.Close();
        }
        private void InitializeDrawing(PictureBox picCanvas)
        {
            // Guardar referencia al PictureBox
            this.picCanvas = picCanvas;

            // Verificar si el círculo excede el tamaño del PictureBox
            if (2 * mRadius * SF > picCanvas.Width || 2 * mRadius * SF > picCanvas.Height)
            {
                MessageBox.Show("El tamaño del círculo excede el tamaño del área de dibujo.",
                    "Tamaño excesivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Crear un bitmap del tamaño del PictureBox
            mBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);

            // Limpiar el bitmap (fondo)
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                g.Clear(Color.PapayaWhip);
            }

            // Mostrar el bitmap en el PictureBox
            picCanvas.Image = mBitmap;

            // Configurar el temporizador
            if (mTimer == null)
            {
                mTimer = new Timer();
                mTimer.Interval = 10; // 10 ms por píxel
                mTimer.Tick += Timer_Tick;
            }
            else
            {
                mTimer.Stop();
            }
        }
        
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Verificar si hemos dibujado todos los puntos
            if (mCurrentStep >= mPoints.Count)
            {
                mTimer.Stop();
                return;
            }

            // Obtener el punto actual
            Point p = mPoints[mCurrentStep];

            // Dibujar un píxel en el bitmap
            if (p.X >= 0 && p.X < mBitmap.Width && p.Y >= 0 && p.Y < mBitmap.Height)
            {
                mBitmap.SetPixel(p.X, p.Y, mPen.Color);
            }

            // Actualizar el PictureBox
            picCanvas.Invalidate();

            // Si tenemos un DataGridView asociado, actualizar la visualización de puntos
            if (mDataGridView != null && mCurrentStep % 10 == 0) // Actualizar cada 10 puntos para no saturar la UI
            {
                UpdatePointsInGridLive(mCurrentStep);
            }

            // Pasar al siguiente punto
            mCurrentStep++;
        }

        private void FillTimer_Tick(object sender, EventArgs e)
        {
            // Número de píxeles a procesar por tick para una animación más fluida
            int pixelsPerTick = 25;
            int pixelsProcessed = 0;

            // Procesar un lote de píxeles por tick
            while (mFillQueue.Count > 0 && pixelsProcessed < pixelsPerTick)
            {
                // Obtener el siguiente punto
                Point p = mFillQueue.Dequeue();
                
                // Verificar si está dentro de los límites
                if (p.X < 0 || p.Y < 0 || p.X >= mBitmap.Width || p.Y >= mBitmap.Height)
                    continue;
                    
                // Verificar si el color coincide con el objetivo
                Color currentColor = mBitmap.GetPixel(p.X, p.Y);
                if (currentColor.ToArgb() != mTargetColor.ToArgb())
                    continue;
                    
                // Pintar el píxel
                mBitmap.SetPixel(p.X, p.Y, mFillColor);
                pixelsProcessed++;
                
                // Continuar el proceso recursivo para este punto
                RecursiveFloodFill(p.X, p.Y - 1, mTargetColor, mFillColor); // Norte
                RecursiveFloodFill(p.X + 1, p.Y, mTargetColor, mFillColor); // Este
                RecursiveFloodFill(p.X, p.Y + 1, mTargetColor, mFillColor); // Sur
                RecursiveFloodFill(p.X - 1, p.Y, mTargetColor, mFillColor); // Oeste
            }

            // Actualizar la visualización
            picCanvas.Invalidate();

            // Detener el timer si ya no hay más puntos que procesar
            if (mFillQueue.Count == 0)
            {
                mFillTimer.Stop();
            }
        }

        public void StartFloodFill(int x, int y)
        {
            if (mBitmap == null)
                return;

            // Verificar que el punto está dentro de los límites
            if (x < 0 || y < 0 || x >= mBitmap.Width || y >= mBitmap.Height)
                return;

            // Obtener el color del píxel actual
            Color targetColor = mBitmap.GetPixel(x, y);

            // Solo comenzar si se hace clic en un área del fondo (PapayaWhip)
            if (targetColor.ToArgb() == Color.PapayaWhip.ToArgb())
            {
                // Crear una cola para los píxeles a procesar
                Queue<Point> pixelQueue = new Queue<Point>();
                pixelQueue.Enqueue(new Point(x, y));

                // Configurar el temporizador para la animación
                if (mFillTimer == null)
                {
                    mFillTimer = new Timer();
                    mFillTimer.Interval = 10; // 10ms para una animación fluida
                    mFillTimer.Tick += (s, e) => {
                        // Procesar un número limitado de píxeles por tick
                        int pixelsPerTick = 200; // Ajustar este valor según la velocidad deseada
                        int pixelsProcessed = 0;

                        while (pixelQueue.Count > 0 && pixelsProcessed < pixelsPerTick)
                        {
                            Point currentPixel = pixelQueue.Dequeue();
                            if (currentPixel.X < 0 || currentPixel.Y < 0 || 
                                currentPixel.X >= mBitmap.Width || currentPixel.Y >= mBitmap.Height)
                                continue;

                            // Si el píxel tiene el color objetivo, rellenarlo
                            if (mBitmap.GetPixel(currentPixel.X, currentPixel.Y).ToArgb() == targetColor.ToArgb())
                            {
                                // Pintar este píxel
                                mBitmap.SetPixel(currentPixel.X, currentPixel.Y, mFillColor);
                                pixelsProcessed++;

                                // Agregar píxeles vecinos a la cola
                                pixelQueue.Enqueue(new Point(currentPixel.X, currentPixel.Y - 1)); // Norte
                                pixelQueue.Enqueue(new Point(currentPixel.X + 1, currentPixel.Y)); // Este
                                pixelQueue.Enqueue(new Point(currentPixel.X, currentPixel.Y + 1)); // Sur
                                pixelQueue.Enqueue(new Point(currentPixel.X - 1, currentPixel.Y)); // Oeste
                            }
                        }

                        // Actualizar la imagen
                        picCanvas.Invalidate();

                        // Si no hay más píxeles que procesar, detener el temporizador
                        if (pixelQueue.Count == 0)
                        {
                            mFillTimer.Stop();
                        }
                    };
                }
                else
                {
                    mFillTimer.Stop();
                }

                // Iniciar el temporizador para comenzar el proceso de relleno
                mFillTimer.Start();
            }
        }

        // Implementación del algoritmo recursivo de relleno por inundación con animación
        private void RecursiveFloodFillAnimated(int x, int y, Color targetColor, Color fillColor)
        {
            try
            {
                // Verificación más robusta: comprobar primero si el bitmap existe
                if (mBitmap == null)
                    return;

                // Comprobar si el punto está fuera de los límites
                if (x < 0 || y < 0 || x >= mBitmap.Width || y >= mBitmap.Height)
                    return;

                // Obtener el color del píxel actual con manejo de excepciones
                Color currentColor;
                try
                {
                    currentColor = mBitmap.GetPixel(x, y);
                }
                catch (Exception)
                {
                    // Si hay algún error al obtener el color, simplemente salir
                    return;
                }

                // Si el color no coincide con el objetivo o ya ha sido pintado, salir
                if (currentColor.ToArgb() != targetColor.ToArgb() ||
                    currentColor.ToArgb() == fillColor.ToArgb())
                    return;

                // Pintar el píxel actual con manejo de excepciones
                try
                {
                    mBitmap.SetPixel(x, y, fillColor);
                }
                catch (Exception)
                {
                    // Si hay algún error al establecer el color, simplemente continuar
                    return;
                }

                // Introducir un pequeño retraso para visualizar el proceso
                mCurrentStep++;
                if (mCurrentStep % 100 == 0) // Cada 100 píxeles, dar tiempo para actualizar la UI
                {
                    picCanvas.Invalidate();
                    Application.DoEvents(); // Permitir que la UI se actualice
                    System.Threading.Thread.Sleep(5); // Pausa más corta para evitar bloqueos
                }

                // Llamada recursiva con verificación adicional para evitar desbordamiento de pila
                if (mCurrentStep < 50000) // Limitar la profundidad de recursión
                {
                    RecursiveFloodFillAnimated(x, y - 1, targetColor, fillColor); // Norte
                    RecursiveFloodFillAnimated(x + 1, y, targetColor, fillColor); // Este
                    RecursiveFloodFillAnimated(x, y + 1, targetColor, fillColor); // Sur
                    RecursiveFloodFillAnimated(x - 1, y, targetColor, fillColor); // Oeste
                }
            }
            catch (Exception ex)
            {
                // Capturar cualquier excepción no prevista para evitar que la aplicación se bloquee
                Console.WriteLine($"Error en RecursiveFloodFillAnimated: {ex.Message}");
                return;
            }
        }
        // Implementación del algoritmo recursivo de relleno por inundación
        private void RecursiveFloodFill(int x, int y, Color targetColor, Color fillColor)
        {
            // Comprobar si el punto está fuera de los límites
            if (x < 0 || y < 0 || x >= mBitmap.Width || y >= mBitmap.Height)
                return;

            // Obtener el color del píxel actual
            Color currentColor = mBitmap.GetPixel(x, y);

            // Si el color no coincide con el objetivo o ya ha sido pintado, salir
            if (currentColor.ToArgb() != targetColor.ToArgb() || 
                currentColor.ToArgb() == fillColor.ToArgb())
                return;

            // Encolar este punto para la animación visual
            mFillQueue.Enqueue(new Point(x, y));
            
            // Añadir puntos adyacentes para procesamiento recursivo
            // En lugar de llamar recursivamente de inmediato, los encolamos para procesar después
            // Norte
            if (y > 0) mFillQueue.Enqueue(new Point(x, y - 1));
            // Este
            if (x < mBitmap.Width - 1) mFillQueue.Enqueue(new Point(x + 1, y));
            // Sur
            if (y < mBitmap.Height - 1) mFillQueue.Enqueue(new Point(x, y + 1));
            // Oeste
            if (x > 0) mFillQueue.Enqueue(new Point(x - 1, y));
        }

        public void AlgoritmoDiscretizacion(PictureBox picCanvas, DataGridView dgvPoints = null)
        {
            // Verificar si el círculo excede el tamaño del PictureBox
            if (2 * mRadius * SF > picCanvas.Width || 2 * mRadius * SF > picCanvas.Height)
            {
                MessageBox.Show("El tamaño del círculo excede el tamaño del área de dibujo.",
                    "Tamaño excesivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Guardar referencia al DataGridView
            mDataGridView = dgvPoints;
            
            // Preparar el DataGridView si está disponible
            if (mDataGridView != null)
            {
                InitializeDataGridView();
            }

            // Inicializar el bitmap y el temporizador
            InitializeDrawing(picCanvas);

            // Crear un bolígrafo para dibujar puntos
            mPen = new Pen(Color.Red, 1);

            // Centro del círculo (en el centro del PictureBox)
            float centerX = picCanvas.Width / 2;
            float centerY = picCanvas.Height / 2;

            // Número de puntos para la discretización
            int numPoints = 360; // Un punto por grado

            // Calcular todos los puntos primero
            mPoints = new List<Point>();
            for (int i = 0; i < numPoints; i++)
            {
                // Convertir el ángulo a radianes
                float angle = (float)(i * 2 * Math.PI / numPoints);

                // Calcular las coordenadas (x,y) del punto en la circunferencia
                int x = (int)(centerX + mRadius * SF * (float)Math.Cos(angle));
                int y = (int)(centerY + mRadius * SF * (float)Math.Sin(angle));

                mPoints.Add(new Point(x, y));
            }

            // Iniciar el temporizador para dibujar los puntos uno a uno
            mCurrentStep = 0;
            mTimer.Start();
        }

        public void AlgoritmoPuntoMedio(PictureBox picCanvas, DataGridView dgvPoints = null)
        {
            // Verificar si el círculo excede el tamaño del PictureBox
            if (2 * mRadius * SF > picCanvas.Width || 2 * mRadius * SF > picCanvas.Height)
            {
                MessageBox.Show("El tamaño del círculo excede el tamaño del área de dibujo.",
                    "Tamaño excesivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Guardar referencia al DataGridView
            mDataGridView = dgvPoints;
            
            // Preparar el DataGridView si está disponible
            if (mDataGridView != null)
            {
                InitializeDataGridView();
            }

            // Inicializar el bitmap y el temporizador
            InitializeDrawing(picCanvas);

            // Crear un bolígrafo para dibujar puntos
            mPen = new Pen(Color.Green, 1);

            // Centro del círculo (en el centro del PictureBox)
            int centerX = picCanvas.Width / 2;
            int centerY = picCanvas.Height / 2;

            // Radio escalado
            int r = (int)(mRadius * SF);

            // Variables para el algoritmo del punto medio
            int x = 0;
            int y = r;
            int p = 1 - r; // Parámetro de decisión inicial

            // Precalcular todos los puntos
            mPoints = new List<Point>();

            // Agregar los primeros 8 puntos simétricos
            AgregarPuntos8Simetricos(centerX, centerY, x, y);

            // Algoritmo del punto medio
            while (x < y)
            {
                x++;

                // Actualizar el parámetro de decisión
                if (p < 0)
                {
                    p += 2 * x + 1;
                }
                else
                {
                    y--;
                    p += 2 * (x - y) + 1;
                }

                // Agregar los 8 puntos simétricos
                AgregarPuntos8Simetricos(centerX, centerY, x, y);
            }

            // Iniciar el temporizador para dibujar los puntos uno a uno
            mCurrentStep = 0;
            mTimer.Start();
        }

        // Método auxiliar para agregar los 8 puntos simétricos a la lista
        private void AgregarPuntos8Simetricos(int centerX, int centerY, int x, int y)
        {
            mPoints.Add(new Point(centerX + x, centerY + y)); // Octante 1
            mPoints.Add(new Point(centerX - x, centerY + y)); // Octante 4
            mPoints.Add(new Point(centerX + x, centerY - y)); // Octante 8
            mPoints.Add(new Point(centerX - x, centerY - y)); // Octante 5
            mPoints.Add(new Point(centerX + y, centerY + x)); // Octante 2
            mPoints.Add(new Point(centerX - y, centerY + x)); // Octante 3
            mPoints.Add(new Point(centerX + y, centerY - x)); // Octante 7
            mPoints.Add(new Point(centerX - y, centerY - x)); // Octante 6
        }

        // Método para manejar el clic en el PictureBox
        public void HandleCanvasClick(int x, int y)
        {
            // Iniciar el relleno por inundación animado
            StartFloodFill(x, y);
        }

        // Inicializa el DataGridView para mostrar los puntos
        private void InitializeDataGridView()
        {
            // Limpiar el DataGridView
            mDataGridView.Rows.Clear();
            
            // Si las columnas no están configuradas, configurarlas
            if (mDataGridView.Columns.Count == 0)
            {
                // Agregar columnas si no existen
                mDataGridView.Columns.Add("colIndex", "Índice");
                mDataGridView.Columns.Add("colX", "Coordenada X");
                mDataGridView.Columns.Add("colY", "Coordenada Y");
            }
            
            // Deshabilitar la actualización del control para mejorar el rendimiento
            mDataGridView.SuspendLayout();
            
            // Opcional: Ajustar tamaño de columnas automáticamente
            mDataGridView.AutoResizeColumns();
        }
        
        // Actualiza el DataGridView en tiempo real con los puntos dibujados
        private void UpdatePointsInGridLive(int currentStep)
        {
            try
            {
                // Solo actualizar si tenemos un DataGridView asignado
                if (mDataGridView == null) return;
                
                // Si estamos en el primer punto, limpiar el grid
                if (currentStep == 0)
                {
                    mDataGridView.Rows.Clear();
                    mDataGridView.SuspendLayout();
                }
                
                // Obtener el punto actual
                Point p = mPoints[currentStep];
                
                // Agregar el punto al DataGridView
                mDataGridView.Rows.Add(currentStep + 1, p.X, p.Y);
                
                // Opcional: Hacer scroll al último punto añadido
                if (mDataGridView.Rows.Count > 0)
                {
                    int lastIndex = mDataGridView.Rows.Count - 1;
                    mDataGridView.FirstDisplayedScrollingRowIndex = lastIndex;
                    mDataGridView.Rows[lastIndex].Selected = true;
                }
                
                // Si es el último punto, resumir el layout
                if (currentStep >= mPoints.Count - 1)
                {
                    mDataGridView.ResumeLayout();
                }
            }
            catch (Exception ex)
            {
                // Si ocurre un error, resumir el layout y mostrar el mensaje
                mDataGridView?.ResumeLayout();
                MessageBox.Show($"Error al actualizar la tabla de puntos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        // Método para mostrar todos los puntos en un DataGridView de una vez
        public void ShowPointsInGrid(DataGridView dgvPoints)
        {
            if (mPoints == null || mPoints.Count == 0)
            {
                MessageBox.Show("No hay puntos para mostrar. Dibuje primero un círculo.",
                    "Sin datos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                // Limpiar el DataGridView
                dgvPoints.Rows.Clear();

                // Si las columnas no están configuradas, configurarlas
                if (dgvPoints.Columns.Count == 0)
                {
                    // Agregar columnas si no existen
                    dgvPoints.Columns.Add("colIndex", "Índice");
                    dgvPoints.Columns.Add("colX", "Coordenada X");
                    dgvPoints.Columns.Add("colY", "Coordenada Y");
                }

                // Deshabilitar la actualización del control para mejorar el rendimiento
                dgvPoints.SuspendLayout();

                // Agregar los puntos al DataGridView
                for (int i = 0; i < mPoints.Count; i++)
                {
                    dgvPoints.Rows.Add(i + 1, mPoints[i].X, mPoints[i].Y);
                }

                // Volver a habilitar la actualización del control
                dgvPoints.ResumeLayout();

                // Opcional: Ajustar tamaño de columnas automáticamente
                dgvPoints.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al mostrar los puntos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}