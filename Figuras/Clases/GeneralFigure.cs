using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImplementacionAlgoritmos
{
    internal class GeneralFigure
    {
        // Atributos
        private int mSides;             // Número de lados
        private int mRadius;            // Radio
        private Point[] mVertices;      // Vértices del polígono
        private Pen mPen;               // Bolígrafo para dibujar
        private PictureBox picCanvas;   // Lienzo
        private Bitmap mBitmap;         // Bitmap para dibujar
        private Timer mDrawTimer;       // Timer para animación de dibujo
        private Timer mFillTimer;       // Timer para animación de relleno
        private int mCurrentEdge;       // Índice del borde actual en animación
        private Color mFillColor;       // Color para el relleno
        private Queue<Point> mFillQueue; // Cola para el algoritmo de relleno

        // Para el DataGridView
        private DataGridView mDataGridView;

        // Constructor
        public GeneralFigure()
        {
            mSides = 3;                 // Triángulo por defecto
            mRadius = 100;              // Radio por defecto
            mPen = new Pen(Color.Blue, 2);
            mFillColor = Color.LightBlue;
            mFillQueue = new Queue<Point>();

            // Inicializar los timers
            mDrawTimer = new Timer();
            mDrawTimer.Interval = 50; // 50ms
            mDrawTimer.Tick += DrawTimer_Tick;

            mFillTimer = new Timer();
            mFillTimer.Interval = 10; // 10ms para relleno más rápido
            mFillTimer.Tick += FillTimer_Tick;
        }

        // Método para inicializar los datos y el lienzo
        public void InitializeData(TextBox txtSides, TextBox txtRadius, PictureBox canCanvas, DataGridView dgvPoints = null)
        {
            // Limpiar los datos
            mSides = 3;
            mRadius = 100;

            // Limpiar los controles
            txtSides.Text = "";
            txtRadius.Text = "";

            // Referencia al PictureBox
            picCanvas = canCanvas;

            // Referencia al DataGridView si existe
            mDataGridView = dgvPoints;
            if (mDataGridView != null)
            {
                InitializeDataGridView();
            }

            // Detener timers si están activos
            if (mDrawTimer.Enabled)
                mDrawTimer.Stop();

            if (mFillTimer.Enabled)
                mFillTimer.Stop();

            // Limpiar la cola de relleno
            mFillQueue.Clear();

            // Limpiar el bitmap
            if (mBitmap != null)
            {
                mBitmap.Dispose();
            }

            // Crear un nuevo bitmap
            mBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                g.Clear(UIStyleUtility.ControlBackgroundColor);
            }

            picCanvas.Image = mBitmap;

            // Poner el foco en el primer TextBox
            txtSides.Focus();
        }

        // Método para leer los datos de entrada
        public void ReadData(TextBox txtSides, TextBox txtRadius)
        {
            try
            {
                mSides = int.Parse(txtSides.Text);
                if (mSides < 3)
                {
                    MessageBox.Show("El número de lados debe ser al menos 3", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mSides = 3;
                    txtSides.Text = "3";
                }

                mRadius = int.Parse(txtRadius.Text);
                if (mRadius <= 0)
                {
                    MessageBox.Show("El radio debe ser mayor que 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    mRadius = 100;
                    txtRadius.Text = "100";
                }
            }
            catch
            {
                MessageBox.Show("Por favor ingrese valores numéricos válidos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                mSides = 3;
                mRadius = 100;
            }
        }

        // Método para dibujar la figura completa (sin animación)
        public void PlotShape(PictureBox canCanvas)
        {
            picCanvas = canCanvas;

            // Verificar si el radio es demasiado grande para el PictureBox
            if (mRadius * 2 > Math.Min(picCanvas.Width, picCanvas.Height))
            {
                MessageBox.Show("El radio es demasiado grande para el área de dibujo",
                    "Tamaño excesivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Limpiar el bitmap
            if (mBitmap == null || mBitmap.Width != picCanvas.Width || mBitmap.Height != picCanvas.Height)
            {
                mBitmap?.Dispose();
                mBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            }

            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                g.Clear(UIStyleUtility.ControlBackgroundColor);

                // Dibujar el polígono
                DrawFigure(g, mSides, mRadius);
            }

            // Actualizar el canvas
            picCanvas.Image = mBitmap;
        }

        // Método para dibujar la figura con animación
        public void AnimatePlotShape(PictureBox canCanvas, DataGridView dgvPoints = null)
        {
            picCanvas = canCanvas;
            mDataGridView = dgvPoints;

            // Verificar si el radio es demasiado grande para el PictureBox
            if (mRadius * 2 > Math.Min(picCanvas.Width, picCanvas.Height))
            {
                MessageBox.Show("El radio es demasiado grande para el área de dibujo",
                    "Tamaño excesivo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Inicializar el DataGridView si existe
            if (mDataGridView != null)
            {
                InitializeDataGridView();
            }

            // Limpiar el bitmap
            if (mBitmap == null || mBitmap.Width != picCanvas.Width || mBitmap.Height != picCanvas.Height)
            {
                mBitmap?.Dispose();
                mBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            }

            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                g.Clear(UIStyleUtility.ControlBackgroundColor);
            }

            // Calcular los vértices de la figura
            CalculateVertices();

            // Iniciar el timer para la animación
            mCurrentEdge = 0;
            mDrawTimer.Start();

            // Actualizar el canvas
            picCanvas.Image = mBitmap;
        }

        // Método para calcular los vértices del polígono
        private void CalculateVertices()
        {
            // Definir el centro de la figura en el centro del bitmap
            Point center = new Point(picCanvas.Width / 2, picCanvas.Height / 2);

            // Crear un array para almacenar los puntos del polígono
            mVertices = new Point[mSides];

            // Calcular cada punto en el círculo
            for (int i = 0; i < mSides; i++)
            {
                // Fórmula para calcular puntos en un círculo
                double angle = (Math.PI * 2 * i / mSides) - Math.PI / 2;

                int x = (int)(center.X + mRadius * Math.Cos(angle));
                int y = (int)(center.Y + mRadius * Math.Sin(angle));

                mVertices[i] = new Point(x, y);
            }
        }

        // Método para dibujar la figura
        private void DrawFigure(Graphics g, int lados, int radio)
        {
            // Definir el centro de la figura en el centro del bitmap
            Point center = new Point(picCanvas.Width / 2, picCanvas.Height / 2);

            // Crear un array para almacenar los puntos del polígono
            Point[] points = new Point[lados];

            // Calcular cada punto en el círculo
            for (int i = 0; i < lados; i++)
            {
                // Fórmula para calcular puntos en un círculo: 
                // x = centerX + radius * cos(angle)
                // y = centerY + radius * sin(angle)
                // El ángulo se calcula como: 2π * i / lados (rotación completa distribuida entre los lados)
                // Restamos π/2 para empezar desde la parte superior (en lugar de la derecha)
                double angle = (Math.PI * 2 * i / lados) - Math.PI / 2;

                int x = (int)(center.X + radio * Math.Cos(angle));
                int y = (int)(center.Y + radio * Math.Sin(angle));

                points[i] = new Point(x, y);
            }

            // Dibujar el polígono
            g.DrawPolygon(mPen, points);
        }

        // Timer para animar el dibujo
        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            if (mCurrentEdge < mSides)
            {
                using (Graphics g = Graphics.FromImage(mBitmap))
                {
                    // Dibujar la línea actual
                    int nextVertex = (mCurrentEdge + 1) % mSides;
                    g.DrawLine(mPen, mVertices[mCurrentEdge], mVertices[nextVertex]);
                }

                // Actualizar el DataGridView si está disponible
                if (mDataGridView != null)
                {
                    UpdateDataGrid(mVertices[mCurrentEdge].X, mVertices[mCurrentEdge].Y, mCurrentEdge);
                }

                // Actualizar el canvas
                picCanvas.Invalidate();

                // Pasar al siguiente borde
                mCurrentEdge++;
            }
            else
            {
                // Detener el timer cuando se ha dibujado toda la figura
                mDrawTimer.Stop();

                // Si hay un DataGridView, añadir el último vértice
                if (mDataGridView != null && mSides > 0)
                {
                    UpdateDataGrid(mVertices[0].X, mVertices[0].Y, mSides);
                }
            }
        }

        // Método para inicializar el DataGridView
        private void InitializeDataGridView()
        {
            if (mDataGridView != null)
            {
                // Limpiar columnas existentes
                mDataGridView.Columns.Clear();

                // Agregar columnas
                mDataGridView.Columns.Add("X", "X");
                mDataGridView.Columns.Add("Y", "Y");
                mDataGridView.Columns.Add("Vertex", "Vértice");

                // Limpiar filas
                mDataGridView.Rows.Clear();
            }
        }

        // Método para actualizar el DataGridView
        private void UpdateDataGrid(int x, int y, int vertex)
        {
            if (mDataGridView != null)
            {
                mDataGridView.Rows.Add(x.ToString(), y.ToString(), (vertex + 1).ToString());

                // Auto-scroll al final
                if (mDataGridView.Rows.Count > 0)
                {
                    mDataGridView.FirstDisplayedScrollingRowIndex = mDataGridView.Rows.Count - 1;
                }
            }
        }

        // Método para manejar el clic en el canvas para el relleno
        public void HandleCanvasClick(int x, int y)
        {
            // Iniciar el relleno por inundación
            StartFloodFill(x, y);
        }

        // Método para iniciar el relleno por inundación
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
            if (targetColor.ToArgb() == UIStyleUtility.ControlBackgroundColor.ToArgb())
            {
                // Limpiar la cola existente
                mFillQueue.Clear();

                // Agregar el punto inicial a la cola
                mFillQueue.Enqueue(new Point(x, y));

                // Iniciar el timer para la animación de relleno
                mFillTimer.Start();
            }
        }

        // Timer para animar el relleno
        private void FillTimer_Tick(object sender, EventArgs e)
        {
            // Número de píxeles a procesar por tick
            int pixelsPerTick = 200;
            int pixelsProcessed = 0;

            // Color objetivo (fondo)
            Color targetColor = UIStyleUtility.ControlBackgroundColor;

            // Procesar un lote de píxeles
            while (mFillQueue.Count > 0 && pixelsProcessed < pixelsPerTick)
            {
                // Obtener el siguiente punto
                Point p = mFillQueue.Dequeue();

                // Verificar si está dentro de los límites
                if (p.X < 0 || p.Y < 0 || p.X >= mBitmap.Width || p.Y >= mBitmap.Height)
                    continue;

                // Obtener el color actual del píxel
                Color currentColor = mBitmap.GetPixel(p.X, p.Y);

                // Si es el color objetivo, rellenar
                if (currentColor.ToArgb() == targetColor.ToArgb())
                {
                    // Pintar este píxel
                    mBitmap.SetPixel(p.X, p.Y, mFillColor);
                    pixelsProcessed++;

                    // Agregar los pixeles vecinos a la cola
                    mFillQueue.Enqueue(new Point(p.X + 1, p.Y)); // Derecha
                    mFillQueue.Enqueue(new Point(p.X - 1, p.Y)); // Izquierda
                    mFillQueue.Enqueue(new Point(p.X, p.Y + 1)); // Abajo
                    mFillQueue.Enqueue(new Point(p.X, p.Y - 1)); // Arriba
                }
            }

            // Actualizar el canvas
            picCanvas.Invalidate();

            // Detener el timer si ya no hay más puntos en la cola
            if (mFillQueue.Count == 0)
            {
                mFillTimer.Stop();
            }
        }

        // Método para cerrar el formulario
        public void CloseForm(Form form)
        {
            form.Close();
        }

        // Nuevo método para el relleno Scanline
        public void StartScanlineFillOnPolygon()
        {
            if (mVertices == null || mVertices.Length < 3)
            {
                MessageBox.Show("Primero debe dibujar un polígono", "Error");
                return;
            }

            // Convertir vértices a lista de puntos para reutilizar el algoritmo
            List<Point> polygonVertices = new List<Point>(mVertices);

            // Aplicar Scanline Fill al polígono existente
            ApplyScanlineFill(polygonVertices);
        }

        // Implementación del algoritmo Scanline Fill para el polígono actual
        private void ApplyScanlineFill(List<Point> vertices)
        {
            if (vertices.Count < 3) return;

            // Encontrar límites Y
            int minY = int.MaxValue;
            int maxY = int.MinValue;

            foreach (Point vertex in vertices)
            {
                if (vertex.Y < minY) minY = vertex.Y;
                if (vertex.Y > maxY) maxY = vertex.Y;
            }

            // Color para el relleno Scanline (diferente al FloodFill)
            Color scanlineFillColor = Color.Orange;

            // Procesar cada línea de barrido
            for (int y = minY; y <= maxY; y++)
            {
                List<int> intersections = FindScanlineIntersections(y, vertices);
                intersections.Sort();

                // Rellenar entre pares de intersecciones
                for (int i = 0; i < intersections.Count - 1; i += 2)
                {
                    if (i + 1 < intersections.Count)
                    {
                        int startX = intersections[i];
                        int endX = intersections[i + 1];

                        for (int x = startX; x <= endX; x++)
                        {
                            if (x >= 0 && x < mBitmap.Width && y >= 0 && y < mBitmap.Height)
                            {
                                // Solo rellenar si no es parte del borde
                                Color currentColor = mBitmap.GetPixel(x, y);
                                if (currentColor.ToArgb() != mPen.Color.ToArgb())
                                {
                                    mBitmap.SetPixel(x, y, scanlineFillColor);
                                }
                            }
                        }
                    }
                }
            }

            picCanvas.Invalidate();
        }

        // Encontrar intersecciones de la línea de barrido con el polígono
        private List<int> FindScanlineIntersections(int y, List<Point> vertices)
        {
            List<int> intersections = new List<int>();

            for (int i = 0; i < vertices.Count; i++)
            {
                Point p1 = vertices[i];
                Point p2 = vertices[(i + 1) % vertices.Count];

                // Verificar si la línea de barrido intersecta con este borde
                if ((p1.Y <= y && p2.Y > y) || (p2.Y <= y && p1.Y > y))
                {
                    // Calcular la intersección X
                    double intersectionX = p1.X + (double)(y - p1.Y) / (p2.Y - p1.Y) * (p2.X - p1.X);
                    intersections.Add((int)Math.Round(intersectionX));
                }
            }

            return intersections;
        }
    }
}