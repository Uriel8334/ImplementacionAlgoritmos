namespace ImplementacionAlgoritmos
{
    partial class FrmHome
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.contextMenuStrip1 = new System.Windows.Forms.MenuStrip();
            this.algoritmosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dDATrazadoDeLineasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bresenhamLineasRectasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.discretizacionDeCircunferenciasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.algoritmoDeRellenoDeFigurasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.BackColor = System.Drawing.Color.MintCream;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.algoritmosToolStripMenuItem});
            this.contextMenuStrip1.Location = new System.Drawing.Point(0, 0);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(983, 24);
            this.contextMenuStrip1.TabIndex = 1;
            this.contextMenuStrip1.Text = "menuStrip1";
            // 
            // algoritmosToolStripMenuItem
            // 
            this.algoritmosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dDATrazadoDeLineasToolStripMenuItem,
            this.bresenhamLineasRectasToolStripMenuItem,
            this.discretizacionDeCircunferenciasToolStripMenuItem,
            this.algoritmoDeRellenoDeFigurasToolStripMenuItem});
            this.algoritmosToolStripMenuItem.Name = "algoritmosToolStripMenuItem";
            this.algoritmosToolStripMenuItem.Size = new System.Drawing.Size(126, 20);
            this.algoritmosToolStripMenuItem.Text = "Tipos de Algoritmos";
            // 
            // dDATrazadoDeLineasToolStripMenuItem
            // 
            this.dDATrazadoDeLineasToolStripMenuItem.Name = "dDATrazadoDeLineasToolStripMenuItem";
            this.dDATrazadoDeLineasToolStripMenuItem.Size = new System.Drawing.Size(425, 22);
            this.dDATrazadoDeLineasToolStripMenuItem.Text = "DDA trazado de líneas entre dos puntos";
            this.dDATrazadoDeLineasToolStripMenuItem.Click += new System.EventHandler(this.DDATrazadoDeLineasToolStripMenuItem_Click_1);
            // 
            // bresenhamLineasRectasToolStripMenuItem
            // 
            this.bresenhamLineasRectasToolStripMenuItem.Name = "bresenhamLineasRectasToolStripMenuItem";
            this.bresenhamLineasRectasToolStripMenuItem.Size = new System.Drawing.Size(425, 22);
            this.bresenhamLineasRectasToolStripMenuItem.Text = "Bresenham para líneas rectas";
            this.bresenhamLineasRectasToolStripMenuItem.Click += new System.EventHandler(this.BresenhamLineasRectasToolStripMenuItem_Click_1);
            // 
            // discretizacionDeCircunferenciasToolStripMenuItem
            // 
            this.discretizacionDeCircunferenciasToolStripMenuItem.Name = "discretizacionDeCircunferenciasToolStripMenuItem";
            this.discretizacionDeCircunferenciasToolStripMenuItem.Size = new System.Drawing.Size(425, 22);
            this.discretizacionDeCircunferenciasToolStripMenuItem.Text = "Discretización de circunferencias (Bresenham para circunferencias)";
            this.discretizacionDeCircunferenciasToolStripMenuItem.Click += new System.EventHandler(this.DiscretizacionDeCircunferenciasToolStripMenuItem_Click_1);
            // 
            // algoritmoDeRellenoDeFigurasToolStripMenuItem
            // 
            this.algoritmoDeRellenoDeFigurasToolStripMenuItem.Name = "algoritmoDeRellenoDeFigurasToolStripMenuItem";
            this.algoritmoDeRellenoDeFigurasToolStripMenuItem.Size = new System.Drawing.Size(425, 22);
            this.algoritmoDeRellenoDeFigurasToolStripMenuItem.Text = "Algoritmo de relleno de figuras (Relleno por inundacion)";
            this.algoritmoDeRellenoDeFigurasToolStripMenuItem.Click += new System.EventHandler(this.AlgoritmoDeRellenoDeFigurasToolStripMenuItem_Click_1);
            // 
            // FrmHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(983, 530);
            this.Controls.Add(this.contextMenuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.contextMenuStrip1;
            this.Name = "FrmHome";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Algoritmos Básicos";
            this.contextMenuStrip1.ResumeLayout(false);
            this.contextMenuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem algoritmosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dDATrazadoDeLineasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bresenhamLineasRectasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem discretizacionDeCircunferenciasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem algoritmoDeRellenoDeFigurasToolStripMenuItem;
    }
}