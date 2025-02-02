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
using Mysqlx.Crud;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace kutuphaneotomasyonuu
{
    public partial class yazarlar : Form
    {
        private string connectionString = Form1.ConnString;

        public yazarlar()
        {
            InitializeComponent();
        }

        private void yazarlar_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            BindYazarlarData();
            ComboBoxYazarıDoldur();
        }

        private void BindYazarlarData()
        {
            try
            {
                string query = "SELECT * FROM yazarlar";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dtYazarlar = new DataTable();
                    adapter.Fill(dtYazarlar);
                    dataGridView1.DataSource = dtYazarlar;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantısı veya sorgu hatası: " + ex.Message);
            }
        }
        private void ComboBoxYazarıDoldur()
        {
            List<string> yazar = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT yazar FROM yazarlar";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        yazar.Add(reader["yazar"].ToString());
                    }
                    comboBox1.DataSource = yazar;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantısı sırasında bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void KAYDET_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO yazarlar (yazar_id, yazar) VALUES (@yazar_id, @yazar)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@yazar_id", textBox1.Text);
                cmd.Parameters.AddWithValue("@yazar", comboBox1.Text);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Kayıt başarıyla eklendi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ekleme sırasında bir hata oluştu: " + ex.Message);
                }
            }

            BindYazarlarData();
        }

        private void SİL_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM yazarlar WHERE yazar_id = @yazar_id";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@yazar_id", textBox1.Text);

                try
                {
                    connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Kayıt başarıyla silindi.");
                    }
                    else
                    {
                        MessageBox.Show("Silinecek kayıt bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Silme sırasında bir hata oluştu: " + ex.Message);
                }
            }

            BindYazarlarData();
        }

        private void GÜNCELLE_Click(object sender, EventArgs e)
        {
            string query = "UPDATE yazarlar SET yazar = @yazar WHERE yazar_id = @yazar_id";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@yazar_id", textBox1.Text);
                cmd.Parameters.AddWithValue("@yazar", comboBox1.Text);

                try
                {
                    connection.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Kayıt başarıyla güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("Güncellenecek kayıt bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Güncelleme sırasında bir hata oluştu: " + ex.Message);
                }
            }

            BindYazarlarData();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
