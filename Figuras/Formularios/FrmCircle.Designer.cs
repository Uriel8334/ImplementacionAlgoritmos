namespace ImplementacionAlgoritmos
{
    partial class FrmCircle
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
            this.components = new System.ComponentModel.Container();
            this.grbOutputs = new System.Windows.Forms.GroupBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.txtPerimeter = new System.Windows.Forms.TextBox();
            this.lblArea = new System.Windows.Forms.Label();
            this.lblPerimeter = new System.Windows.Forms.Label();
            this.grbProcess = new System.Windows.Forms.GroupBox();
            this.btnAlgorithPMedio = new System.Windows.Forms.Button();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.btnAlgorithDis = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.grbInputs = new System.Windows.Forms.GroupBox();
            this.txtRadius = new System.Windows.Forms.TextBox();
            this.lblRadius = new System.Windows.Forms.Label();
            this.grbCanvas = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picCanvas = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grpBoxText1 = new System.Windows.Forms.GroupBox();
            this.lblText1 = new System.Windows.Forms.Label();
            this.grpBoxData = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grbOutputs.SuspendLayout();
            this.grbProcess.SuspendLayout();
            this.grbInputs.SuspendLayout();
            this.grbCanvas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpBoxText1.SuspendLayout();
            this.grpBoxData.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbOutputs
            // 
            this.grbOutputs.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.grbOutputs.Controls.Add(this.txtArea);
            this.grbOutputs.Controls.Add(this.txtPerimeter);
            this.grbOutputs.Controls.Add(this.lblArea);
            this.grbOutputs.Controls.Add(this.lblPerimeter);
            this.grbOutputs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbOutputs.Location = new System.Drawing.Point(725, 82);
            this.grbOutputs.Name = "grbOutputs";
            this.grbOutputs.Size = new System.Drawing.Size(370, 90);
            this.grbOutputs.TabIndex = 17;
            this.grbOutputs.TabStop = false;
            // 
            // txtArea
            // 
            this.txtArea.Enabled = false;
            this.txtArea.Location = new System.Drawing.Point(102, 57);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(198, 23);
            this.txtArea.TabIndex = 3;
            // 
            // txtPerimeter
            // 
            this.txtPerimeter.Enabled = false;
            this.txtPerimeter.Location = new System.Drawing.Point(102, 16);
            this.txtPerimeter.Name = "txtPerimeter";
            this.txtPerimeter.Size = new System.Drawing.Size(198, 23);
            this.txtPerimeter.TabIndex = 2;
            // 
            // lblArea
            // 
            this.lblArea.AutoSize = true;
            this.lblArea.Location = new System.Drawing.Point(13, 59);
            this.lblArea.Name = "lblArea";
            this.lblArea.Size = new System.Drawing.Size(47, 17);
            this.lblArea.TabIndex = 1;
            this.lblArea.Text = "Área:";
            // 
            // lblPerimeter
            // 
            this.lblPerimeter.AutoSize = true;
            this.lblPerimeter.Location = new System.Drawing.Point(13, 22);
            this.lblPerimeter.Name = "lblPerimeter";
            this.lblPerimeter.Size = new System.Drawing.Size(83, 17);
            this.lblPerimeter.TabIndex = 0;
            this.lblPerimeter.Text = "Perímetro:";
            // 
            // grbProcess
            // 
            this.grbProcess.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.grbProcess.Controls.Add(this.btnAlgorithPMedio);
            this.grbProcess.Controls.Add(this.btnCalculate);
            this.grbProcess.Controls.Add(this.btnAlgorithDis);
            this.grbProcess.Controls.Add(this.btnExit);
            this.grbProcess.Controls.Add(this.btnReset);
            this.grbProcess.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold);
            this.grbProcess.Location = new System.Drawing.Point(458, 12);
            this.grbProcess.Name = "grbProcess";
            this.grbProcess.Size = new System.Drawing.Size(256, 160);
            this.grbProcess.TabIndex = 15;
            this.grbProcess.TabStop = false;
            // 
            // btnAlgorithPMedio
            // 
            this.btnAlgorithPMedio.Location = new System.Drawing.Point(5, 101);
            this.btnAlgorithPMedio.Name = "btnAlgorithPMedio";
            this.btnAlgorithPMedio.Size = new System.Drawing.Size(237, 25);
            this.btnAlgorithPMedio.TabIndex = 4;
            this.btnAlgorithPMedio.Text = "Algoritmo Punto Medio";
            this.btnAlgorithPMedio.UseVisualStyleBackColor = true;
            this.btnAlgorithPMedio.Click += new System.EventHandler(this.btnAlgorithPMedio_Click);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(6, 28);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(75, 23);
            this.btnCalculate.TabIndex = 0;
            this.btnCalculate.Text = "Calcular";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // btnAlgorithDis
            // 
            this.btnAlgorithDis.Location = new System.Drawing.Point(5, 70);
            this.btnAlgorithDis.Name = "btnAlgorithDis";
            this.btnAlgorithDis.Size = new System.Drawing.Size(237, 25);
            this.btnAlgorithDis.TabIndex = 3;
            this.btnAlgorithDis.Text = "Algoritmo discretizacion";
            this.btnAlgorithDis.UseVisualStyleBackColor = true;
            this.btnAlgorithDis.Click += new System.EventHandler(this.btnAlgorithDis_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(168, 28);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 2;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(87, 28);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 1;
            this.btnReset.Text = "Resetear";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // grbInputs
            // 
            this.grbInputs.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.grbInputs.Controls.Add(this.txtRadius);
            this.grbInputs.Controls.Add(this.lblRadius);
            this.grbInputs.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbInputs.Location = new System.Drawing.Point(725, 12);
            this.grbInputs.Name = "grbInputs";
            this.grbInputs.Size = new System.Drawing.Size(370, 64);
            this.grbInputs.TabIndex = 14;
            this.grbInputs.TabStop = false;
            // 
            // txtRadius
            // 
            this.txtRadius.Location = new System.Drawing.Point(105, 25);
            this.txtRadius.Name = "txtRadius";
            this.txtRadius.Size = new System.Drawing.Size(195, 23);
            this.txtRadius.TabIndex = 2;
            // 
            // lblRadius
            // 
            this.lblRadius.AutoSize = true;
            this.lblRadius.Location = new System.Drawing.Point(27, 29);
            this.lblRadius.Margin = new System.Windows.Forms.Padding(10);
            this.lblRadius.Name = "lblRadius";
            this.lblRadius.Size = new System.Drawing.Size(55, 17);
            this.lblRadius.TabIndex = 0;
            this.lblRadius.Text = "Radio:";
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
            this.grbCanvas.TabIndex = 16;
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
            this.picCanvas.Click += new System.EventHandler(this.picCanvas_Click);
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
            this.grpBoxText1.TabIndex = 19;
            this.grpBoxText1.TabStop = false;
            // 
            // lblText1
            // 
            this.lblText1.AutoSize = true;
            this.lblText1.Location = new System.Drawing.Point(13, 28);
            this.lblText1.Margin = new System.Windows.Forms.Padding(10);
            this.lblText1.Name = "lblText1";
            this.lblText1.Size = new System.Drawing.Size(410, 85);
            this.lblText1.TabIndex = 0;
            this.lblText1.Text = "Aplicacion para trazado de círculos.\r\n\r\n1. Ingrese un radio\r\n2. Por Algoritmo de " +
    "discretización, presione el botón ->\r\n3. Por Algoritmo de Punto Medio, presione " +
    "el botón ->";
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
            this.grpBoxData.TabIndex = 20;
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
            // FrmCircle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1107, 676);
            this.Controls.Add(this.grpBoxData);
            this.Controls.Add(this.grpBoxText1);
            this.Controls.Add(this.grbOutputs);
            this.Controls.Add(this.grbProcess);
            this.Controls.Add(this.grbInputs);
            this.Controls.Add(this.grbCanvas);
            this.Name = "FrmCircle";
            this.Text = "FrmCircle";
            this.Load += new System.EventHandler(this.FrmCircle_Load);
            this.grbOutputs.ResumeLayout(false);
            this.grbOutputs.PerformLayout();
            this.grbProcess.ResumeLayout(false);
            this.grbInputs.ResumeLayout(false);
            this.grbInputs.PerformLayout();
            this.grbCanvas.ResumeLayout(false);
            this.grbCanvas.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCanvas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpBoxText1.ResumeLayout(false);
            this.grpBoxText1.PerformLayout();
            this.grpBoxData.ResumeLayout(false);
            this.grpBoxData.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbOutputs;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.TextBox txtPerimeter;
        private System.Windows.Forms.Label lblArea;
        private System.Windows.Forms.Label lblPerimeter;
        private System.Windows.Forms.GroupBox grbProcess;
        private System.Windows.Forms.Button btnAlgorithPMedio;
        private System.Windows.Forms.Button btnAlgorithDis;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.GroupBox grbInputs;
        private System.Windows.Forms.TextBox txtRadius;
        private System.Windows.Forms.Label lblRadius;
        private System.Windows.Forms.GroupBox grbCanvas;
        private System.Windows.Forms.PictureBox picCanvas;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox grpBoxText1;
        private System.Windows.Forms.Label lblText1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpBoxData;
        private System.Windows.Forms.Label label2;
    }
}