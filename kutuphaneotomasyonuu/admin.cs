using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kutuphaneotomasyonuu
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
        }

        private void Admin_Load(object sender, EventArgs e)
        {

        }
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox1.Text;
            string sifre = textBox2.Text;

            if (kullaniciAdi == "admin" && sifre == "123")
            {
                this.Hide();
                Form1 form1 = new Form1();
                form1.Show();
                form1.FormClosed += (s, args) => this.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
            }
        }
    }
}
