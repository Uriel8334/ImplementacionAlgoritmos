using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ImplementacionAlgoritmos
{
    internal class Lines
    {
        // Atributos
        private Point startPoint;
        private Point endPoint;
        private List<Point> linePoints;
        private Bitmap bitmap;
        private PictureBox canvas;
        private Timer drawTimer;
        private int currentPointIndex;
        private DataGridView dataGridView;
        private bool isFirstPoint = true;

        // Colores
        private Color lineColor = Color.Blue;
        private Color pointColor = Color.Red;

        // Constructor
        public Lines()
        {
            linePoints = new List<Point>();
            drawTimer = new Timer();
            drawTimer.Interval = 50; // 50 ms de intervalo
            drawTimer.Tick += DrawTimer_Tick;
            currentPointIndex = 0;
        }

        // Método para inicializar el lienzo
        public void InitializeCanvas(PictureBox picCanvas, DataGridView dgvPoints)
        {
            canvas = picCanvas;
            dataGridView = dgvPoints;

            // Crear un nuevo bitmap del tamaño del canvas
            bitmap = new Bitmap(canvas.Width, canvas.Height);
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.PapayaWhip);
            }

            // Asignar el bitmap al canvas
            canvas.Image = bitmap;

            // Inicializar el DataGridView
            InitializeDataGridView();
        }

        // Método para inicializar el DataGridView
        private void InitializeDataGridView()
        {
            if (dataGridView != null)
            {
                // Limpiar columnas existentes
                dataGridView.Columns.Clear();

                // Agregar columnas
                dataGridView.Columns.Add("X", "X");
                dataGridView.Columns.Add("Y", "Y");
                dataGridView.Columns.Add("Step", "Paso");

                // Limpiar filas
                dataGridView.Rows.Clear();
            }
        }

        // Método para manejar el clic en el canvas
        public void HandleClick(PictureBox picCanvas, MouseEventArgs e)
        {
            if (isFirstPoint)
            {
                // Primer punto
                startPoint = new Point(e.X, e.Y);
                DrawCircle(e.X, e.Y);
                isFirstPoint = false;
            }
            else
            {
                // Segundo punto
                endPoint = new Point(e.X, e.Y);
                DrawCircle(e.X, e.Y);

                // Calcular y dibujar la línea
                CalculateDDALine();

                // Iniciar la animación
                currentPointIndex = 0;
                drawTimer.Start();

                // Resetear para el próximo par de puntos
                isFirstPoint = true;
            }
        }

        // Método para calcular los puntos de la línea con DDA
        private void CalculateDDALine()
        {
            linePoints.Clear();

            // Calcular diferencias
            int dx = endPoint.X - startPoint.X;
            int dy = endPoint.Y - startPoint.Y;

            // Determinar el número de pasos
            int steps = Math.Max(Math.Abs(dx), Math.Abs(dy));

            // Calcular incrementos
            float xIncrement = dx / (float)steps;
            float yIncrement = dy / (float)steps;

            // Valores iniciales
            float x = startPoint.X;
            float y = startPoint.Y;

            // Generar todos los puntos
            for (int i = 0; i <= steps; i++)
            {
                linePoints.Add(new Point((int)Math.Round(x), (int)Math.Round(y)));
                x += xIncrement;
                y += yIncrement;
            }
        }

        // Método para el timer que anima el dibujo de la línea
        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            if (currentPointIndex < linePoints.Count)
            {
                // Obtener el punto actual
                Point currentPoint = linePoints[currentPointIndex];

                // Dibujar el punto en el bitmap
                DrawPixel(currentPoint.X, currentPoint.Y, lineColor);

                // Actualizar el DataGridView
                UpdateDataGrid(currentPoint.X, currentPoint.Y, currentPointIndex);

                // Incrementar índice
                currentPointIndex++;
            }
            else
            {
                // Detener el timer cuando se han dibujado todos los puntos
                drawTimer.Stop();
            }
        }
        // Método para calcular los puntos de la línea con el algoritmo de Bresenham
        public void CalculateBresenhamLine()
        {
            linePoints.Clear();

            int x1 = startPoint.X;
            int y1 = startPoint.Y;
            int x2 = endPoint.X;
            int y2 = endPoint.Y;

            // Variables para el algoritmo de Bresenham
            int dx = Math.Abs(x2 - x1);
            int dy = Math.Abs(y2 - y1);
            int sx = (x1 < x2) ? 1 : -1;
            int sy = (y1 < y2) ? 1 : -1;
            int err = dx - dy;

            while (true)
            {
                // Agregar el punto actual a la lista
                linePoints.Add(new Point(x1, y1));

                // Si hemos llegado al punto final, salir
                if (x1 == x2 && y1 == y2)
                    break;

                // Calcular el próximo punto
                int e2 = 2 * err;
                if (e2 > -dy)
                {
                    err -= dy;
                    x1 += sx;
                }
                if (e2 < dx)
                {
                    err += dx;
                    y1 += sy;
                }
            }
        }

        // Método para iniciar el dibujo de una línea con Bresenham
        public void DrawBresenhamLine(PictureBox picCanvas, MouseEventArgs e)
        {
            HandleClickForBresenham(picCanvas, e);
        }

        // Método para manejar clicks para el algoritmo de Bresenham
        public void HandleClickForBresenham(PictureBox picCanvas, MouseEventArgs e)
        {
            if (isFirstPoint)
            {
                // Primer punto
                startPoint = new Point(e.X, e.Y);
                DrawCircle(e.X, e.Y);
                isFirstPoint = false;
            }
            else
            {
                // Segundo punto
                endPoint = new Point(e.X, e.Y);
                DrawCircle(e.X, e.Y);

                // Calcular los puntos usando el algoritmo de Bresenham
                CalculateBresenhamLine();

                // Iniciar la animación
                currentPointIndex = 0;
                drawTimer.Start();

                // Resetear para el próximo par de puntos
                isFirstPoint = true;
            }
        }

        // Método para dibujar un pixel
        private void DrawPixel(int x, int y, Color color)
        {
            if (x >= 0 && x < bitmap.Width && y >= 0 && y < bitmap.Height)
            {
                bitmap.SetPixel(x, y, color);
                canvas.Invalidate(); // Actualizar el canvas
            }
        }

        // Método para dibujar un círculo en un vértice
        public void DrawCircle(int x, int y)
        {
            // Radio del círculo
            int radius = 3;

            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.DrawEllipse(new Pen(pointColor, 1), x - radius, y - radius, radius * 2, radius * 2);
            }

            canvas.Invalidate();
        }

        // Método para actualizar el DataGridView
        private void UpdateDataGrid(int x, int y, int step)
        {
            if (dataGridView != null)
            {
                dataGridView.Rows.Add(x.ToString(), y.ToString(), step.ToString());

                // Auto-scroll al final
                if (dataGridView.Rows.Count > 0)
                {
                    dataGridView.FirstDisplayedScrollingRowIndex = dataGridView.Rows.Count - 1;
                }
            }
        }

        // Método para resetear el canvas
        // Método para resetear el canvas
        public void ResetCanvas(PictureBox picCanvas)
        {
            using (Graphics g = Graphics.FromImage(bitmap))
            {
                g.Clear(Color.PapayaWhip);

                // Opcionalmente, agregar un sutil efecto de gradiente
                using (LinearGradientBrush backgroundBrush = new LinearGradientBrush(
                    new Rectangle(0, 0, canvas.Width, canvas.Height),
                    Color.FromArgb(250, 245, 230), // Crema muy claro
                    Color.FromArgb(245, 245, 220), // Beige claro
                    LinearGradientMode.ForwardDiagonal))
                {
                    g.FillRectangle(backgroundBrush, 0, 0, canvas.Width, canvas.Height);
                }
            }

            canvas.Invalidate();

            if (dataGridView != null)
            {
                dataGridView.Rows.Clear();
            }

            isFirstPoint = true;
        }
        // Método para cerrar el formulario
        public void CloseForm(Form form)
        {
            form.Close();
        }

        // Método para dibujar la línea manualmente (sin animación)
        public void DrawLine(PictureBox picCanvas, MouseEventArgs e)
        {
            HandleClick(picCanvas, e);
        }
    }
}