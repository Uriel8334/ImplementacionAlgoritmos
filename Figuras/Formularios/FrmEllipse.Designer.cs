namespace ImplementacionAlgoritmos
{
    partial class FrmEllipse
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
            this.grpBoxData = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grpBoxText1 = new System.Windows.Forms.GroupBox();
            this.lblText1 = new System.Windows.Forms.Label();
            this.grbProcess = new System.Windows.Forms.GroupBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.grbInputs = new System.Windows.Forms.GroupBox();
            this.txtRadiusY = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtRadiusX = new System.Windows.Forms.TextBox();
            this.lblRadius = new System.Windows.Forms.Label();
            this.grbCanvas = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.grpBoxData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpBoxText1.SuspendLayout();
            this.grbProcess.SuspendLayout();
            this.grbInputs.SuspendLayout();
            this.grbCanvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBoxData
            // 
            this.grpBoxData.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.grpBoxData.Controls.Add(this.label2);
            this.grpBoxData.Controls.Add(this.dataGridView1);
            this.grpBoxData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.grpBoxData.Location = new System.Drawing.Point(12, 178);
            this.grpBoxData.Name = "grpBoxData";
            this.grpBoxData.Size = new System.Drawing.Size(440, 486);
            this.grpBoxData.TabIndex = 26;
            this.grpBoxData.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(321, 34);
            this.label2.TabIndex = 19;
            this.label2.Text = "Aquí podrá visualizar los puntos dibujados \r\ncon los pasos realizados\r\n";
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PapayaWhip;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.X,
            this.Y});
            this.dataGridView1.Location = new System.Drawing.Point(9, 58);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(423, 420);
            this.dataGridView1.TabIndex = 18;
            // 
            // X
            // 
            this.X.HeaderText = "Punto X";
            this.X.Name = "X";
            // 
            // Y
            // 
            this.Y.HeaderText = "Punto Y";
            this.Y.Name = "Y";
            // 
            // grpBoxText1
            // 
            this.grpBoxText1.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.grpBoxText1.Controls.Add(this.lblText1);
            this.grpBoxText1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBoxText1.Location = new System.Drawing.Point(12, 12);
            this.grpBoxText1.Name = "grpBoxText1";
            this.grpBoxText1.Size = new System.Drawing.Size(440, 160);
            this.grpBoxText1.TabIndex = 25;
            this.grpBoxText1.TabStop = false;
            // 
            // lblText1
            // 
            this.lblText1.AutoSize = true;
            this.lblText1.Location = new System.Drawing.Point(13, 28);
            this.lblText1.Margin = new System.Windows.Forms.Padding(10);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(264, 85);
            this.lblText1.TabIndex = 0;
            this.lblText1.Text = "Aplicacion para trazado de elipses.\r\n\r\n1. Ingrese un radio X\r\n2. Ingrese un radio" +
    " Y\r\n3. Presione el botón calcular";
            // 
            // grbProcess
            // 
            this.grbProcess.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.grbProcess.Controls.Add(this.btnCalculate);
            this.grbProcess.Controls.Add(this.btnExit);
            this.grbProcess.Controls.Add(this.btnReset);
            this.grbProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
            this.grbProcess.Location = new System.Drawing.Point(458, 12);
            this.grbProcess.Name = "grbProcess";
            this.grbProcess.Size = new System.Drawing.Size(256, 160);
            this.grbProcess.TabIndex = 22;
            this.grbProcess.TabStop = false;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(57, 41);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(138, 23);
            this.btnCalculate.TabIndex = 0;
            this.btnCalculate.Text = "Calcular";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(57, 99);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(138, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(57, 70);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(138, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Resetear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // grbInputs
            // 
            this.grbInputs.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.grbInputs.Controls.Add(this.txtRadiusY);
            this.grbInputs.Controls.Add(this.label3);
            this.grbInputs.Controls.Add(this.txtRadiusX);
            this.grbInputs.Controls.Add(this.lblRadius);
            this.grbInputs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbInputs.Location = new System.Drawing.Point(725, 12);
            this.grbInputs.Name = "grbInputs";
            this.grbInputs.Size = new System.Drawing.Size(370, 160);
            this.grbInputs.TabIndex = 21;
            this.grbInputs.TabStop = false;
            // 
            // txtRadiusY
            // 
            this.txtRadiusY.Location = new System.Drawing.Point(102, 99);
            this.txtRadiusY.Name = "txtRadiusY";
            this.txtRadiusY.Size = new System.Drawing.Size(153, 23);
            this.txtRadiusY.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 102);
            this.label3.Margin = new System.Windows.Forms.Padding(10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "Radio Y";
            // 
            // txtRadiusX
            // 
            this.txtRadiusX.Location = new System.Drawing.Point(102, 41);
            this.txtRadiusX.Name = "txtRadiusX";
            this.txtRadiusX.Size = new System.Drawing.Size(153, 23);
            this.txtRadiusX.TabIndex = 2;
            // 
            // lblRadius
            // 
            this.lblRadius.AutoSize = true;
            this.lblRadius.Location = new System.Drawing.Point(13, 44);
            this.lblRadius.Margin = new System.Windows.Forms.Padding(10);
            this.lblRadius.Name = "lblRadius";
            this.lblRadius.Size = new System.Drawing.Size(65, 17);
            this.lblRadius.TabIndex = 0;
            this.lblRadius.Text = "Radio X";
            // 
            // grbCanvas
            // 
            this.grbCanvas.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.grbCanvas.Controls.Add(this.label1);
            this.grbCanvas.Controls.Add(this.picCanvas);
            this.grbCanvas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbCanvas.Location = new System.Drawing.Point(458, 178);
            this.grbCanvas.Name = "grbCanvas";
            this.grbCanvas.Size = new System.Drawing.Size(637, 486);
            this.grbCanvas.TabIndex = 23;
            this.grbCanvas.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(239, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Aquí podrá visualizar el gráfico.";
            // 
            // picCanvas
            // 
            this.picCanvas.BackColor = System.Drawing.Color.PapayaWhip;
            this.picCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picCanvas.Location = new System.Drawing.Point(6, 58);
            this.picCanvas.Name = "picCanvas";
            this.picCanvas.Size = new System.Drawing.Size(625, 422);
            this.picCanvas.TabIndex = 0;
            this.picCanvas.TabStop = false;
            // 
            // FrmEllipse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 672);
            this.Controls.Add(this.grpBoxData);
            this.Controls.Add(this.grpBoxText1);
            this.Controls.Add(this.grbProcess);
            this.Controls.Add(this.grbInputs);
            this.Controls.Add(this.grbCanvas);
            this.Name = "FrmEllipse";
            this.Text = "FrmEllipse";
            this.Load += new System.EventHandler(this.FrmEllipse_Load);
            this.grpBoxData.ResumeLayout(false);
            this.grpBoxData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpBoxText1.ResumeLayout(false);
            this.grpBoxText1.PerformLayout();
            this.grbProcess.ResumeLayout(false);
            this.grbInputs.ResumeLayout(false);
            this.grbInputs.PerformLayout();
            this.grbCanvas.ResumeLayout(false);
            this.grbCanvas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBoxData;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.GroupBox grpBoxText1;
        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.GroupBox grbProcess;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.GroupBox grbInputs;
        private System.Windows.Forms.TextBox txtRadiusX;
        private System.Windows.Forms.Label lblRadius;
        private System.Windows.Forms.GroupBox grbCanvas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.TextBox txtRadiusY;
        private System.Windows.Forms.Label label3;
    }
}