using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace ImplementacionAlgoritmos
{
    public static class UIStyleUtility
    {
        #region Colores del Tema - Olive Green
        // Olive Green como color principal (HEX: #636B2F, RGB: 38.8% red, 42% green, 18.4% blue)
        private static readonly Color OliveGreenPrimary = ColorTranslator.FromHtml("#636B2F");       // Olive Green principal
        private static readonly Color OliveGreenLight = ColorTranslator.FromHtml("#8A9548");         // Olive Green claro
        private static readonly Color OliveGreenDark = ColorTranslator.FromHtml("#4A5122");          // Olive Green oscuro
        private static readonly Color PureWhite = ColorTranslator.FromHtml("#FFFFFF");               // Blanco puro
        private static readonly Color CreamBackground = ColorTranslator.FromHtml("#F5F5DC");         // Fondo crema suave

        // Gradientes que combinan los tonos olive
        private static readonly Color BackgroundGradientTop = CreamBackground;                       // Fondo claro superior
        private static readonly Color BackgroundGradientBottom = ColorTranslator.FromHtml("#E8E8D0"); // Fondo ligeramente más oscuro

        // Texto y elementos destacados
        public static Color AccentColor = OliveGreenDark;                       // Olive Green oscuro para textos principales
        public static Color ButtonForeColor = PureWhite;                       // Blanco para texto de botones
        public static Color ButtonBackColorTop = OliveGreenLight;               // Olive Green claro en la parte superior
        public static Color ButtonBackColorBottom = OliveGreenPrimary;          // Olive Green principal en la parte inferior

        // Bordes que complementan el diseño
        public static Color BorderColor = OliveGreenPrimary;

        // Color base para contenedores
        public static Color ControlBackgroundColor = CreamBackground;

        // Control de elementos ya estilizados
        private static readonly HashSet<Control> StylizedControls = new HashSet<Control>();
        #endregion

        #region Métodos para GroupBox
        public static void ApplyGroupBoxStyle(GroupBox box)
        {
            if (StylizedControls.Contains(box))
                return;

            // Fondo suave que permite destacar elementos
            box.BackColor = ControlBackgroundColor;
            box.ForeColor = AccentColor;
            box.Font = new Font("Segoe UI", 11F, FontStyle.Regular);

            // Evento Paint para degradado suave
            box.Paint += GroupBox_Paint;
            StylizedControls.Add(box);
        }

        public static void GroupBox_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            if (box == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Fondo degradado suave de crema a ligeramente más oscuro
            Rectangle rect = new Rectangle(
                box.ClientRectangle.X,
                box.ClientRectangle.Y,
                box.ClientRectangle.Width,
                box.ClientRectangle.Height
            );

            using (LinearGradientBrush brush = new LinearGradientBrush(
                rect, BackgroundGradientTop, BackgroundGradientBottom, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, rect);
            }

            // Borde redondeado en olive green para definir el área
            int radius = 12;
            Rectangle borderRect = new Rectangle(
                box.ClientRectangle.X + 1,
                box.ClientRectangle.Y + 8,
                box.ClientRectangle.Width - 2,
                box.ClientRectangle.Height - 9);

            using (GraphicsPath path = CreateRoundedRectangle(borderRect, radius))
            using (Pen pen = new Pen(BorderColor, 2))
            {
                // Área de fondo para el título
                using (SolidBrush backgroundBrush = new SolidBrush(BackgroundGradientTop))
                {
                    float textWidth = e.Graphics.MeasureString(box.Text, box.Font).Width;
                    Rectangle textRect = new Rectangle(
                        borderRect.X + 8,
                        borderRect.Y - 9,
                        (int)(textWidth + 8),
                        16);
                    e.Graphics.FillRectangle(backgroundBrush, textRect);
                }
                e.Graphics.DrawPath(pen, path);
            }

            // Texto del título en olive green oscuro para buena legibilidad
            using (SolidBrush textBrush = new SolidBrush(box.ForeColor))
            {
                e.Graphics.DrawString(box.Text, box.Font, textBrush,
                    new PointF(box.ClientRectangle.X + 10, box.ClientRectangle.Y - 1));
            }
        }
        #endregion

        #region Métodos para Button
        public static void ApplyButtonStyle(Button button, Color? foreColor = null)
        {
            if (StylizedControls.Contains(button))
                return;

            // Estilo con olive green que destaca sobre el fondo claro
            button.BackColor = ButtonBackColorBottom;
            button.ForeColor = foreColor ?? ButtonForeColor;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button.FlatAppearance.BorderSize = 0;

            // Aplicar paint personalizado
            button.Paint += Button_Paint;
            StylizedControls.Add(button);
        }

        public static void Button_Paint(object sender, PaintEventArgs e)
        {
            Button button = sender as Button;
            if (button == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Rectángulo redondeado con degradado olive green
            using (GraphicsPath path = CreateRoundedRectangle(
                new Rectangle(2, 2, button.Width - 4, button.Height - 4), 10))
            {
                // Degradado de olive green claro a olive green principal
                using (LinearGradientBrush backgroundBrush = new LinearGradientBrush(
                    button.ClientRectangle,
                    ButtonBackColorTop,
                    ButtonBackColorBottom,
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillPath(backgroundBrush, path);
                }

                // Borde en olive green oscuro para definición
                using (Pen borderPen = new Pen(OliveGreenDark, 1))
                {
                    e.Graphics.DrawPath(borderPen, path);
                }

                // Efecto de brillo sutil en la parte superior
                Rectangle topHighlight = new Rectangle(4, 4, button.Width - 8, button.Height / 3);
                using (LinearGradientBrush highlightBrush = new LinearGradientBrush(
                    topHighlight,
                    Color.FromArgb(30, PureWhite),
                    Color.FromArgb(0, PureWhite),
                    LinearGradientMode.Vertical))
                {
                    using (GraphicsPath highlightPath = CreateRoundedRectangle(topHighlight, 8))
                    {
                        e.Graphics.FillPath(highlightBrush, highlightPath);
                    }
                }

                // Texto en blanco para contraste sobre olive green
                StringFormat format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };

                using (SolidBrush textBrush = new SolidBrush(button.ForeColor))
                {
                    e.Graphics.DrawString(button.Text, button.Font, textBrush, button.ClientRectangle, format);
                }
            }
        }
        #endregion

        #region Métodos para PictureBox
        public static void ApplyPictureBoxStyle(PictureBox pictureBox)
        {
            if (StylizedControls.Contains(pictureBox))
                return;

            // Fondo claro para integración con el tema
            pictureBox.BackColor = CreamBackground;
            pictureBox.BorderStyle = BorderStyle.None;
            pictureBox.Paint += PictureBox_Paint;

            StylizedControls.Add(pictureBox);
        }

        public static void PictureBox_Paint(object sender, PaintEventArgs e)
        {
            PictureBox pb = sender as PictureBox;
            if (pb == null) return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Borde en olive green que define el área
            Rectangle borderRect = new Rectangle(1, 1, pb.Width - 2, pb.Height - 2);
            using (GraphicsPath path = CreateRoundedRectangle(borderRect, 10))
            {
                using (Pen borderPen = new Pen(BorderColor, 2))
                {
                    e.Graphics.DrawPath(borderPen, path);
                }
            }
        }
        #endregion

        #region Métodos para DataGridView
        public static void ApplyDataGridViewStyle(DataGridView dgv)
        {
            if (StylizedControls.Contains(dgv))
                return;

            // Fondo claro del tema
            dgv.BackgroundColor = CreamBackground;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = OliveGreenPrimary;

            // Encabezados en olive green para destacar
            var headerStyle = new DataGridViewCellStyle
            {
                BackColor = OliveGreenPrimary,
                ForeColor = PureWhite,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            dgv.ColumnHeadersDefaultCellStyle = headerStyle;

            // Celdas con fondo claro y texto oscuro
            var cellStyle = new DataGridViewCellStyle
            {
                BackColor = PureWhite,
                ForeColor = OliveGreenDark
            };
            dgv.DefaultCellStyle = cellStyle;

            dgv.RowHeadersDefaultCellStyle.BackColor = OliveGreenLight;
            dgv.RowHeadersDefaultCellStyle.ForeColor = OliveGreenDark;
            dgv.RowsDefaultCellStyle.BackColor = PureWhite;
            dgv.RowsDefaultCellStyle.ForeColor = OliveGreenDark;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = BackgroundGradientBottom;
            dgv.AlternatingRowsDefaultCellStyle.ForeColor = OliveGreenDark;

            StylizedControls.Add(dgv);
        }
        #endregion

        #region Métodos para Form
        public static void ApplyFormStyle(Form form)
        {
            if (StylizedControls.Contains(form))
                return;

            // Fondo claro que permite destacar elementos con olive green
            form.BackColor = CreamBackground;

            ApplyStyleToControls(form.Controls);
            StylizedControls.Add(form);

            form.FormClosed += (sender, e) =>
            {
                var formControls = GetAllChildControls(form);
                foreach (var control in formControls)
                {
                    StylizedControls.Remove(control);
                }
                StylizedControls.Remove(form);
            };
        }

        private static void ApplyStyleToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is GroupBox groupBox)
                {
                    ApplyGroupBoxStyle(groupBox);
                }
                else if (control is Button button)
                {
                    // Botones de Salir con color rojo que contraste
                    if (button.Text.Contains("Salir") || button.Text.Contains("Exit"))
                        ApplyButtonStyle(button, ColorTranslator.FromHtml("#DC143C")); // Rojo crimson
                    else
                        ApplyButtonStyle(button);
                }
                else if (control is PictureBox pictureBox)
                {
                    ApplyPictureBoxStyle(pictureBox);
                }
                else if (control is DataGridView dataGridView)
                {
                    ApplyDataGridViewStyle(dataGridView);
                }
                else if (control is Label label)
                {
                    // Etiquetas en olive green oscuro para buena legibilidad
                    label.ForeColor = AccentColor;
                    label.BackColor = Color.Transparent;
                }

                // Aplicar recursivamente
                if (control.Controls.Count > 0)
                {
                    ApplyStyleToControls(control.Controls);
                }
            }
        }

        private static List<Control> GetAllChildControls(Control control)
        {
            var controls = new List<Control> { control };
            foreach (Control childControl in control.Controls)
            {
                controls.AddRange(GetAllChildControls(childControl));
            }
            return controls;
        }
        #endregion

        #region Utilidades de Dibujo
        public static GraphicsPath CreateRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;
            if (diameter > rect.Width) diameter = rect.Width;
            if (diameter > rect.Height) diameter = rect.Height;
            radius = diameter / 2;

            int x = rect.X;
            int y = rect.Y;
            int width = rect.Width;
            int height = rect.Height;

            path.AddArc(x, y, diameter, diameter, 180, 90);
            path.AddLine(x + radius, y, x + width - radius, y);
            path.AddArc(x + width - diameter, y, diameter, diameter, 270, 90);
            path.AddLine(x + width, y + radius, x + width, y + height - radius);
            path.AddArc(x + width - diameter, y + height - diameter, diameter, diameter, 0, 90);
            path.AddLine(x + width - radius, y + height, x + radius, y + height);
            path.AddArc(x, y + height - diameter, diameter, diameter, 90, 90);
            path.AddLine(x, y + height - radius, x, y + radius);

            path.CloseFigure();
            return path;
        }
        #endregion

        #region Eliminar Manejadores Antiguos
        public static void RemoveOldStyleHandlers(Form form)
        {
            foreach (Control control in GetAllChildControls(form))
            {
                try
                {
                    if (control is GroupBox || control is Button || control is PictureBox)
                    {
                        var eventField = control.GetType().GetField("Paint",
                            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                        if (eventField != null)
                        {
                            eventField.SetValue(control, null);
                        }
                    }
                }
                catch { }
            }
        }

        public static void ApplyStylesToForm(Form form)
        {
            var controlsToRemove = StylizedControls.Where(c => c.FindForm() == form).ToList();
            foreach (var control in controlsToRemove)
                StylizedControls.Remove(control);

            form.BackColor = CreamBackground;
            foreach (Control control in GetAllChildControls(form))
            {
                if (control is GroupBox groupBox)
                {
                    groupBox.BackColor = ControlBackgroundColor;
                    groupBox.ForeColor = AccentColor;
                    groupBox.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
                    groupBox.Paint += GroupBox_Paint;
                }
                else if (control is Button button)
                {
                    button.FlatStyle = FlatStyle.Flat;
                    button.BackColor = ButtonBackColorBottom;
                    button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                    if (button.Text.Contains("Salir") || button.Text.Contains("Exit"))
                        button.ForeColor = ColorTranslator.FromHtml("#DC143C");
                    else
                        button.ForeColor = ButtonForeColor;
                    button.Paint += Button_Paint;
                }
                else if (control is PictureBox pictureBox)
                {
                    pictureBox.BackColor = CreamBackground;
                    pictureBox.BorderStyle = BorderStyle.None;
                    pictureBox.Paint += PictureBox_Paint;
                }
                else if (control is DataGridView dgv)
                {
                    ApplyDataGridViewStyle(dgv);
                }

                StylizedControls.Add(control);
            }

            StylizedControls.Add(form);

            form.FormClosed += (sender, e) => {
                foreach (var c in GetAllChildControls(form))
                    StylizedControls.Remove(c);
                StylizedControls.Remove(form);
            };
        }
        #endregion
    }
}