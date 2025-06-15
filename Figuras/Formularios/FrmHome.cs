using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D; // Para dibujar bordes redondeados

namespace ImplementacionAlgoritmos
{
    public partial class FrmHome : Form
    {
        public FrmHome()
        {
            InitializeComponent();
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
    }
    
}
