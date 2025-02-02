namespace kutuphaneotomasyonuu
{
    partial class oduncalinankitaplar
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBox1 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            KAYDET = new Button();
            SİL = new Button();
            GÜNCELLE = new Button();
            comboBoxUyeler = new ComboBox();
            comboBoxKitaplar = new ComboBox();
            comboBox1 = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(25, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.Size = new Size(1290, 484);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(80, 554);
            label1.Name = "label1";
            label1.Size = new Size(84, 25);
            label1.TabIndex = 1;
            label1.Text = "odunc_id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(124, 591);
            label2.Name = "label2";
            label2.Size = new Size(40, 25);
            label2.TabIndex = 2;
            label2.Text = "üye";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(113, 629);
            label3.Name = "label3";
            label3.Size = new Size(51, 25);
            label3.TabIndex = 3;
            label3.Text = "kitap";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(85, 666);
            label4.Name = "label4";
            label4.Size = new Size(79, 25);
            label4.TabIndex = 4;
            label4.Text = "alis_tarih";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(77, 701);
            label5.Name = "label5";
            label5.Size = new Size(87, 25);
            label5.TabIndex = 5;
            label5.Text = "iade_tarih";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(99, 738);
            label6.Name = "label6";
            label6.Size = new Size(65, 25);
            label6.TabIndex = 6;
            label6.Text = "durum";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(170, 548);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(150, 31);
            textBox1.TabIndex = 7;
            // 
            // textBox4
            // 
            textBox4.Location = new Point(170, 660);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(150, 31);
            textBox4.TabIndex = 10;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(170, 695);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(150, 31);
            textBox5.TabIndex = 11;
            // 
            // KAYDET
            // 
            KAYDET.Location = new Point(441, 527);
            KAYDET.Name = "KAYDET";
            KAYDET.Size = new Size(247, 73);
            KAYDET.TabIndex = 13;
            KAYDET.Text = "KAYDET";
            KAYDET.UseVisualStyleBackColor = true;
            KAYDET.Click += button1_Click;
            // 
            // SİL
            // 
            SİL.Location = new Point(441, 604);
            SİL.Name = "SİL";
            SİL.Size = new Size(247, 73);
            SİL.TabIndex = 14;
            SİL.Text = "SİL";
            SİL.UseVisualStyleBackColor = true;
            SİL.Click += SİL_Click;
            // 
            // GÜNCELLE
            // 
            GÜNCELLE.Location = new Point(441, 683);
            GÜNCELLE.Name = "GÜNCELLE";
            GÜNCELLE.Size = new Size(247, 73);
            GÜNCELLE.TabIndex = 15;
            GÜNCELLE.Text = "GÜNCELLE";
            GÜNCELLE.UseVisualStyleBackColor = true;
            GÜNCELLE.Click += GÜNCELLE_Click;
            // 
            // comboBoxUyeler
            // 
            comboBoxUyeler.FormattingEnabled = true;
            comboBoxUyeler.Location = new Point(170, 588);
            comboBoxUyeler.Name = "comboBoxUyeler";
            comboBoxUyeler.Size = new Size(150, 33);
            comboBoxUyeler.TabIndex = 16;
            comboBoxUyeler.SelectedIndexChanged += comboBoxUyeler_SelectedIndexChanged;
            // 
            // comboBoxKitaplar
            // 
            comboBoxKitaplar.FormattingEnabled = true;
            comboBoxKitaplar.Location = new Point(170, 630);
            comboBoxKitaplar.Name = "comboBoxKitaplar";
            comboBoxKitaplar.Size = new Size(150, 33);
            comboBoxKitaplar.TabIndex = 17;
            comboBoxKitaplar.SelectedIndexChanged += comboBoxKitaplar_SelectedIndexChanged;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(170, 730);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(150, 33);
            comboBox1.TabIndex = 18;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // oduncalinankitaplar
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Wheat;
            ClientSize = new Size(1350, 796);
            Controls.Add(comboBox1);
            Controls.Add(comboBoxKitaplar);
            Controls.Add(comboBoxUyeler);
            Controls.Add(GÜNCELLE);
            Controls.Add(SİL);
            Controls.Add(KAYDET);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox1);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Name = "oduncalinankitaplar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "oduncalinankitaplar";
            Load += oduncalinankitaplar_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox1;
        private TextBox textBox4;
        private TextBox textBox5;
        private Button KAYDET;
        private Button SİL;
        private Button GÜNCELLE;
        private ComboBox comboBoxUyeler;
        private ComboBox comboBoxKitaplar;
        private ComboBox comboBox1;
    }
}