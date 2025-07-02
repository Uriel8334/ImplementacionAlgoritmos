using ImplementacionAlgoritmos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AlgoritmoCohenSutherland
{
    public partial class FrmCohenSutherland : Form
    {
        private CohenSutherlandAlgorithm clipper;
        private List<LinesSutherland> originalLines;
        private List<LinesSutherland> clippedLines;
        private bool isDrawingWindow = true;
        private bool isDrawingLine = false;
        private Point p1;
        private Point clippingWindowP1;
        private Point clippingWindowP2;
        // Añadir al inicio de la clase FrmCohenSutherland:
        private Sutherland_HodgmanAlgorithm clipperSH;
        private bool isDrawingPolygon = false;
        private List<Point> currentPolygon = new List<Point>();
        private List<List<Point>> originalPolygons = new List<List<Point>>();
        private List<List<Point>> clippedPolygons = new List<List<Point>>();

        public FrmCohenSutherland()
        {
            InitializeComponent();
            originalLines = new List<LinesSutherland>();
            clippedLines = new List<LinesSutherland>();
            originalPolygons = new List<List<Point>>();
            clippedPolygons = new List<List<Point>>();
            currentPolygon = new List<Point>();

            SetupDataGridView();

            // Evento para dibujar en el PictureBox
            pictureBox1.Paint += PictureBox1_Paint;
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;
            pictureBox1.MouseUp += PictureBox1_MouseUp;

            // Agregar evento de teclado
            this.KeyPreview = true;
            this.KeyDown += FrmCohenSutherland_KeyDown;
            UIStyleUtility.ApplyStylesToForm(this);

        }

        private void SetupDataGridView()
        {
            // Configurar DataGridView para mostrar los puntos
            dataGridView1.ColumnCount = 9;
            dataGridView1.Columns[0].Name = "Línea";
            dataGridView1.Columns[1].Name = "X1";
            dataGridView1.Columns[2].Name = "Y1";
            dataGridView1.Columns[3].Name = "X2";
            dataGridView1.Columns[4].Name = "Y2";
            dataGridView1.Columns[5].Name = "Código P1";
            dataGridView1.Columns[6].Name = "Código P2";
            dataGridView1.Columns[7].Name = "Resultado";
            dataGridView1.Columns[8].Name = "Estado";

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isDrawingWindow)
            {
                clippingWindowP1 = e.Location;
            }
            else if (e.Button == MouseButtons.Right && !isDrawingLine)
            {
                // Iniciar o continuar el dibujo de un polígono
                if (!isDrawingPolygon)
                {
                    currentPolygon.Clear();
                    isDrawingPolygon = true;
                }
                currentPolygon.Add(e.Location);
                pictureBox1.Invalidate();
            }
            else if (e.Button == MouseButtons.Left && !isDrawingLine && !isDrawingPolygon)
            {
                p1 = e.Location;
                isDrawingLine = true;
            }
        }

        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDrawingWindow && e.Button == MouseButtons.Left)
            {
                clippingWindowP2 = e.Location;
                pictureBox1.Invalidate();
            }
            else if (isDrawingLine && e.Button == MouseButtons.Left)
            {
                pictureBox1.Invalidate();
            }
            else if (isDrawingPolygon)
            {
                // Para mostrar una línea desde el último punto al cursor
                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrawingWindow)
            {
                clippingWindowP2 = e.Location;
                // Inicializar ambos algoritmos con la misma ventana de recorte
                clipper = new CohenSutherlandAlgorithm(
                    clippingWindowP1.X, clippingWindowP1.Y,
                    clippingWindowP2.X, clippingWindowP2.Y);

                clipperSH = new Sutherland_HodgmanAlgorithm(
                    clippingWindowP1.X, clippingWindowP1.Y,
                    clippingWindowP2.X, clippingWindowP2.Y);

                isDrawingWindow = false;
                pictureBox1.Invalidate();
            }
            else if (isDrawingLine && e.Button == MouseButtons.Left)
            {
                // El código existente para dibujar líneas
                LinesSutherland originalLine = new LinesSutherland(p1.X, p1.Y, e.X, e.Y, Color.Blue);
                originalLines.Add(originalLine);

                // Añadir punto original al DataGridView con códigos vacíos
                dataGridView1.Rows.Add(
                    $"Original {originalLines.Count}",
                    originalLine.X1,
                    originalLine.Y1,
                    originalLine.X2,
                    originalLine.Y2,
                    "-",
                    "-",
                    "-",
                    "Original"
                );

                // Si ya hay ventana de recorte, aplicar el algoritmo según el botón del ratón
                if (clipper != null && clipperSH != null)
                {
                    LinesSutherland clippedLine = originalLine.Clone();
                    clippedLine.IsClipped = true;
                    clippedLine.Color = Color.Red;

                    // Crear variables temporales
                    int x1 = clippedLine.X1;
                    int y1 = clippedLine.Y1;
                    int x2 = clippedLine.X2;
                    int y2 = clippedLine.Y2;
                    int code1 = 0, code2 = 0;
                    string clipResult = "";
                    bool lineAccepted = false;
                    string algorithm = "";

                    // Seleccionar algoritmo según el botón del ratón
                    if (e.Button == MouseButtons.Left)
                    {
                        algorithm = "Cohen-Sutherland";
                        lineAccepted = clipper.ClipLine(ref x1, ref y1, ref x2, ref y2, out code1, out code2, out clipResult);
                        clippedLine.Code1 = code1;
                        clippedLine.Code2 = code2;
                    }
                    else if (e.Button == MouseButtons.Right)
                    {
                        algorithm = "Sutherland-Hodgman";
                        lineAccepted = clipperSH.ClipLine(ref x1, ref y1, ref x2, ref y2, out code1, out code2, out clipResult);
                        clippedLine.Code1 = code1;
                        clippedLine.Code2 = code2;
                    }

                    clippedLine.ClipResult = clipResult;

                    if (lineAccepted)
                    {
                        // Actualizar las propiedades con los nuevos valores
                        clippedLine.X1 = x1;
                        clippedLine.Y1 = y1;
                        clippedLine.X2 = x2;
                        clippedLine.Y2 = y2;

                        clippedLines.Add(clippedLine);

                        // Añadir línea recortada al DataGridView
                        dataGridView1.Rows.Add(
                            $"Recortada {clippedLines.Count}",
                            clippedLine.X1,
                            clippedLine.Y1,
                            clippedLine.X2,
                            clippedLine.Y2,
                            $"{clippedLine.GetCode1Binary()} ({clippedLine.GetCodeDescription(clippedLine.Code1)})",
                            $"{clippedLine.GetCode2Binary()} ({clippedLine.GetCodeDescription(clippedLine.Code2)})",
                            clipResult,
                            $"Recortada ({algorithm})"
                        );

                        // Si fue un recorte calculado con Cohen-Sutherland, añadir detalles
                        if (e.Button == MouseButtons.Left && clipResult.StartsWith("Recorte calculado"))
                        {
                            dataGridView1.Rows.Add(
                                $"Detalle",
                                "-",
                                "-",
                                "-",
                                "-",
                                $"Original: {Convert.ToString(code1, 2).PadLeft(4, '0')}",
                                $"Original: {Convert.ToString(code2, 2).PadLeft(4, '0')}",
                                $"Intersecciones calculadas en los bordes",
                                "Info"
                            );
                        }
                    }
                    else
                    {
                        // Añadir información de línea rechazada
                        dataGridView1.Rows.Add(
                            $"Rechazada {clippedLines.Count + 1}",
                            "-",
                            "-",
                            "-",
                            "-",
                            $"{Convert.ToString(code1, 2).PadLeft(4, '0')} ({GetRegionDescription(code1)})",
                            $"{Convert.ToString(code2, 2).PadLeft(4, '0')} ({GetRegionDescription(code2)})",
                            clipResult,
                            $"Rechazada ({algorithm})"
                        );
                    }
                }

                isDrawingLine = false;
                pictureBox1.Invalidate();
            }
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Font codeFont = new Font("Arial", 8);

            // Dibujar ventana de recorte temporal
            if (isDrawingWindow && clippingWindowP2 != Point.Empty)
            {
                g.DrawRectangle(Pens.Black,
                    Math.Min(clippingWindowP1.X, clippingWindowP2.X),
                    Math.Min(clippingWindowP1.Y, clippingWindowP2.Y),
                    Math.Abs(clippingWindowP2.X - clippingWindowP1.X),
                    Math.Abs(clippingWindowP2.Y - clippingWindowP1.Y));
            }

            // Dibujar ventana de recorte definida
            if (!isDrawingWindow && clipper != null)
            {
                Rectangle window = clipper.ClippingWindow;
                g.DrawRectangle(Pens.Black, window);

                // Corregir la visualización de los códigos de región
                // Esquina superior izquierda: 1001 (TOP+LEFT)
                g.DrawString("1001 (TOP+LEFT)", codeFont, Brushes.DarkGray, window.Left - 80, window.Top - 15);

                // Superior: 1000 (TOP)
                g.DrawString("1000 (TOP)", codeFont, Brushes.DarkGray, window.Left + window.Width / 2 - 30, window.Top - 15);

                // Esquina superior derecha: 1010 (TOP+RIGHT)
                g.DrawString("1010 (TOP+RIGHT)", codeFont, Brushes.DarkGray, window.Right + 5, window.Top - 15);

                // Izquierda: 0001 (LEFT)
                g.DrawString("0001 (LEFT)", codeFont, Brushes.DarkGray, window.Left - 60, window.Top + window.Height / 2);

                // Centro: 0000 (INSIDE)
                g.DrawString("0000 (INSIDE)", codeFont, Brushes.DarkGray, window.Left + window.Width / 2 - 30, window.Top + window.Height / 2);

                // Derecha: 0010 (RIGHT)
                g.DrawString("0010 (RIGHT)", codeFont, Brushes.DarkGray, window.Right + 5, window.Top + window.Height / 2);

                // Esquina inferior izquierda: 0101 (BOTTOM+LEFT)
                g.DrawString("0101 (BOTTOM+LEFT)", codeFont, Brushes.DarkGray, window.Left - 85, window.Bottom + 5);

                // Inferior: 0100 (BOTTOM)
                g.DrawString("0100 (BOTTOM)", codeFont, Brushes.DarkGray, window.Left + window.Width / 2 - 35, window.Bottom + 5);

                // Esquina inferior derecha: 0110 (BOTTOM+RIGHT)
                g.DrawString("0110 (BOTTOM+RIGHT)", codeFont, Brushes.DarkGray, window.Right - 40, window.Bottom + 5);

                // Dibujar las regiones con colores suaves para mayor claridad
                using (Brush topLeftBrush = new SolidBrush(Color.FromArgb(30, 255, 0, 0)))
                using (Brush topBrush = new SolidBrush(Color.FromArgb(30, 0, 255, 0)))
                using (Brush topRightBrush = new SolidBrush(Color.FromArgb(30, 0, 0, 255)))
                using (Brush leftBrush = new SolidBrush(Color.FromArgb(30, 255, 255, 0)))
                using (Brush rightBrush = new SolidBrush(Color.FromArgb(30, 0, 255, 255)))
                using (Brush bottomLeftBrush = new SolidBrush(Color.FromArgb(30, 255, 0, 255)))
                using (Brush bottomBrush = new SolidBrush(Color.FromArgb(30, 128, 128, 128)))
                using (Brush bottomRightBrush = new SolidBrush(Color.FromArgb(30, 255, 128, 0)))
                {
                    // Dibujar regiones fuera de la ventana
                    // TOP-LEFT
                    g.FillRectangle(topLeftBrush, 0, 0, window.Left, window.Top);
                    // TOP
                    g.FillRectangle(topBrush, window.Left, 0, window.Width, window.Top);
                    // TOP-RIGHT
                    g.FillRectangle(topRightBrush, window.Right, 0, pictureBox1.Width - window.Right, window.Top);
                    // LEFT
                    g.FillRectangle(leftBrush, 0, window.Top, window.Left, window.Height);
                    // RIGHT
                    g.FillRectangle(rightBrush, window.Right, window.Top, pictureBox1.Width - window.Right, window.Height);
                    // BOTTOM-LEFT
                    g.FillRectangle(bottomLeftBrush, 0, window.Bottom, window.Left, pictureBox1.Height - window.Bottom);
                    // BOTTOM
                    g.FillRectangle(bottomBrush, window.Left, window.Bottom, window.Width, pictureBox1.Height - window.Bottom);
                    // BOTTOM-RIGHT
                    g.FillRectangle(bottomRightBrush, window.Right, window.Bottom, pictureBox1.Width - window.Right, pictureBox1.Height - window.Bottom);
                }
            }

            // Dibujar línea temporal
            if (isDrawingLine)
            {
                g.DrawLine(Pens.Blue, p1, pictureBox1.PointToClient(MousePosition));
            }

            // Dibujar todas las líneas originales
            foreach (LinesSutherland line in originalLines)
            {
                g.DrawLine(new Pen(line.Color), line.X1, line.Y1, line.X2, line.Y2);

                // Dibujar puntos en los extremos para mayor claridad
                g.FillEllipse(Brushes.Blue, line.X1 - 3, line.Y1 - 3, 6, 6);
                g.FillEllipse(Brushes.Blue, line.X2 - 3, line.Y2 - 3, 6, 6);
            }

            // Dibujar todas las líneas recortadas
            foreach (LinesSutherland line in clippedLines)
            {
                g.DrawLine(new Pen(line.Color, 2), line.X1, line.Y1, line.X2, line.Y2);

                // Dibujar puntos en los extremos recortados
                g.FillEllipse(Brushes.Red, line.X1 - 4, line.Y1 - 4, 8, 8);
                g.FillEllipse(Brushes.Red, line.X2 - 4, line.Y2 - 4, 8, 8);

                // Mostrar códigos de región junto a los puntos
                g.DrawString(line.GetCode1Binary(), codeFont, Brushes.Red, line.X1 + 5, line.Y1 - 15);
                g.DrawString(line.GetCode2Binary(), codeFont, Brushes.Red, line.X2 + 5, line.Y2 - 15);
            }

            // Dibujar polígono en construcción
            if (isDrawingPolygon && currentPolygon.Count > 0)
            {
                // Dibujar las líneas conectadas del polígono
                for (int i = 0; i < currentPolygon.Count - 1; i++)
                {
                    g.DrawLine(Pens.Green, currentPolygon[i], currentPolygon[i + 1]);
                    g.FillEllipse(Brushes.Green, currentPolygon[i].X - 3, currentPolygon[i].Y - 3, 6, 6);
                }

                // Dibujar el último punto
                g.FillEllipse(Brushes.Green, currentPolygon[currentPolygon.Count - 1].X - 3,
                             currentPolygon[currentPolygon.Count - 1].Y - 3, 6, 6);

                // Dibujar línea desde el último punto al cursor
                g.DrawLine(Pens.Green, currentPolygon[currentPolygon.Count - 1],
                          pictureBox1.PointToClient(MousePosition));

                // Si hay más de 2 puntos, dibujar una línea de cierre sugerida (punteada)
                if (currentPolygon.Count > 2)
                {
                    Pen dashedPen = new Pen(Color.Green, 1);
                    dashedPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
                    g.DrawLine(dashedPen, currentPolygon[currentPolygon.Count - 1], currentPolygon[0]);
                    dashedPen.Dispose();
                }
            }

            // Dibujar todos los polígonos originales
            foreach (var polygon in originalPolygons)
            {
                if (polygon.Count > 0)
                {
                    for (int i = 0; i < polygon.Count; i++)
                    {
                        g.FillEllipse(Brushes.Blue, polygon[i].X - 3, polygon[i].Y - 3, 6, 6);
                        g.DrawLine(Pens.Blue, polygon[i], polygon[(i + 1) % polygon.Count]);
                    }
                }
            }

            // Dibujar todos los polígonos recortados
            foreach (var polygon in clippedPolygons)
            {
                if (polygon.Count > 0)
                {
                    Pen redPen = new Pen(Color.Red, 2);
                    for (int i = 0; i < polygon.Count; i++)
                    {
                        g.FillEllipse(Brushes.Red, polygon[i].X - 4, polygon[i].Y - 4, 8, 8);
                        g.DrawLine(redPen, polygon[i], polygon[(i + 1) % polygon.Count]);
                    }
                    redPen.Dispose();
                }
            }

            // Instrucciones
            string instructions;
            if (isDrawingWindow)
                instructions = "Haz clic y arrastra para definir la ventana de recorte";
            else if (isDrawingPolygon)
                instructions = "Clic derecho: añadir vértice | Enter: finalizar polígono | Esc: cancelar";
            else
                instructions = "Clic izquierdo: Cohen-Sutherland (líneas) | Clic derecho: Sutherland-Hodgman (polígonos)";

            g.DrawString(instructions, new Font("Arial", 10), Brushes.Black, 10, 10);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Limpiar las líneas y la ventana de recorte
            originalLines.Clear();
            clippedLines.Clear();
            originalPolygons.Clear();
            clippedPolygons.Clear();
            currentPolygon.Clear();
            clipper = null;
            clipperSH = null;
            isDrawingWindow = true;
            isDrawingPolygon = false;
            isDrawingLine = false;
            dataGridView1.Rows.Clear();
            pictureBox1.Invalidate();
        }

        // Método auxiliar para obtener la descripción de la región sin necesidad de crear un objeto Lines
        private string GetRegionDescription(int code)
        {
            if (code == 0) return "INSIDE";

            List<string> regions = new List<string>();

            if ((code & 8) != 0) regions.Add("TOP");
            if ((code & 4) != 0) regions.Add("BOTTOM");
            if ((code & 2) != 0) regions.Add("RIGHT");
            if ((code & 1) != 0) regions.Add("LEFT");

            return string.Join("+", regions);
        }
        private void FinishPolygon()
        {
            if (currentPolygon.Count < 3)
                return;

            List<Point> originalPolygon = new List<Point>(currentPolygon);
            originalPolygons.Add(originalPolygon);

            // Añadir información del polígono original al DataGridView
            dataGridView1.Rows.Add(
                $"Polígono {originalPolygons.Count}",
                "Múltiples",
                "puntos",
                originalPolygon.Count.ToString(),
                "vértices",
                "-",
                "-",
                "-",
                "Polígono Original"
            );

            // Si ya hay ventana de recorte, aplicar el algoritmo de Sutherland-Hodgman
            if (clipperSH != null)
            {
                // Recortar el polígono
                List<Point> clippedPolygon = clipperSH.ClipPolygon(originalPolygon);

                if (clippedPolygon.Count > 2)
                {
                    clippedPolygons.Add(clippedPolygon);

                    // Añadir polígono recortado al DataGridView
                    dataGridView1.Rows.Add(
                        $"Recortado {clippedPolygons.Count}",
                        "Múltiples",
                        "puntos",
                        clippedPolygon.Count.ToString(),
                        "vértices",
                        "-",
                        "-",
                        "Recorte con Sutherland-Hodgman",
                        "Polígono Recortado"
                    );
                }
                else
                {
                    // El polígono está completamente fuera
                    dataGridView1.Rows.Add(
                        $"Rechazado",
                        "-",
                        "-",
                        "-",
                        "-",
                        "-",
                        "-",
                        "Polígono completamente fuera",
                        "Rechazado"
                    );
                }
            }

            // Limpiar el polígono actual pero mantener el modo de dibujo de polígonos
            currentPolygon.Clear();
            // NO desactivar el modo polígono para permitir dibujar otro inmediatamente
            // isDrawingPolygon = false;  
            pictureBox1.Invalidate();
        }
        private void FrmCohenSutherland_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && isDrawingPolygon && currentPolygon.Count > 2)
            {
                // Finalizar el polígono
                FinishPolygon();
            }
            else if (e.KeyCode == Keys.Escape && isDrawingPolygon)
            {
                // Cancelar el polígono actual
                currentPolygon.Clear();
                isDrawingPolygon = false;
                pictureBox1.Invalidate();
            }
        }

    }
}
