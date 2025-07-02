using System;
using System.Windows.Forms;

namespace ImplementacionAlgoritmos
{
    public partial class FrmBSpline : Form
    {
        private BSpline bsplineObj;
        private static FrmBSpline instance;

        public FrmBSpline()
        {
            InitializeComponent();
            bsplineObj = new BSpline();
            UIStyleUtility.ApplyStylesToForm(this);
        }

        public static FrmBSpline GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmBSpline();
            }
            return instance;
        }

        private void FrmBSpline_Load(object sender, EventArgs e)
        {
            bsplineObj.InitializeData(picCanvas, dataGridView1);

            // Configurar ComboBox para el grado
            cmbDegree.Items.AddRange(new object[] { "1", "2", "3", "4", "5" });
            cmbDegree.SelectedIndex = 2; // Grado 3 por defecto
        }

        private void picCanvas_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseEvent = e as MouseEventArgs;
            if (mouseEvent != null)
            {
                bsplineObj.AddControlPoint(mouseEvent.X, mouseEvent.Y);
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            // Establecer el grado seleccionado
            if (cmbDegree.SelectedItem != null)
            {
                int degree = int.Parse(cmbDegree.SelectedItem.ToString());
                bsplineObj.SetDegree(degree);
            }

            bsplineObj.CalculateBSpline();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            bsplineObj.ClearCurve();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            bsplineObj.CloseForm(this);
        }
    }
}