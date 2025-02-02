namespace kutuphaneotomasyonuu
{
    partial class yazarlar
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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            KAYDET = new Button();
            SİL = new Button();
            GÜNCELLE = new Button();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(653, 38);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(414, 616);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(112, 153);
            label1.Name = "label1";
            label1.Size = new Size(77, 25);
            label1.TabIndex = 1;
            label1.Text = "yazar id:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(132, 223);
            label2.Name = "label2";
            label2.Size = new Size(57, 25);
            label2.TabIndex = 2;
            label2.Text = "yazar:";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(195, 147);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(152, 31);
            textBox1.TabIndex = 3;
            // 
            // KAYDET
            // 
            KAYDET.Location = new Point(218, 363);
            KAYDET.Name = "KAYDET";
            KAYDET.Size = new Size(160, 72);
            KAYDET.TabIndex = 5;
            KAYDET.Text = "KAYDET";
            KAYDET.UseVisualStyleBackColor = true;
            KAYDET.Click += KAYDET_Click;
            // 
            // SİL
            // 
            SİL.Location = new Point(218, 468);
            SİL.Name = "SİL";
            SİL.Size = new Size(160, 72);
            SİL.TabIndex = 6;
            SİL.Text = "SİL";
            SİL.UseVisualStyleBackColor = true;
            SİL.Click += SİL_Click;
            // 
            // GÜNCELLE
            // 
            GÜNCELLE.Location = new Point(218, 561);
            GÜNCELLE.Name = "GÜNCELLE";
            GÜNCELLE.Size = new Size(160, 72);
            GÜNCELLE.TabIndex = 7;
            GÜNCELLE.Text = "GÜNCELLE";
            GÜNCELLE.UseVisualStyleBackColor = true;
            GÜNCELLE.Click += GÜNCELLE_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(195, 215);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(152, 33);
            comboBox1.TabIndex = 8;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // yazarlar
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(1478, 713);
            Controls.Add(comboBox1);
            Controls.Add(GÜNCELLE);
            Controls.Add(SİL);
            Controls.Add(KAYDET);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "yazarlar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "yazarlar";
            Load += yazarlar_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Button KAYDET;
        private Button SİL;
        private Button GÜNCELLE;
        private ComboBox comboBox1;
    }
}