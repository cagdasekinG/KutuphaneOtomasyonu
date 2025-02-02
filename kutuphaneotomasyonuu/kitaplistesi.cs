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
using TextBox = System.Windows.Forms.TextBox;


namespace kutuphaneotomasyonuu
{
    public partial class kitaplistesi : Form
    {
        private MySqlConnection conn;
        private string connectionString = Form1.ConnString;
        private TextBox textbox2;
        private int stoksayisi;

        public kitaplistesi()
        {
            InitializeComponent();
            DilListesiDoldur();
        }
        private void DilListesiDoldur()
        {
            string[] diller = { "Afrikaanca", "Albanca", "Arapça", "Azerice", "Baskça",
    "Bengalce", "Birmanca", "Boşnakça", "Bulgarca", "Çekçe",
    "Çince", "Danimarkaca", "Endonezce", "Ermenice", "Estonyaca",
    "Farsça", "Filipince", "Fince", "Fransızca", "Galiçyaca",
    "Güceratça", "Gürcüce", "Haiti Kreyolu", "Hausa", "Hintçe",
    "Hollandaca", "İbranice", "İngilizce", "İrlandaca", "İspanyolca",
    "İsveççe", "İtalyanca", "İzlandaca", "Japonca", "Kannada",
    "Katalanca", "Kazakça", "Kırgızca", "Korece", "Kürtçe",
    "Lehçe", "Letonca", "Litvanca", "Macarca", "Makedonca",
    "Malayalam", "Malayca", "Maori", "Marathi", "Moğolca",
    "Nepalce", "Norveççe", "Özbekçe", "Pencapça", "Portekizce",
    "Romence", "Rusça", "Sırpça", "Sinhala", "Slovakça",
    "Slovenca", "Somalice", "Svahili", "Tacikçe", "Tamilce",
    "Tatarca", "Teluguca", "Tayca", "Tibetçe", "Türkçe",
    "Türkmence", "Ukraynaca", "Urduca", "Uygurca", "Vietnamca",
    "Yidiş", "Yoruba", "Yunanca", "Zuluca" };
            comboBox1.Items.AddRange(diller);
        }

        private void kitaplistesi_Load(object sender, EventArgs e)
        {
            comboBox4.SelectedIndex = -1;
            comboBox3.SelectedIndex = -1;
            conn = new MySqlConnection(connectionString);
            dataGridView1.DataSource = GetBooksFromDatabase(conn);
            //ComboBoxKitaplariDoldur();
            ComboBoxYazarlarıDoldur();
            ComboBoxYayineviniDoldur();
        }

