using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImplementacionAlgoritmos
{
    internal class ScanlineFill
    {
        // Atributos
        private Bitmap mBitmap;
        private PictureBox picCanvas;
        private Timer mFillTimer;
        private Color mFillColor;
        private Color mBoundaryColor;
        private List<Point> mPolygonVertices;
        private int mCurrentScanLine;
        private int mMaxY;
        private int mMinY;

        // Constructor
        public ScanlineFill()
        {
            mFillColor = Color.LightGreen;
            mBoundaryColor = Color.Blue;
            mPolygonVertices = new List<Point>();
        }

        // Inicializar
        public void InitializeData(PictureBox canCanvas)
        {
            picCanvas = canCanvas;
            
            if (mFillTimer != null && mFillTimer.Enabled)
                mFillTimer.Stop();

            if (mBitmap != null)
                mBitmap.Dispose();

            mBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                g.Clear(UIStyleUtility.ControlBackgroundColor);
            }

            picCanvas.Image = mBitmap;
            mPolygonVertices.Clear();
        }

        // Agregar vértice del polígono
        public void AddVertex(int x, int y)
        {
            mPolygonVertices.Add(new Point(x, y));
            
            // Dibujar el punto
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                g.FillEllipse(new SolidBrush(Color.Red), x - 3, y - 3, 6, 6);
            }
            picCanvas.Invalidate();
        }

        // Dibujar polígono
        public void DrawPolygon()
        {
            if (mPolygonVertices.Count < 3) return;

            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                Point[] points = mPolygonVertices.ToArray();
                g.DrawPolygon(new Pen(mBoundaryColor, 2), points);
            }
            picCanvas.Invalidate();
        }

        // Algoritmo Scanline Fill
        public void StartScanlineFill()
        {
            if (mPolygonVertices.Count < 3)
            {
                MessageBox.Show("Necesita al menos 3 vértices para el polígono", "Error");
                return;
            }

            // Encontrar límites Y
            mMinY = int.MaxValue;
            mMaxY = int.MinValue;
            
            foreach (Point vertex in mPolygonVertices)
            {
                if (vertex.Y < mMinY) mMinY = vertex.Y;
                if (vertex.Y > mMaxY) mMaxY = vertex.Y;
            }

            // Iniciar animación
            mCurrentScanLine = mMinY;
            
            if (mFillTimer == null)
            {
                mFillTimer = new Timer();
                mFillTimer.Interval = 50;
                mFillTimer.Tick += FillTimer_Tick;
            }
            
            mFillTimer.Start();
        }

        // Timer para animación del relleno
        private void FillTimer_Tick(object sender, EventArgs e)
        {
            if (mCurrentScanLine > mMaxY)
            {
                mFillTimer.Stop();
                return;
            }

            // Encontrar intersecciones con la línea de barrido actual
            List<int> intersections = FindIntersections(mCurrentScanLine);
            
            // Ordenar intersecciones
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
                        if (x >= 0 && x < mBitmap.Width && mCurrentScanLine >= 0 && mCurrentScanLine < mBitmap.Height)
                        {
                            mBitmap.SetPixel(x, mCurrentScanLine, mFillColor);
                        }
                    }
                }
            }

            picCanvas.Invalidate();
            mCurrentScanLine++;
        }

        // Encontrar intersecciones de la línea de barrido con el polígono
        private List<int> FindIntersections(int y)
        {
            List<int> intersections = new List<int>();
            
            for (int i = 0; i < mPolygonVertices.Count; i++)
            {
                Point p1 = mPolygonVertices[i];
                Point p2 = mPolygonVertices[(i + 1) % mPolygonVertices.Count];
                
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

        // Limpiar polígono
        public void ClearPolygon()
        {
            mPolygonVertices.Clear();
            InitializeData(picCanvas);
        }

        // Cerrar formulario
        public void CloseForm(Form form)
        {
            form.Close();
        }
    }
}