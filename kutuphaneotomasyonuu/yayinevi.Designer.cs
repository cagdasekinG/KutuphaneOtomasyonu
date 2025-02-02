namespace kutuphaneotomasyonuu
{
    partial class yayinevi
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
            dataGridView1 = new DataGridView();
            KAYDET = new Button();
            SİL = new Button();
            GÜNCELLE = new Button();
            label1 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(649, 55);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(382, 478);
            dataGridView1.TabIndex = 0;
            // 
            // KAYDET
            // 
            KAYDET.Location = new Point(403, 203);
            KAYDET.Name = "KAYDET";
            KAYDET.Size = new Size(153, 82);
            KAYDET.TabIndex = 1;
            KAYDET.Text = "KAYDET";
            KAYDET.UseVisualStyleBackColor = true;
            KAYDET.Click += KAYDET_Click;
            // 
            // SİL
            // 
            SİL.Location = new Point(403, 317);
            SİL.Name = "SİL";
            SİL.Size = new Size(153, 82);
            SİL.TabIndex = 2;
            SİL.Text = "SİL";
            SİL.UseVisualStyleBackColor = true;
            SİL.Click += SİL_Click;
            // 
            // GÜNCELLE
            // 
            GÜNCELLE.Location = new Point(403, 427);
            GÜNCELLE.Name = "GÜNCELLE";
            GÜNCELLE.Size = new Size(153, 82);
            GÜNCELLE.TabIndex = 3;
            GÜNCELLE.Text = "GÜNCELLE";
            GÜNCELLE.UseVisualStyleBackColor = true;
            GÜNCELLE.Click += GÜNCELLE_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 284);
            label1.Name = "label1";
            label1.Size = new Size(101, 25);
            label1.TabIndex = 4;
            label1.Text = "yayinevi_id:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 356);
            label2.Name = "label2";
            label2.Size = new Size(79, 25);
            label2.TabIndex = 5;
            label2.Text = "yayinevi:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(152, 353);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(133, 33);
            comboBox1.TabIndex = 6;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(152, 278);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(133, 31);
            textBox1.TabIndex = 7;
            // 
            // yayinevi
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(1215, 622);
            Controls.Add(textBox1);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(GÜNCELLE);
            Controls.Add(SİL);
            Controls.Add(KAYDET);
            Controls.Add(dataGridView1);
            Name = "yayinevi";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "yayinevi";
            Load += yayinevi_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Button KAYDET;
        private Button SİL;
        private Button GÜNCELLE;
        private Label label1;
        private Label label2;
        private ComboBox comboBox1;
        private TextBox textBox1;
    }
}