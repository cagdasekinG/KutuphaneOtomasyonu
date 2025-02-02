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

namespace kutuphaneotomasyonuu
{
    public partial class yayinevi : Form
    {
        private string connectionString = Form1.ConnString;

        public yayinevi()
        {
            InitializeComponent();
        }

        private void yayinevi_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = -1;
            BindYayineviData();
            ComboBoxYayineviniDoldur();
        }

        private void BindYayineviData()
        {
            try
            {
                string query = "SELECT * FROM yayinevi";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dtYayinevi = new DataTable();
                    adapter.Fill(dtYayinevi);
                    dataGridView1.DataSource = dtYayinevi;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantısı veya sorgu hatası: " + ex.Message);
            }
        }
        private void ComboBoxYayineviniDoldur()
        {
            List<string> yayinevi = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT yayinevi FROM yayinevi";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        yayinevi.Add(reader["yayinevi"].ToString());
                    }
                    comboBox1.DataSource = yayinevi;
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
            string query = "INSERT INTO yayinevi (yayinevi_id, yayinevi) VALUES (@yayinevi_id, @yayinevi)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@yayinevi_id", textBox1.Text);
                cmd.Parameters.AddWithValue("@yayinevi", comboBox1.Text);

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

            BindYayineviData();
        }

        private void SİL_Click(object sender, EventArgs e)
        {
            string query = "DELETE FROM yayinevi WHERE yayinevi_id = @yayinevi_id";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@yayinevi_id", textBox1.Text);

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

            BindYayineviData();
        }


        private void GÜNCELLE_Click(object sender, EventArgs e)
        {
            string query = "UPDATE yayinevi SET yayinevi = @yayinevi WHERE yayinevi_id = @yayinevi_id";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@yayinevi_id", textBox1.Text);
                cmd.Parameters.AddWithValue("@yayinevi", comboBox1.Text);

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

            BindYayineviData();
        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            List<string> originalList = ((List<string>)comboBox1.DataSource).ToList();
            string searchText = comboBox1.Text.ToLower();
            List<string> filteredList = originalList.Where(yayinevi => yayinevi.ToLower().Contains(searchText)).ToList();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}

