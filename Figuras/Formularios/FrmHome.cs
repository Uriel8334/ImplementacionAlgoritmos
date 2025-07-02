using System;
using System.Windows.Forms;
using AlgoritmoCohenSutherland;

namespace ImplementacionAlgoritmos
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
            UIStyleUtility.ApplyStylesToForm(this);

        }

        private void DDATrazadoDeLineasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmLines frmLines = FrmLines.GetInstance();
            frmLines.MdiParent = this;
            frmLines.Show();
        }
        private void BresenhamLineasRectasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmBresenhamLines frmBresenham = FrmBresenhamLines.GetInstance();
            frmBresenham.MdiParent = this;
            frmBresenham.Show();

        }
        private void DiscretizacionDeCircunferenciasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmCircle frmCircle = FrmCircle.GetInstance();
            frmCircle.MdiParent = this;
            frmCircle.Show();
        }
        private void AlgoritmoDeRellenoDeFigurasToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            FrmFiguraGeneral frmFiguraGeneral = FrmFiguraGeneral.GetInstance();
            frmFiguraGeneral.MdiParent = this;
            frmFiguraGeneral.Show();
        }

        private void curvaDeBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBezier frmBezier = FrmBezier.GetInstance();
            frmBezier.MdiParent = this;
            frmBezier.Show();
        }

        private void bresenhamParaElipsesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmEllipse frmEllipse = FrmEllipse.GetInstance();
            frmEllipse.MdiParent = this;
            frmEllipse.Show();
        }

        private void bSplineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBSpline frmBSpline = FrmBSpline.GetInstance();
            frmBSpline.MdiParent = this;
            frmBSpline.Show();
        }

        private void algoritmosCohenSutherlandHodgmanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmCohenSutherland frmCohenSutherland = new FrmCohenSutherland();
            frmCohenSutherland.MdiParent = this;
            frmCohenSutherland.Show();
        }
    }
    
}
