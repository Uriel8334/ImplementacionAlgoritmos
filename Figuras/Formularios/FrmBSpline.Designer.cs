namespace ImplementacionAlgoritmos
{
    partial class FrmBSpline
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblText5 = new System.Windows.Forms.Label();
            this.grpDataGrid = new System.Windows.Forms.GroupBox();
            this.lblText3 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grpBoxFigure = new System.Windows.Forms.GroupBox();
            this.lblText1 = new System.Windows.Forms.Label();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cmbDegree = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.grpDataGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpBoxFigure.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.grpOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.groupBox1.Controls.Add(this.lblText5);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(615, 69);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            // 
            // lblText5
            // 
            this.lblText5.AutoSize = true;
            this.lblText5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblText5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText5.Location = new System.Drawing.Point(3, 19);
            this.lblText5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblText5.Name = "lblText5";
            this.lblText5.Size = new System.Drawing.Size(428, 34);
            this.lblText5.TabIndex = 2;
            this.lblText5.Text = "Aplicacion para animación de trazado de líneas mediante \r\nalgoritmo BSpline.";
            // 
            // grpDataGrid
            // 
            this.grpDataGrid.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.grpDataGrid.Controls.Add(this.lblText3);
            this.grpDataGrid.Controls.Add(this.dataGridView1);
            this.grpDataGrid.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.grpDataGrid.Location = new System.Drawing.Point(633, 106);
            this.grpDataGrid.Name = "grpDataGrid";
            this.grpDataGrid.Size = new System.Drawing.Size(378, 425);
            this.grpDataGrid.TabIndex = 21;
            this.grpDataGrid.TabStop = false;
            // 
            // lblText3
            // 
            this.lblText3.AutoSize = true;
            this.lblText3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblText3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText3.Location = new System.Drawing.Point(3, 19);
            this.lblText3.Name = "lblText3";
            this.lblText3.Size = new System.Drawing.Size(321, 34);
            this.lblText3.TabIndex = 2;
            this.lblText3.Text = "Aquí podrá visualizar los puntos dibujados \r\ncon los pasos realizados";
            this.lblText3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PapayaWhip;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.GridColor = System.Drawing.Color.PapayaWhip;
            this.dataGridView1.Location = new System.Drawing.Point(7, 79);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(365, 359);
            this.dataGridView1.TabIndex = 0;
            // 
            // grpBoxFigure
            // 
            this.grpBoxFigure.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.grpBoxFigure.Controls.Add(this.lblText1);
            this.grpBoxFigure.Controls.Add(this.picCanvas);
            this.grpBoxFigure.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxFigure.Location = new System.Drawing.Point(12, 87);
            this.grpBoxFigure.Name = "grpBoxFigure";
            this.grpBoxFigure.Size = new System.Drawing.Size(615, 444);
            this.grpBoxFigure.TabIndex = 19;
            this.grpBoxFigure.TabStop = false;
            // 
            // lblText1
            // 
            this.lblText1.AutoSize = true;
            this.lblText1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText1.Location = new System.Drawing.Point(3, 19);
            this.lblText1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(477, 34);
            this.lblText1.TabIndex = 1;
            this.lblText1.Text = "1. De click izquierdo dentro del marco para establecer un punto.\r\n2. De click izq" +
    "uierdo nuevamente para establecer otro punto.\r\n";
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.PapayaWhip;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(7, 79);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(602, 359);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            this.picCanvas.Click += new System.EventHandler(this.picCanvas_Click);
            // 
            // grpOptions
            // 
            this.grpOptions.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.grpOptions.Controls.Add(this.label1);
            this.grpOptions.Controls.Add(this.cmbDegree);
            this.grpOptions.Controls.Add(this.button3);
            this.grpOptions.Controls.Add(this.button1);
            this.grpOptions.Controls.Add(this.button2);
            this.grpOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpOptions.Location = new System.Drawing.Point(633, 12);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(378, 88);
            this.grpOptions.TabIndex = 20;
            this.grpOptions.TabStop = false;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(11, 15);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(133, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "Calcular";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(289, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(76, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Salir";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(150, 15);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Resetear gráfico";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // cmbDegree
            // 
            this.cmbDegree.FormattingEnabled = true;
            this.cmbDegree.Location = new System.Drawing.Point(150, 46);
            this.cmbDegree.Name = "cmbDegree";
            this.cmbDegree.Size = new System.Drawing.Size(215, 23);
            this.cmbDegree.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Grado de BSpline";
            // 
            // FrmBSpline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1023, 538);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpDataGrid);
            this.Controls.Add(this.grpBoxFigure);
            this.Controls.Add(this.grpOptions);
            this.Name = "FrmBSpline";
            this.Text = "FrmBSpline";
            this.Load += new System.EventHandler(this.FrmBSpline_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpDataGrid.ResumeLayout(false);
            this.grpDataGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpBoxFigure.ResumeLayout(false);
            this.grpBoxFigure.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.grpOptions.ResumeLayout(false);
            this.grpOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblText5;
        private System.Windows.Forms.GroupBox grpDataGrid;
        private System.Windows.Forms.Label lblText3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox grpBoxFigure;
        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbDegree;
    }
}