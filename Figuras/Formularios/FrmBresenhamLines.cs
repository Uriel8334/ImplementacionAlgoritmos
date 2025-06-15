using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ImplementacionAlgoritmos;

namespace ImplementacionAlgoritmos
{
    public partial class FrmBresenhamLines : Form
    {
        private Lines linesObj;
        private static FrmBresenhamLines instance;

        public FrmBresenhamLines()
        {
            InitializeComponent();
            linesObj = new Lines();
        }

        // aplicando singleton
        public static FrmBresenhamLines GetInstance()
        {
            if(instance == null || instance.IsDisposed)
            {
                instance = new FrmBresenhamLines();
            }
            return instance;
        }

        private void picCanvas_MouseClick(object sender, EventArgs e)
        {
            // Manejar el clic para dibujar con Bresenham
            linesObj.HandleClickForBresenham(picCanvas, (MouseEventArgs)e);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Resetear el lienzo
            linesObj.ResetCanvas(picCanvas);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario
            linesObj.CloseForm(this);
        }

        private void FrmBresenhamLines_Load_1(object sender, EventArgs e)
        {
            // Inicializar el lienzo y el DataGridView
            linesObj.InitializeCanvas(picCanvas, dataGridView1);
        }
    }
}