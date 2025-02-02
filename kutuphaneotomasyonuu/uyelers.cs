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

namespace kutuphaneotomasyonuu
{
    public partial class uyelers : Form
    {
        private string connectionString = Form1.ConnString;

        public uyelers()
        {
            InitializeComponent();
        }

        private void uyelers_Load(object sender, EventArgs e)
        {
            BindUyelerData();
        }


        private void BindUyelerData()
        {
            try
            {
                string query = "SELECT * FROM uyeler";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dtUyeler = new DataTable();
                    adapter.Fill(dtUyeler);
                    dataGridView1.DataSource = dtUyeler;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantısı veya sorgu hatası: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void KAYDET_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO uyeler (uye_id, tc_kimlik_no, adisoyadi, cinsiyet, dogum_tarihi, uye_tarihi, email, telefon) VALUES (@uye_id, @tc_kimlik_no, @adisoyadi, @cinsiyet, @dogum_tarihi, @uye_tarihi, @email, @telefon)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@uye_id", textBox1.Text);
                cmd.Parameters.AddWithValue("@tc_kimlik_no", textBox2.Text);
                cmd.Parameters.AddWithValue("@adisoyadi", textBox3.Text);
                cmd.Parameters.AddWithValue("@cinsiyet", textBox5.Text);
                cmd.Parameters.AddWithValue("@dogum_tarihi", textBox6.Text);
                cmd.Parameters.AddWithValue("@uye_tarihi", textBox7.Text);
                cmd.Parameters.AddWithValue("@email", textBox8.Text);
                cmd.Parameters.AddWithValue("@telefon", textBox9.Text);

                try
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Üye başarıyla kaydedildi.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Kaydetme sırasında bir hata oluştu: " + ex.Message);
                }
            }

            BindUyelerData();
        }

        private void SİL_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string uye_id = selectedRow.Cells["uye_id"].Value.ToString();

                string query = "DELETE FROM uyeler WHERE uye_id = @uye_id";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@uye_id", uye_id);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Üye başarıyla silindi.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silme sırasında bir hata oluştu: " + ex.Message);
                    }
                }

                BindUyelerData();
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.");
            }
        }

        private void GÜNCELLE_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string uye_id = selectedRow.Cells["uye_id"].Value.ToString();

                string query = "UPDATE uyeler SET tc_kimlik_no = @tc_kimlik_no, adi = @adi, soyadi = @soyadi, cinsiyet = @cinsiyet, dogum_tarihi = @dogum_tarihi, uye_tarihi = @uye_tarihi, email = @email, telefon = @telefon WHERE uye_id = @uye_id";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@uye_id", uye_id);
                    cmd.Parameters.AddWithValue("@tc_kimlik_no", textBox2.Text);
                    cmd.Parameters.AddWithValue("@adi", textBox3.Text);
                    cmd.Parameters.AddWithValue("@cinsiyet", textBox5.Text);
                    cmd.Parameters.AddWithValue("@dogum_tarihi", textBox6.Text);
                    cmd.Parameters.AddWithValue("@uye_tarihi", textBox7.Text);
                    cmd.Parameters.AddWithValue("@email", textBox8.Text);
                    cmd.Parameters.AddWithValue("@telefon", textBox9.Text);

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Üye başarıyla güncellendi.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Güncelleme sırasında bir hata oluştu: " + ex.Message);
                    }
                    finally
                    {
                        if (connection.State == ConnectionState.Open)
                        {
                            connection.Close();
                        }
                    }
                }

                BindUyelerData();
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.");
            }
        }
    }
}
