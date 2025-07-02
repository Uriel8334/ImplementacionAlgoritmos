using System;
using System.Collections.Generic;
using System.Drawing;

namespace AlgoritmoCohenSutherland
{
    internal class Sutherland_HodgmanAlgorithm
    {
        // Límites de la ventana de recorte
        private int xMin, yMin, xMax, yMax;

        public Rectangle ClippingWindow
        {
            get
            {
                return new Rectangle(xMin, yMin, xMax - xMin, yMax - yMin);
            }
        }

        public Sutherland_HodgmanAlgorithm(int x1, int y1, int x2, int y2)
        {
            xMin = Math.Min(x1, x2);
            yMin = Math.Min(y1, y2);
            xMax = Math.Max(x1, x2);
            yMax = Math.Max(y1, y2);
        }

        // Enumera los lados del rectángulo de recorte
        private enum ClipEdge
        {
            Left,
            Right,
            Bottom,
            Top
        }

        // Determina si un punto está dentro de un borde específico
        private bool IsInside(Point p, ClipEdge edge)
        {
            switch (edge)
            {
                case ClipEdge.Left:
                    return p.X >= xMin;
                case ClipEdge.Right:
                    return p.X <= xMax;
                case ClipEdge.Bottom:
                    return p.Y >= yMin;
                case ClipEdge.Top:
                    return p.Y <= yMax;
                default:
                    return false;
            }
        }

        // Calcula la intersección de una línea con un borde específico
        private Point ComputeIntersection(Point p1, Point p2, ClipEdge edge)
        {
            int x = 0, y = 0;

            // Evitar división por cero
            if (Math.Abs(p2.X - p1.X) < 0.001 && (edge == ClipEdge.Left || edge == ClipEdge.Right))
            {
                x = (edge == ClipEdge.Left) ? xMin : xMax;
                y = p1.Y;
                return new Point(x, y);
            }

            if (Math.Abs(p2.Y - p1.Y) < 0.001 && (edge == ClipEdge.Bottom || edge == ClipEdge.Top))
            {
                y = (edge == ClipEdge.Bottom) ? yMin : yMax;
                x = p1.X;
                return new Point(x, y);
            }

            switch (edge)
            {
                case ClipEdge.Left:
                    x = xMin;
                    y = p1.Y + (p2.Y - p1.Y) * (xMin - p1.X) / (p2.X - p1.X);
                    break;
                case ClipEdge.Right:
                    x = xMax;
                    y = p1.Y + (p2.Y - p1.Y) * (xMax - p1.X) / (p2.X - p1.X);
                    break;
                case ClipEdge.Bottom:
                    y = yMin;
                    x = p1.X + (p2.X - p1.X) * (yMin - p1.Y) / (p2.Y - p1.Y);
                    break;
                case ClipEdge.Top:
                    y = yMax;
                    x = p1.X + (p2.X - p1.X) * (yMax - p1.Y) / (p2.Y - p1.Y);
                    break;
            }

            return new Point(x, y);
        }

        // Recorta el polígono contra un borde específico
        private List<Point> ClipAgainstEdge(List<Point> inputPolygon, ClipEdge edge)
        {
            List<Point> outputPolygon = new List<Point>();

            // Si no hay puntos, devolvemos lista vacía
            if (inputPolygon.Count == 0)
                return outputPolygon;

            // Tomamos el último punto como punto inicial para la primera arista
            Point s = inputPolygon[inputPolygon.Count - 1];

            foreach (Point e in inputPolygon)
            {
                // Si el punto final está dentro del borde actual
                if (IsInside(e, edge))
                {
                    // Si el punto inicial está fuera, añadimos la intersección
                    if (!IsInside(s, edge))
                    {
                        outputPolygon.Add(ComputeIntersection(s, e, edge));
                    }
                    // Añadimos el punto final
                    outputPolygon.Add(e);
                }
                // Si el punto final está fuera pero el inicial está dentro
                else if (IsInside(s, edge))
                {
                    // Añadimos solo la intersección
                    outputPolygon.Add(ComputeIntersection(s, e, edge));
                }

                // Actualizamos el punto inicial para la siguiente arista
                s = e;
            }

            return outputPolygon;
        }

        // Recorta el polígono contra todos los bordes del rectángulo
        public List<Point> ClipPolygon(List<Point> inputPolygon)
        {
            List<Point> outputPolygon = new List<Point>(inputPolygon);

            // Procesamos cada borde del rectángulo
            foreach (ClipEdge edge in Enum.GetValues(typeof(ClipEdge)))
            {
                outputPolygon = ClipAgainstEdge(outputPolygon, edge);
            }

            return outputPolygon;
        }

        // Método para recortar líneas individuales compatible con la interfaz existente
        public bool ClipLine(ref int x1, ref int y1, ref int x2, ref int y2, out int code1, out int code2, out string clipResult)
        {
            // Crear un polígono con dos puntos (una línea)
            List<Point> linePolygon = new List<Point>
            {
                new Point(x1, y1),
                new Point(x2, y2)
            };

            // Recortar la línea como un polígono
            List<Point> clippedPolygon = ClipPolygon(linePolygon);

            // Códigos de región (simulados para compatibilidad)
            code1 = 0;
            code2 = 0;

            // Si hay menos de 2 puntos después del recorte, la línea está fuera
            if (clippedPolygon.Count < 2)
            {
                clipResult = "Rechazo (Sutherland-Hodgman)";
                return false;
            }

            // Actualizar las coordenadas de la línea recortada
            x1 = clippedPolygon[0].X;
            y1 = clippedPolygon[0].Y;
            x2 = clippedPolygon[clippedPolygon.Count - 1].X;
            y2 = clippedPolygon[clippedPolygon.Count - 1].Y;

            clipResult = "Recorte con Sutherland-Hodgman";
            return true;
        }
    }
}