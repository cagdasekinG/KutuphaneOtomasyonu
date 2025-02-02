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
    public partial class Form1 : Form
    {
        public static string ConnString { get; } = System.IO.File.ReadAllText("C:\\kutuphaneotomasyonuu\\baglanti.txt");
        MySqlConnection conn = new MySqlConnection(Form1.ConnString);
        MySqlCommand cmd;
        MySqlDataAdapter adapter;
        DataTable dt;
        string connectionstring = Form1.ConnString;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            kitaplistesi kitaplistesi = new kitaplistesi();
            kitaplistesi.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            uyelers uyelers = new uyelers();
            uyelers.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            oduncalinankitaplar oduncalinankitaplar = new oduncalinankitaplar();
            oduncalinankitaplar.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            yazarlar yazarlar = new yazarlar();
            yazarlar.Show();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            yayinevi yayinevi = new yayinevi();
            yayinevi.Show();
        }
    }
}
