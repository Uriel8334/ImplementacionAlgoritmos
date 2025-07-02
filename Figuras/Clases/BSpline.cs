using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImplementacionAlgoritmos
{
    internal class BSpline
    {
        // Atributos
        private List<Point> mControlPoints;
        private List<Point> mCurvePoints;
        private Bitmap mBitmap;
        private PictureBox picCanvas;
        private Timer mDrawTimer;
        private int mCurrentStep;
        private DataGridView mDataGridView;
        private int mDegree; // Grado de la B-Spline
        private List<double> mKnotVector; // Vector de nudos

        // Constructor
        public BSpline()
        {
            mControlPoints = new List<Point>();
            mCurvePoints = new List<Point>();
            mDegree = 3; // B-Spline cúbica por defecto
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

        // Establecer grado de la B-Spline
        public void SetDegree(int degree)
        {
            if (degree > 0)
                mDegree = degree;
        }

        // Calcular curva B-Spline
        public void CalculateBSpline()
        {
            if (mControlPoints.Count < mDegree + 1)
            {
                MessageBox.Show($"Necesita al menos {mDegree + 1} puntos de control para una B-Spline de grado {mDegree}", "Error");
                return;
            }

            mCurvePoints.Clear();
            
            // Generar vector de nudos uniforme
            GenerateKnotVector();

            // Calcular puntos de la curva
            int steps = 200;
            double tMin = mKnotVector[mDegree];
            double tMax = mKnotVector[mControlPoints.Count];
            
            for (int i = 0; i <= steps; i++)
            {
                double t = tMin + (double)i / steps * (tMax - tMin);
                Point curvePoint = CalculateBSplinePoint(t);
                mCurvePoints.Add(curvePoint);
            }

            // Iniciar animación
            mCurrentStep = 0;
            if (mDrawTimer == null)
            {
                mDrawTimer = new Timer();
                mDrawTimer.Interval = 20;
                mDrawTimer.Tick += DrawTimer_Tick;
            }
            mDrawTimer.Start();
        }

        // Generar vector de nudos uniforme
        private void GenerateKnotVector()
        {
            mKnotVector = new List<double>();
            int n = mControlPoints.Count;
            int m = n + mDegree + 1;

            // Vector de nudos uniforme abierto
            for (int i = 0; i < m; i++)
            {
                if (i <= mDegree)
                    mKnotVector.Add(0.0);
                else if (i >= n)
                    mKnotVector.Add(1.0);
                else
                    mKnotVector.Add((double)(i - mDegree) / (n - mDegree));
            }
        }

        // Calcular punto en la curva B-Spline usando algoritmo de De Boor
        private Point CalculateBSplinePoint(double t)
        {
            int n = mControlPoints.Count;
            
            // Encontrar el intervalo de nudos que contiene t
            int k = FindKnotSpan(t);
            
            // Algoritmo de De Boor
            Point[] d = new Point[mDegree + 1];
            
            // Inicializar con puntos de control relevantes
            for (int j = 0; j <= mDegree; j++)
            {
                d[j] = mControlPoints[k - mDegree + j];
            }

            // Aplicar algoritmo de De Boor
            for (int r = 1; r <= mDegree; r++)
            {
                for (int j = mDegree; j >= r; j--)
                {
                    double alpha = (t - mKnotVector[k - mDegree + j]) / 
                                  (mKnotVector[k + j - r + 1] - mKnotVector[k - mDegree + j]);
                    
                    int newX = (int)((1.0 - alpha) * d[j - 1].X + alpha * d[j].X);
                    int newY = (int)((1.0 - alpha) * d[j - 1].Y + alpha * d[j].Y);
                    d[j] = new Point(newX, newY);
                }
            }

            return d[mDegree];
        }

        // Encontrar el intervalo de nudos
        private int FindKnotSpan(double t)
        {
            int n = mControlPoints.Count;
            
            if (t >= mKnotVector[n])
                return n - 1;
            
            if (t <= mKnotVector[mDegree])
                return mDegree;

            // Búsqueda binaria
            int low = mDegree;
            int high = n;
            int mid = (low + high) / 2;

            while (t < mKnotVector[mid] || t >= mKnotVector[mid + 1])
            {
                if (t < mKnotVector[mid])
                    high = mid;
                else
                    low = mid;
                mid = (low + high) / 2;
            }

            return mid;
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
                // Dibujar punto más grueso para B-Spline
                using (Graphics g = Graphics.FromImage(mBitmap))
                {
                    g.FillEllipse(new SolidBrush(Color.Green), p.X - 1, p.Y - 1, 3, 3);
                }
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
                mDataGridView.Columns.Add("T", "Parámetro T");
                mDataGridView.Rows.Clear();
            }
        }

        // Actualizar DataGridView
        private void UpdateDataGrid(int x, int y, int step)
        {
            if (mDataGridView != null)
            {
                double t = (double)step / 200;
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