using System;
using System.Windows.Forms;

namespace ImplementacionAlgoritmos
{
    public partial class FrmEllipse : Form
    {
        private Ellipse ellipseObj;
        private static FrmEllipse instance;

        public FrmEllipse()
        {
            InitializeComponent();
            ellipseObj = new Ellipse();
            UIStyleUtility.ApplyStylesToForm(this);
        }

        public static FrmEllipse GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmEllipse();
            }
            return instance;
        }

        private void FrmEllipse_Load(object sender, EventArgs e)
        {
            ellipseObj.InitializeData(txtRadiusX, txtRadiusY, picCanvas, dataGridView1);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            ellipseObj.ReadData(txtRadiusX, txtRadiusY);
            ellipseObj.BresenhamEllipse(picCanvas, dataGridView1);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ellipseObj.InitializeData(txtRadiusX, txtRadiusY, picCanvas, dataGridView1);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            ellipseObj.CloseForm(this);
        }
    }
}