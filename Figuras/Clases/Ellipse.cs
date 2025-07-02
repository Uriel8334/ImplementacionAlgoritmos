using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImplementacionAlgoritmos
{
    internal class Ellipse
    {
        // Atributos
        private int mRadiusX;           // Radio horizontal
        private int mRadiusY;           // Radio vertical
        private Point mCenter;          // Centro de la elipse
        private List<Point> mPoints;    // Puntos de la elipse
        private Bitmap mBitmap;         // Bitmap para dibujar
        private PictureBox picCanvas;   // Lienzo
        private Timer mTimer;           // Timer para animación
        private int mCurrentStep;       // Paso actual
        private Pen mPen;               // Bolígrafo para dibujar
        private DataGridView mDataGridView; // Para mostrar puntos

        // Constructor
        public Ellipse()
        {
            mRadiusX = 50;
            mRadiusY = 30;
            mCenter = new Point(200, 150);
            mPoints = new List<Point>();
            mPen = new Pen(Color.Blue, 2);
        }

        // Inicializar datos
        public void InitializeData(TextBox txtRadiusX, TextBox txtRadiusY, PictureBox canCanvas, DataGridView dgvPoints = null)
        {
            mRadiusX = 50;
            mRadiusY = 30;
            
            txtRadiusX.Text = "";
            txtRadiusY.Text = "";
            
            picCanvas = canCanvas;
            mDataGridView = dgvPoints;
            
            if (mTimer != null && mTimer.Enabled)
                mTimer.Stop();

            if (mBitmap != null)
                mBitmap.Dispose();

            mBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                g.Clear(UIStyleUtility.ControlBackgroundColor);
            }

            picCanvas.Image = mBitmap;
            mPoints.Clear();

            if (mDataGridView != null)
                InitializeDataGridView();
        }

        // Leer datos de entrada
        public void ReadData(TextBox txtRadiusX, TextBox txtRadiusY)
        {
            try
            {
                mRadiusX = int.Parse(txtRadiusX.Text);
                mRadiusY = int.Parse(txtRadiusY.Text);
                
                if (mRadiusX <= 0 || mRadiusY <= 0)
                {
                    MessageBox.Show("Los radios deben ser mayores que 0", "Error");
                    mRadiusX = 50;
                    mRadiusY = 30;
                }
            }
            catch
            {
                MessageBox.Show("Ingrese valores válidos", "Error");
                mRadiusX = 50;
                mRadiusY = 30;
            }
        }

        // Algoritmo de Bresenham para elipses
        public void BresenhamEllipse(PictureBox picCanvas, DataGridView dgvPoints = null)
        {
            picCanvas = this.picCanvas;
            mDataGridView = dgvPoints;
            
            mCenter = new Point(picCanvas.Width / 2, picCanvas.Height / 2);
            mPoints.Clear();

            int rx = mRadiusX;
            int ry = mRadiusY;
            int cx = mCenter.X;
            int cy = mCenter.Y;

            // Variables para el algoritmo
            int x = 0;
            int y = ry;
            int rx2 = rx * rx;
            int ry2 = ry * ry;
            int twoRx2 = 2 * rx2;
            int twoRy2 = 2 * ry2;
            int p;
            int px = 0;
            int py = twoRx2 * y;

            // Región 1
            p = (int)(ry2 - (rx2 * ry) + (0.25 * rx2));
            while (px < py)
            {
                AddEllipsePoints(cx, cy, x, y);
                x++;
                px += twoRy2;

                if (p < 0)
                {
                    p += ry2 + px;
                }
                else
                {
                    y--;
                    py -= twoRx2;
                    p += ry2 + px - py;
                }
            }

            // Región 2
            p = (int)(ry2 * (x + 0.5) * (x + 0.5) + rx2 * (y - 1) * (y - 1) - rx2 * ry2);
            while (y > 0)
            {
                AddEllipsePoints(cx, cy, x, y);
                y--;
                py -= twoRx2;

                if (p > 0)
                {
                    p += rx2 - py;
                }
                else
                {
                    x++;
                    px += twoRy2;
                    p += rx2 - py + px;
                }
            }

            // Iniciar animación
            InitializeDrawing();
        }

        // Agregar los 4 puntos simétricos de la elipse
        private void AddEllipsePoints(int cx, int cy, int x, int y)
        {
            mPoints.Add(new Point(cx + x, cy + y));
            mPoints.Add(new Point(cx - x, cy + y));
            mPoints.Add(new Point(cx + x, cy - y));
            mPoints.Add(new Point(cx - x, cy - y));
        }

        // Inicializar dibujo animado
        private void InitializeDrawing()
        {
            if (mTimer == null)
            {
                mTimer = new Timer();
                mTimer.Interval = 10;
                mTimer.Tick += Timer_Tick;
            }
            
            mCurrentStep = 0;
            mTimer.Start();
        }

        // Timer para animación
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (mCurrentStep >= mPoints.Count)
            {
                mTimer.Stop();
                return;
            }

            Point p = mPoints[mCurrentStep];
            if (p.X >= 0 && p.X < mBitmap.Width && p.Y >= 0 && p.Y < mBitmap.Height)
            {
                mBitmap.SetPixel(p.X, p.Y, mPen.Color);
            }

            picCanvas.Invalidate();

            if (mDataGridView != null && mCurrentStep % 10 == 0)
            {
                UpdateDataGrid(p.X, p.Y, mCurrentStep);
            }

            mCurrentStep++;
        }

        // Inicializar DataGridView
        private void InitializeDataGridView()
        {
            if (mDataGridView != null)
            {
                mDataGridView.Columns.Clear();
                mDataGridView.Columns.Add("X", "X");
                mDataGridView.Columns.Add("Y", "Y");
                mDataGridView.Columns.Add("Step", "Paso");
                mDataGridView.Rows.Clear();
            }
        }

        // Actualizar DataGridView
        private void UpdateDataGrid(int x, int y, int step)
        {
            if (mDataGridView != null)
            {
                mDataGridView.Rows.Add(x.ToString(), y.ToString(), step.ToString());
                if (mDataGridView.Rows.Count > 0)
                {
                    mDataGridView.FirstDisplayedScrollingRowIndex = mDataGridView.Rows.Count - 1;
                }
            }
        }

        // Cerrar formulario
        public void CloseForm(Form form)
        {
            form.Close();
        }
    }
}