using System;
using System.Drawing;

namespace AlgoritmoCohenSutherland
{
    public class CohenSutherlandAlgorithm
    {
        // Códigos de región para Cohen-Sutherland
        private const int INSIDE = 0; // 0000
        private const int LEFT = 1;   // 0001
        private const int RIGHT = 2;  // 0010
        private const int BOTTOM = 4; // 0100
        private const int TOP = 8;    // 1000

        // Límites de la ventana de recorte
        private int xMin, yMin, xMax, yMax;

        public Rectangle ClippingWindow
        {
            get
            {
                return new Rectangle(xMin, yMin, xMax - xMin, yMax - yMin);
            }
        }

        public CohenSutherlandAlgorithm(int x1, int y1, int x2, int y2)
        {
            xMin = Math.Min(x1, x2);
            yMin = Math.Min(y1, y2);
            xMax = Math.Max(x1, x2);
            yMax = Math.Max(y1, y2);
        }

        // Determina el código de región para un punto (x,y)
        private int ComputeCode(double x, double y)
        {
            // Inicializa como INSIDE
            int code = INSIDE;

            if (x < xMin)
                code |= LEFT;
            else if (x > xMax)
                code |= RIGHT;
            if (y < yMin)
                code |= BOTTOM;
            else if (y > yMax)
                code |= TOP;

            return code;
        }

        // Implementación del algoritmo Cohen-Sutherland para recortar líneas
        public bool ClipLine(ref int x1, ref int y1, ref int x2, ref int y2, out int code1, out int code2, out string clipResult)
        {
            double x1d = x1, y1d = y1, x2d = x2, y2d = y2;

            // Calcular códigos de región para P1, P2
            code1 = ComputeCode(x1d, y1d);
            code2 = ComputeCode(x2d, y2d);
            int originalCode1 = code1;
            int originalCode2 = code2;

            bool accept = false;
            clipResult = "";

            while (true)
            {
                // Si ambos extremos están dentro de la ventana
                if ((code1 | code2) == 0)
                {
                    accept = true;
                    clipResult = "Aceptación trivial";
                    break;
                }
                // Si ambos extremos están fuera de la misma región
                else if ((code1 & code2) != 0)
                {
                    clipResult = "Rechazo trivial";
                    break;
                }
                else
                {
                    clipResult = "Recorte calculado";
                    // Al menos uno está fuera, elegir uno
                    int codeOut = code1 != 0 ? code1 : code2;

                    double x, y;

                    // Encontrar intersección con el borde
                    if ((codeOut & TOP) != 0)
                    {
                        x = x1d + (x2d - x1d) * (yMax - y1d) / (y2d - y1d);
                        y = yMax;
                        clipResult += " (Intersección con TOP)";
                    }
                    else if ((codeOut & BOTTOM) != 0)
                    {
                        x = x1d + (x2d - x1d) * (yMin - y1d) / (y2d - y1d);
                        y = yMin;
                        clipResult += " (Intersección con BOTTOM)";
                    }
                    else if ((codeOut & RIGHT) != 0)
                    {
                        y = y1d + (y2d - y1d) * (xMax - x1d) / (x2d - x1d);
                        x = xMax;
                        clipResult += " (Intersección con RIGHT)";
                    }
                    else // (codeOut & LEFT) != 0
                    {
                        y = y1d + (y2d - y1d) * (xMin - x1d) / (x2d - x1d);
                        x = xMin;
                        clipResult += " (Intersección con LEFT)";
                    }

                    // Reemplazar el punto fuera de la ventana
                    if (codeOut == code1)
                    {
                        x1d = x;
                        y1d = y;
                        code1 = ComputeCode(x1d, y1d);
                    }
                    else
                    {
                        x2d = x;
                        y2d = y;
                        code2 = ComputeCode(x2d, y2d);
                    }
                }
            }

            if (accept)
            {
                x1 = (int)Math.Round(x1d);
                y1 = (int)Math.Round(y1d);
                x2 = (int)Math.Round(x2d);
                y2 = (int)Math.Round(y2d);
            }

            return accept;
        }
    }
}