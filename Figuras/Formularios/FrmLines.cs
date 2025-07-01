using System;
using System.Windows.Forms;

namespace ImplementacionAlgoritmos
{
    public partial class FrmLines : Form
    {
        // Instancia de la clase Lines
        private Lines ObjLine;
        // Aplicando Singleton
        private static FrmLines instance;

        // Constructor sin parámetros
        public FrmLines()
        {
            InitializeComponent();

            // Inicializar la clase Lines
            ObjLine = new Lines();

            // Inicializar el canvas
            ObjLine.InitializeCanvas(picCanvas, dataGridView1);

            UIStyleUtility.ApplyStylesToForm(this);

        }

        // Aplicando Singleton
        public static FrmLines GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmLines();
            }
            return instance;
        }

        // Botón para llamar a la función de resetear
        private void btnReset_Click(object sender, EventArgs e)
        {
            // Llamada a la función Reset
            ObjLine.ResetCanvas(picCanvas);
        }

        // Método para salir
        private void btnExit_Click(object sender, EventArgs e)
        {
            ObjLine.CloseForm(this);
        }

        private void picCanvas_Click(object sender, EventArgs e)
        {
            // Convertir el argumento a MouseEventArgs
            MouseEventArgs mouseEvent = (MouseEventArgs)e;

            // Verificar si el botón presionado es el izquierdo
            if (mouseEvent.Button == MouseButtons.Left)
            {
                // Llamada a la función DrawLine de Linea
                ObjLine.DrawLine(picCanvas, mouseEvent);
            }
        }
    }
}