using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImplementacionAlgoritmos
{
    public partial class FrmFiguraGeneral : Form
    {
        private GeneralFigure ObjFiguraGeneral = new GeneralFigure();
        private static FrmFiguraGeneral instance;

        public FrmFiguraGeneral()
        {
            InitializeComponent();
        }

        private void FrmFiguraGeneral_Load(object sender, EventArgs e)
        {
            // Inicializar los datos y el lienzo
            ObjFiguraGeneral.InitializeData(txtNumeroLados, txtRadio, picCanvas, dataGridView1);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Leer los datos de los TextBox
            ObjFiguraGeneral.ReadData(txtNumeroLados, txtRadio);

            // Dibujar la figura animada
            ObjFiguraGeneral.AnimatePlotShape(picCanvas, dataGridView1);
        }

        public static FrmFiguraGeneral GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmFiguraGeneral();
            }
            return instance;
        }

        private void picCanvas_Click(object sender, EventArgs e)
        {
            // Convertir la posición del clic a coordenadas relativas al pictureBox
            MouseEventArgs mouseEvent = e as MouseEventArgs;
            if (mouseEvent != null)
            {
                // Pasar las coordenadas al método de manejo de clics
                ObjFiguraGeneral.HandleCanvasClick(mouseEvent.X, mouseEvent.Y);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            // Reiniciar los datos y el lienzo
            ObjFiguraGeneral.InitializeData(txtNumeroLados, txtRadio, picCanvas, dataGridView1);
        }

        private void btnExit_Click_1(object sender, EventArgs e)
        {
            // Cerrar el formulario
            ObjFiguraGeneral.CloseForm(this);
        }
    }
}