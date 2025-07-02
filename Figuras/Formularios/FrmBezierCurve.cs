using System;
using System.Windows.Forms;

namespace ImplementacionAlgoritmos
{
    public partial class FrmBezier : Form
    {
        private BezierCurve bezierObj;
        private static FrmBezier instance;

        public FrmBezier()
        {
            InitializeComponent();
            bezierObj = new BezierCurve();
            UIStyleUtility.ApplyStylesToForm(this);
        }

        public static FrmBezier GetInstance()
        {
            if (instance == null || instance.IsDisposed)
            {
                instance = new FrmBezier();
            }
            return instance;
        }

        private void FrmBezier_Load(object sender, EventArgs e)
        {
            bezierObj.InitializeData(picCanvas, dataGridView1);
        }

        private void picCanvas_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseEvent = e as MouseEventArgs;
            if (mouseEvent != null)
            {
                bezierObj.AddControlPoint(mouseEvent.X, mouseEvent.Y);
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            bezierObj.CalculateBezierCurve();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            bezierObj.ClearCurve();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            bezierObj.CloseForm(this);
        }
    }
}