        private DataTable GetBooksFromDatabase(MySqlConnection conn)
        {
            DataTable dt = new DataTable();
            try
            {
                conn.Open();
                string query = "SELECT * FROM kitaplar";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantısı sırasında bir hata oluştu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        private void ComboBoxYazarlarıDoldur()
        {
            try
            {
                conn.Open();
                string query = "SELECT yazar FROM yazarlar";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                List<string> yazarlar = new List<string>();
                while (reader.Read())
                {
                    yazarlar.Add(reader["yazar"].ToString());
                }
                comboBox3.DataSource = yazarlar;
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
        public class Kitaplar
        {
            private string connectionString;

            public Kitaplar(string connString)
            {
                connectionString = connString;
            }

            public int GetKitapIdByName(string kitapAdi)
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    string query = "SELECT id FROM kitaplar WHERE kitap_adi = @kitapAdi";
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

        }


        private void ComboBoxYayineviniDoldur()
        {
            List<string> yayineviListesi = new List<string>();
            try
            {
                conn.Open();
                string query = "SELECT yayinevi FROM yayinevi";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    yayineviListesi.Add(reader["yayinevi"].ToString());
                }
                comboBox4.DataSource = yayineviListesi;
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

        private void BindKitaplarData()
        {
            try
            {
                conn.Open();
                string query = "SELECT kitap_adi FROM kitaplar";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                textbox2.Text = "";
                while (reader.Read())
                {
                    textbox2.Text += reader["kitap_adi"].ToString() + Environment.NewLine;
                }
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


        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string kitap_id = textBox1.Text;
            string kitap_adi = textBox2.Text;
            string yazar = comboBox3.Text;
            string yayinevi = comboBox4.Text;
            string basim_yili = textBox3.Text;
            string sayfa_sayisi = textBox4.Text;
            string dil = comboBox1.Text;
            if (!int.TryParse(textBox6.Text, out int stokSayisi))
            {
                MessageBox.Show("Lütfen geçerli bir stok sayısı giriniz.");
                return;
            }

            string query = "INSERT INTO kitaplar (kitap_id, kitap_adi, yazar, yayinevi, basim_yili, sayfa_sayisi, dil, stok_sayisi) VALUES (@kitap_id, @kitap_adi, @yazar, @yayinevi, @basim_yili, @sayfa_sayisi, @dil, @stok_sayisi)";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@kitap_id", kitap_id);
            cmd.Parameters.AddWithValue("@kitap_adi", kitap_adi);
            cmd.Parameters.AddWithValue("@yazar", yazar);
            cmd.Parameters.AddWithValue("@yayinevi", yayinevi);
            cmd.Parameters.AddWithValue("@basim_yili", basim_yili);
            cmd.Parameters.AddWithValue("@sayfa_sayisi", sayfa_sayisi);
            cmd.Parameters.AddWithValue("@dil", dil);
            cmd.Parameters.AddWithValue("@stok_sayisi", stokSayisi);

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Kitap başarıyla kaydedildi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanına kaydetme sırasında bir hata oluştu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
            RefreshDataGridView();
        }


        private void btnSil_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int kitapId))
            {
                MessageBox.Show("Lütfen geçerli bir kitap ID giriniz.");
                return;
            }

            string query = "DELETE FROM kitaplar WHERE kitap_id = @kitap_id";

            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@kitap_id", kitapId);

            try
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();

                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("Kitap başarıyla silindi.");
                    RefreshDataGridView();
                }
                else
                {
                    MessageBox.Show("Silinecek kitap bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanından silme sırasında bir hata oluştu: " + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }


        private void RefreshDataGridView()
        {
            dataGridView1.DataSource = GetBooksFromDatabase(conn);
            dataGridView1.Refresh();
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                string kitap_id = selectedRow.Cells["kitap_id"].Value.ToString();

                string query = "UPDATE kitaplar SET kitap_adi = @kitap_adi, yazar = @yazar, yayinevi = @yayinevi, basim_yili = @basim_yili, sayfa_sayisi = @sayfa_sayisi, dil = @dil, stok_sayisi = @stok_sayisi WHERE kitap_id = @kitap_id";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@kitap_id", textBox1.Text);
                cmd.Parameters.AddWithValue("@kitap_adi", textBox2.Text);
                cmd.Parameters.AddWithValue("@yazar", comboBox3.Text);
                cmd.Parameters.AddWithValue("@yayinevi", comboBox4.Text);
                cmd.Parameters.AddWithValue("@basim_yili", textBox3.Text);
                cmd.Parameters.AddWithValue("@sayfa_sayisi", textBox4.Text);
                cmd.Parameters.AddWithValue("@dil", comboBox1.Text);
                cmd.Parameters.AddWithValue("@stok_sayisi", textBox6.Text);

                try
                {
                    if (conn.State != ConnectionState.Open)
                        conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Kitap bilgileri başarıyla güncellendi.");
                        selectedRow.Cells["kitap_id"].Value = textBox1.Text;
                        selectedRow.Cells["kitap_adi"].Value = textBox2.Text;
                        selectedRow.Cells["yazar"].Value = comboBox3.Text;
                        selectedRow.Cells["yayinevi"].Value = comboBox4.Text;
                        selectedRow.Cells["basim_yili"].Value = textBox3.Text;
                        selectedRow.Cells["sayfa_sayisi"].Value = textBox4.Text;
                        selectedRow.Cells["dil"].Value = comboBox1.Text;
                        selectedRow.Cells["stok_sayisi"].Value = textBox6.Text;
                    }
                    else
                    {
                        MessageBox.Show("Güncellenecek kitap bulunamadı.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veritabanında güncelleme sırasında bir hata oluştu: " + ex.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin.");
            }
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void comboBox3_TextChanged(object sender, EventArgs e)
        {
            List<string> originalList = ((List<string>)comboBox3.DataSource).ToList();
            string searchText = comboBox3.Text.ToLower();
            List<string> filteredList = originalList.Where(yazar => yazar.ToLower().Contains(searchText)).ToList();
            comboBox3.DataSource = filteredList;
            comboBox3.Text = searchText;
            comboBox3.SelectionStart = searchText.Length;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        private void comboBox4_TextChanged(object sender, EventArgs e)
        {
            List<string> originalList = ((List<string>)comboBox4.DataSource).ToList();
            string searchText = comboBox4.Text.ToLower();
            List<string> filteredList = originalList.Where(yayinevi => yayinevi.ToLower().Contains(searchText)).ToList();
            comboBox4.DataSource = filteredList;
            comboBox4.Text = searchText;
            comboBox4.SelectionStart = searchText.Length;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
