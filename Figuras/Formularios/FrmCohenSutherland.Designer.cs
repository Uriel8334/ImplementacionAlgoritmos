namespace AlgoritmoCohenSutherland
{
    partial class FrmCohenSutherland
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.grpGraphicBox = new System.Windows.Forms.GroupBox();
            this.lblText = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpDataBox = new System.Windows.Forms.GroupBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.grpGraphicBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpDataBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.PapayaWhip;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(7, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1110, 270);
            this.dataGridView1.TabIndex = 0;
            // 
            // grpGraphicBox
            // 
            this.grpGraphicBox.Controls.Add(this.lblText);
            this.grpGraphicBox.Controls.Add(this.btnClear);
            this.grpGraphicBox.Controls.Add(this.pictureBox1);
            this.grpGraphicBox.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpGraphicBox.Location = new System.Drawing.Point(13, 13);
            this.grpGraphicBox.Name = "grpGraphicBox";
            this.grpGraphicBox.Size = new System.Drawing.Size(1121, 425);
            this.grpGraphicBox.TabIndex = 1;
            this.grpGraphicBox.TabStop = false;
            this.grpGraphicBox.Text = "Algoritmo de Cohen-Sutherland";
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Location = new System.Drawing.Point(6, 29);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(439, 16);
            this.lblText.TabIndex = 2;
            this.lblText.Text = "Aplicación para la implementación de Cohen-Sutherland ";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(955, 22);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(147, 23);
            this.btnClear.TabIndex = 1;
            this.btnClear.Text = "Limpiar ventanas";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.PapayaWhip;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(6, 58);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1109, 361);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseUp);
            // 
            // grpDataBox
            // 
            this.grpDataBox.Controls.Add(this.dataGridView1);
            this.grpDataBox.Font = new System.Drawing.Font("Courier New", 10F, System.Drawing.FontStyle.Bold);
            this.grpDataBox.Location = new System.Drawing.Point(12, 444);
            this.grpDataBox.Name = "grpDataBox";
            this.grpDataBox.Size = new System.Drawing.Size(1122, 305);
            this.grpDataBox.TabIndex = 2;
            this.grpDataBox.TabStop = false;
            this.grpDataBox.Text = "Tabla de datos";
            // 
            // FrmCohenSutherland
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1145, 761);
            this.Controls.Add(this.grpDataBox);
            this.Controls.Add(this.grpGraphicBox);
            this.Name = "FrmCohenSutherland";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmCohenSutherland";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmCohenSutherland_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.grpGraphicBox.ResumeLayout(false);
            this.grpGraphicBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpDataBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox grpGraphicBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox grpDataBox;
        private System.Windows.Forms.Button btnClear;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label lblText;
    }
}