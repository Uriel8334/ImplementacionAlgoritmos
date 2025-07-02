using System;
using System.Drawing;
using System.Collections.Generic;

namespace AlgoritmoCohenSutherland
{
    public class LinesSutherland
    {
        public int X1 { get; set; }
        public int Y1 { get; set; }
        public int X2 { get; set; }
        public int Y2 { get; set; }
        public Color Color { get; set; }
        public bool IsClipped { get; set; }

        // Nuevas propiedades para mostrar los códigos de región
        public int Code1 { get; set; }
        public int Code2 { get; set; }
        public string ClipResult { get; set; } = "No evaluado";

        public LinesSutherland(int x1, int y1, int x2, int y2, Color color)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
            Color = color;
            IsClipped = false;
        }

        public LinesSutherland Clone()
        {
            return new LinesSutherland(X1, Y1, X2, Y2, Color) { IsClipped = IsClipped };
        }

        // Método para obtener representación binaria del código de región
        public string GetCode1Binary()
        {
            return Convert.ToString(Code1, 2).PadLeft(4, '0');
        }

        public string GetCode2Binary()
        {
            return Convert.ToString(Code2, 2).PadLeft(4, '0');
        }

        // Método para interpretar el código
        public string GetCodeDescription(int code)
        {
            if (code == 0) return "INSIDE";

            List<string> regions = new List<string>();

            // Orden correcto para TOP|BOTTOM|RIGHT|LEFT
            if ((code & 8) != 0) regions.Add("TOP");
            if ((code & 4) != 0) regions.Add("BOTTOM");
            if ((code & 2) != 0) regions.Add("RIGHT");
            if ((code & 1) != 0) regions.Add("LEFT");

            return string.Join("+", regions);
        }
    }
}