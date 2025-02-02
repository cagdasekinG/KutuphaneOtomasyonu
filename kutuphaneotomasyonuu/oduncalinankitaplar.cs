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
    public partial class oduncalinankitaplar : Form
    {
        private string connectionString = Form1.ConnString + ";Allow Zero Datetime=True;";

        public oduncalinankitaplar()
        {
            InitializeComponent();
        }

        private void oduncalinankitaplar_Load(object sender, EventArgs e)
        {
            comboBoxUyeler.SelectedIndex = -1;
            comboBoxKitaplar.SelectedIndex = -1;
            BindoduncalinankitaplarData();
            ComboBoxUyeleriDoldur();
            ComboBoxKitaplariDoldur();
            comboBoxKitaplar.TextChanged += new EventHandler(comboBoxKitaplar_TextChanged);
            ComboBoxKitaplariDoldur();
            comboBox1.Items.Add("Alındı");
            comboBox1.Items.Add("İade Edildi");

        }
        private void ComboBoxUyeleriDoldur()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT adisoyadi FROM uyeler";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    List<string> uyeler = new List<string>();
                    while (reader.Read())
                    {
                        uyeler.Add(reader["adisoyadi"].ToString());
                    }
                    comboBoxUyeler.DataSource = uyeler;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı bağlantısı sırasında bir hata oluştu: " + ex.Message);
                }
                finally
                {
                }
            }
        }
        private int Getkitap_idByName(string kitapAdi)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT kitap_id FROM kitaplar WHERE kitap_adi = @kitapAdi";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kitapAdi", kitapAdi);
                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Kitap bulunamadı.");
                        return -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                    return -1;
                }
            }
        }
        private int GetUyeIdByName(string adisoyadi)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT uye_id FROM uyeler WHERE adisoyadi = @adisoyadi";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@adisoyadi", adisoyadi);
                try
                {
                    conn.Open();
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        MessageBox.Show("Üye bulunamadı.");
                        return -1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanı hatası: " + ex.Message);
                    return -1;
                }
            }
        }




        private void ComboBoxKitaplariDoldur()
        {
            List<string> kitaplarListesi = new List<string>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT kitap_adi FROM kitaplar";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        kitaplarListesi.Add(reader["kitap_adi"].ToString());
                    }
                    comboBoxKitaplar.DataSource = kitaplarListesi;
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


        private void BindoduncalinankitaplarData()
        {
            try
            {
                string query = "SELECT * FROM oduncalinankitaplar";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlDataAdapter adapter = new MySqlDataAdapter(query, connection);
                    DataTable dtoduncalinankitaplar = new DataTable();
                    adapter.Fill(dtoduncalinankitaplar);
                    dataGridView1.DataSource = dtoduncalinankitaplar;
                    dataGridView1.Columns["alis_tarihi"].DefaultCellStyle.Format = "dd.MM.yyyy";
                    dataGridView1.Columns["iade_tarihi"].DefaultCellStyle.Format = "dd.MM.yyyy";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantısı veya sorgu hatası: " + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kitapAdi = comboBoxKitaplar.Text;
            int kitap_id = Getkitap_idByName(kitapAdi);
            string queryOduncVerme = "INSERT INTO oduncalinankitaplar (odunc_id, adisoyadi, kitap_adi, alis_tarihi, iade_tarihi, durum) VALUES (@odunc_id, @adisoyadi, @kitap_adi, @alis_tarihi, @iade_tarihi, @durum)";
            string queryStokAzalt = "UPDATE kitaplar SET stok_sayisi = stok_sayisi - 1 WHERE kitap_id = @kitap_id AND stok_sayisi > 0";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                MySqlCommand cmdOduncVerme = new MySqlCommand(queryOduncVerme, connection);
                MySqlCommand cmdStokAzalt = new MySqlCommand(queryStokAzalt, connection);
                cmdOduncVerme.Parameters.AddWithValue("@odunc_id", textBox1.Text);
                cmdOduncVerme.Parameters.AddWithValue("@adisoyadi", comboBoxUyeler.Text);
                cmdOduncVerme.Parameters.AddWithValue("@kitap_adi", comboBoxKitaplar.Text);
                cmdOduncVerme.Parameters.AddWithValue("@alis_tarihi", textBox4.Text);
                cmdOduncVerme.Parameters.AddWithValue("@iade_tarihi", textBox5.Text);
                cmdOduncVerme.Parameters.AddWithValue("@durum", comboBox1.Text);
                cmdStokAzalt.Parameters.AddWithValue("@kitap_id", kitap_id);

                try
                {
                    connection.Open();
                    int resultStokAzalt = cmdStokAzalt.ExecuteNonQuery();
                    if (resultStokAzalt > 0)
                    {
                        cmdOduncVerme.ExecuteNonQuery();
                        MessageBox.Show("Kitap ödünç verildi ve stok güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("Stokta yeterli kitap yok.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("İşlem sırasında bir hata oluştu: " + ex.Message);
                }
            }

            BindoduncalinankitaplarData();
        }

        private void SİL_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string odunc_id = selectedRow.Cells["odunc_id"].Value.ToString();
                string kitapAdi = selectedRow.Cells["kitap_adi"].Value.ToString();
                int kitap_id = Getkitap_idByName(kitapAdi);
                string querySilme = "DELETE FROM oduncalinankitaplar WHERE odunc_id = @odunc_id";
                string queryStokArtir = "UPDATE kitaplar SET stok_sayisi = stok_sayisi + 1 WHERE kitap_id = @kitap_id";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmdSilme = new MySqlCommand(querySilme, connection);
                    MySqlCommand cmdStokArtir = new MySqlCommand(queryStokArtir, connection);
                    cmdSilme.Parameters.AddWithValue("@odunc_id", odunc_id);
                    cmdStokArtir.Parameters.AddWithValue("@kitap_id", kitap_id);

                    try
                    {
                        connection.Open();
                        int resultSilme = cmdSilme.ExecuteNonQuery();
                        if (resultSilme > 0)
                        {
                            cmdStokArtir.ExecuteNonQuery();
                            MessageBox.Show("Kitap iade alındı ve stok güncellendi.");
                        }
                        else
                        {
                            MessageBox.Show("Silinecek kayıt bulunamadı.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Silme işlemi sırasında bir hata oluştu: " + ex.Message);
                    }
                }

                BindoduncalinankitaplarData();
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
                string odunc_id = selectedRow.Cells["odunc_id"].Value.ToString();
                int kitap_id = Getkitap_idByName(comboBoxKitaplar.Text);

                string query = "UPDATE oduncalinankitaplar SET adisoyadi = @adisoyadi, kitap_adi = @kitap_adi, alis_tarihi = @alis_tarihi, iade_tarihi = @iade_tarihi, durum = @durum WHERE odunc_id = @odunc_id";
                string stokQuery = "";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@odunc_id", odunc_id);
                    cmd.Parameters.AddWithValue("@adisoyadi", comboBoxUyeler.Text);
                    cmd.Parameters.AddWithValue("@kitap_adi", comboBoxKitaplar.Text);
                    cmd.Parameters.AddWithValue("@alis_tarihi", DateTime.Parse(textBox4.Text));
                    cmd.Parameters.AddWithValue("@iade_tarihi", DateTime.Parse(textBox5.Text));
                    cmd.Parameters.AddWithValue("@durum", comboBox1.Text);

                    if (comboBox1.Text == "Alındı")
                    {
                        stokQuery = "UPDATE kitaplar SET stok_sayisi = stok_sayisi - 1 WHERE kitap_id = @kitap_id AND stok_sayisi > 0";
                    }
                    else if (comboBox1.Text == "İade Edildi")
                    {
                        stokQuery = "UPDATE kitaplar SET stok_sayisi = stok_sayisi + 1 WHERE kitap_id = @kitap_id";
                    }

                    try
                    {
                        connection.Open();
                        cmd.ExecuteNonQuery();

                        if (!string.IsNullOrEmpty(stokQuery))
                        {
                            MySqlCommand stokCmd = new MySqlCommand(stokQuery, connection);
                            stokCmd.Parameters.AddWithValue("@kitap_id", kitap_id);
                            stokCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Kayıt başarıyla güncellendi ve stok ayarlandı.");
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

                BindoduncalinankitaplarData();
            }
            else
            {
                MessageBox.Show("Lütfen güncellenecek bir satır seçin.");
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBoxUyeler_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> originalList = ((List<string>)comboBoxUyeler.DataSource).ToList();
            string searchText = comboBoxKitaplar.Text.ToLower();
            List<string> filteredList = originalList.Where(uye => uye.ToLower().Contains(searchText)).ToList();

        }

        private void comboBoxKitaplar_TextChanged(object sender, EventArgs e)
        {
            List<string> originalList = ((List<string>)comboBoxKitaplar.DataSource).ToList();
            string searchText = comboBoxKitaplar.Text.ToLower();
            List<string> filteredList = originalList.Where(kitap => kitap.ToLower().Contains(searchText)).ToList();

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() == "Alındı")
            {
            }
            else if (comboBox1.SelectedItem.ToString() == "İade Edildi")
            {

            }
        }

        private void comboBoxKitaplar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
