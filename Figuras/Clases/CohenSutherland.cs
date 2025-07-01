using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ImplementacionAlgoritmos
{
    internal class CohenSutherland
    {
        // Códigos de región
        private const int INSIDE = 0; // 0000
        private const int LEFT = 1;   // 0001
        private const int RIGHT = 2;  // 0010
        private const int BOTTOM = 4; // 0100
        private const int TOP = 8;    // 1000

        // Atributos
        private Rectangle mClipWindow;
        private Bitmap mBitmap;
        private PictureBox picCanvas;
        private List<Point> mLinePoints;
        private List<Point> mClippedPoints;
        private bool mDefiningWindow;
        private Point mWindowStart;

        // Constructor
        public CohenSutherland()
        {
            mClipWindow = new Rectangle(50, 50, 200, 150);
            mLinePoints = new List<Point>();
            mClippedPoints = new List<Point>();
            mDefiningWindow = false;
        }

        // Inicializar
        public void InitializeData(PictureBox canCanvas)
        {
            picCanvas = canCanvas;

            if (mBitmap != null)
                mBitmap.Dispose();

            mBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                g.Clear(UIStyleUtility.ControlBackgroundColor);
            }

            picCanvas.Image = mBitmap;
            mLinePoints.Clear();
            mClippedPoints.Clear();
            
            DrawClipWindow();
        }

        // Dibujar ventana de recorte
        private void DrawClipWindow()
        {
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                g.DrawRectangle(new Pen(Color.Red, 2), mClipWindow);
            }
            picCanvas.Invalidate();
        }

        // Calcular código de región para un punto
        private int ComputeRegionCode(int x, int y)
        {
            int code = INSIDE;

            if (x < mClipWindow.Left)
                code |= LEFT;
            else if (x > mClipWindow.Right)
                code |= RIGHT;

            if (y < mClipWindow.Top)
                code |= TOP;
            else if (y > mClipWindow.Bottom)
                code |= BOTTOM;

            return code;
        }

        // Algoritmo Cohen-Sutherland
        public bool ClipLine(ref Point p1, ref Point p2)
        {
            int code1 = ComputeRegionCode(p1.X, p1.Y);
            int code2 = ComputeRegionCode(p2.X, p2.Y);
            bool accept = false;

            while (true)
            {
                if ((code1 | code2) == 0)
                {
                    // Ambos puntos están dentro
                    accept = true;
                    break;
                }
                else if ((code1 & code2) != 0)
                {
                    // Ambos puntos están en la misma región exterior
                    break;
                }
                else
                {
                    // Calcular intersección
                    int codeOut = (code1 != 0) ? code1 : code2;
                    int x = 0, y = 0;

                    if ((codeOut & TOP) != 0)
                    {
                        x = p1.X + (p2.X - p1.X) * (mClipWindow.Top - p1.Y) / (p2.Y - p1.Y);
                        y = mClipWindow.Top;
                    }
                    else if ((codeOut & BOTTOM) != 0)
                    {
                        x = p1.X + (p2.X - p1.X) * (mClipWindow.Bottom - p1.Y) / (p2.Y - p1.Y);
                        y = mClipWindow.Bottom;
                    }
                    else if ((codeOut & RIGHT) != 0)
                    {
                        y = p1.Y + (p2.Y - p1.Y) * (mClipWindow.Right - p1.X) / (p2.X - p1.X);
                        x = mClipWindow.Right;
                    }
                    else if ((codeOut & LEFT) != 0)
                    {
                        y = p1.Y + (p2.Y - p1.Y) * (mClipWindow.Left - p1.X) / (p2.X - p1.X);
                        x = mClipWindow.Left;
                    }

                    if (codeOut == code1)
                    {
                        p1.X = x;
                        p1.Y = y;
                        code1 = ComputeRegionCode(p1.X, p1.Y);
                    }
                    else
                    {
                        p2.X = x;
                        p2.Y = y;
                        code2 = ComputeRegionCode(p2.X, p2.Y);
                    }
                }
            }

            return accept;
        }

        // Agregar línea
        public void AddLine(Point start, Point end)
        {
            // Dibujar línea original
            using (Graphics g = Graphics.FromImage(mBitmap))
            {
                g.DrawLine(new Pen(Color.Blue, 1), start, end);
            }

            // Aplicar recorte
            Point clippedStart = start;
            Point clippedEnd = end;
            
            if (ClipLine(ref clippedStart, ref clippedEnd))
            {
                // Dibujar línea recortada
                using (Graphics g = Graphics.FromImage(mBitmap))
                {
                    g.DrawLine(new Pen(Color.Green, 3), clippedStart, clippedEnd);
                }
            }

            picCanvas.Invalidate();
        }

        // Manejar clic del mouse
        public void HandleMouseClick(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Cambiar modo de definición de ventana
                mDefiningWindow = !mDefiningWindow;
                if (mDefiningWindow)
                {
                    mWindowStart = new Point(e.X, e.Y);
                }
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (mDefiningWindow)
                {
                    // Definir nueva ventana de recorte
                    int width = Math.Abs(e.X - mWindowStart.X);
                    int height = Math.Abs(e.Y - mWindowStart.Y);
                    int x = Math.Min(mWindowStart.X, e.X);
                    int y = Math.Min(mWindowStart.Y, e.Y);
                    
                    mClipWindow = new Rectangle(x, y, width, height);
                    mDefiningWindow = false;
                    
                    // Redibujar todo
                    InitializeData(picCanvas);
                }
                else
                {
                    // Agregar punto para línea
                    mLinePoints.Add(new Point(e.X, e.Y));
                    
                    if (mLinePoints.Count == 2)
                    {
                        AddLine(mLinePoints[0], mLinePoints[1]);
                        mLinePoints.Clear();
                    }
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