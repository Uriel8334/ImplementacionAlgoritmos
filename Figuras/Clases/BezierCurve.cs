using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImplementacionAlgoritmos
{
    internal class BezierCurve
    {
        // Atributos
        private List<Point> mControlPoints;
        private List<Point> mCurvePoints;
        private Bitmap mBitmap;
        private PictureBox picCanvas;
        private Timer mDrawTimer;
        private int mCurrentStep;
        private DataGridView mDataGridView;

        // Constructor
        public BezierCurve()
        {
            mControlPoints = new List<Point>();
            mCurvePoints = new List<Point>();
        }

        // Inicializar
        public void InitializeData(PictureBox canCanvas, DataGridView dgvPoints = null)
        {
            picCanvas = canCanvas;
            mDataGridView = dgvPoints;

            if (mDrawTimer != null && mDrawTimer.Enabled)
                mDrawTimer.Stop();

            if (mBitmap != null)
                mBitmap.Dispose();

            mBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                g.Clear(UIStyleUtility.ControlBackgroundColor);
            }

            picCanvas.Image = mBitmap;
            mControlPoints.Clear();
            mCurvePoints.Clear();

            if (mDataGridView != null)
                InitializeDataGridView();
        }

        // Agregar punto de control
        public void AddControlPoint(int x, int y)
        {
            mControlPoints.Add(new Point(x, y));
            
            // Dibujar punto de control
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                g.FillEllipse(new SolidBrush(Color.Red), x - 4, y - 4, 8, 8);
                g.DrawString((mControlPoints.Count - 1).ToString(), 
                    new Font("Arial", 8), new SolidBrush(Color.Black), x + 5, y - 10);
            }

            // Dibujar líneas de control si hay más de un punto
            if (mControlPoints.Count > 1)
            {
                using (Graphics g = Graphics.FromImage(mBitmap))
                {
                    for (int i = 0; i < mControlPoints.Count - 1; i++)
                    {
                        g.DrawLine(new Pen(Color.Gray, 1), mControlPoints[i], mControlPoints[i + 1]);
                    }
                }
            }

            picCanvas.Invalidate();
        }

        // Calcular curva de Bézier
        public void CalculateBezierCurve()
        {
            if (mControlPoints.Count < 2)
            {
                MessageBox.Show("Necesita al menos 2 puntos de control", "Error");
                return;
            }

            mCurvePoints.Clear();
            int steps = 100;

            for (int i = 0; i <= steps; i++)
            {
                double t = (double)i / steps;
                Point curvePoint = CalculateBezierPoint(t);
                mCurvePoints.Add(curvePoint);
            }

            // Iniciar animación
            mCurrentStep = 0;
            if (mDrawTimer == null)
            {
                mDrawTimer = new Timer();
                mDrawTimer.Interval = 50;
                mDrawTimer.Tick += DrawTimer_Tick;
            }
            mDrawTimer.Start();
        }

        // Calcular punto en la curva usando algoritmo de De Casteljau
        private Point CalculateBezierPoint(double t)
        {
            List<Point> tempPoints = new List<Point>(mControlPoints);

            while (tempPoints.Count > 1)
            {
                List<Point> newPoints = new List<Point>();
                
                for (int i = 0; i < tempPoints.Count - 1; i++)
                {
                    int x = (int)(tempPoints[i].X * (1 - t) + tempPoints[i + 1].X * t);
                    int y = (int)(tempPoints[i].Y * (1 - t) + tempPoints[i + 1].Y * t);
                    newPoints.Add(new Point(x, y));
                }
                
                tempPoints = newPoints;
            }

            return tempPoints[0];
        }

        // Timer para animación
        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            if (mCurrentStep >= mCurvePoints.Count)
            {
                mDrawTimer.Stop();
                return;
            }

            Point p = mCurvePoints[mCurrentStep];
            
            if (p.X >= 0 && p.X < mBitmap.Width && p.Y >= 0 && p.Y < mBitmap.Height)
            {
                mBitmap.SetPixel(p.X, p.Y, Color.Blue);
                
                // Dibujar punto más grueso
                using (Graphics g = Graphics.FromImage(mBitmap))
                {
                    g.FillEllipse(new SolidBrush(Color.Blue), p.X - 1, p.Y - 1, 2, 2);
                }
            }

            picCanvas.Invalidate();

            if (mDataGridView != null && mCurrentStep % 5 == 0)
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
                mDataGridView.Columns.Add("T", "Parámetro T");
                mDataGridView.Rows.Clear();
            }
        }

        // Actualizar DataGridView
        private void UpdateDataGrid(int x, int y, int step)
        {
            if (mDataGridView != null)
            {
                double t = (double)step / 100;
                mDataGridView.Rows.Add(x.ToString(), y.ToString(), t.ToString("F3"));
                
                if (mDataGridView.Rows.Count > 0)
                {
                    mDataGridView.FirstDisplayedScrollingRowIndex = mDataGridView.Rows.Count - 1;
                }
            }
        }

        // Limpiar curva
        public void ClearCurve()
        {
            mControlPoints.Clear();
            mCurvePoints.Clear();
            InitializeData(picCanvas, mDataGridView);
        }

        // Cerrar formulario
        public void CloseForm(Form form)
        {
            form.Close();
        }
    }
}