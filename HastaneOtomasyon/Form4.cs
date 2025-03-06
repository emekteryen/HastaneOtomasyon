using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HastaneOtomasyon
{
    public partial class Form4 : Form
    {
        int hastaid,rowIndex,ilac_adet,ilacadedi;
        string h_ad, h_soyad;
        decimal h_tcno;
        private readonly string connectionString = "server=localhost;database=hastane;user=root;pwd=";
        public Form4(int hastaid,string h_ad,string h_soyad,decimal h_tcno)
        {
            InitializeComponent();
            this.hastaid = hastaid;
            this.h_ad = h_ad;
            this.h_soyad = h_soyad;
            this.h_tcno = h_tcno;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= 10; i++)
            {
                comboBox1.Items.Add(i.ToString());
            }
            comboBox1.SelectedIndex = 0;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            yazdır();
            receteyaz();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ilacadedi = int.Parse(comboBox1.SelectedItem.ToString());
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int mevcut = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ilac_adet2"].Value);
            dataGridView1.Rows[e.RowIndex].Cells["ilac_adet2"].Value = mevcut - 1;
            int kalan = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["ilac_adet2"].Value);
            if (kalan == 0)
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            ilacgetir();
        }
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentCell != null)
            {
                rowIndex = dataGridView2.CurrentCell.RowIndex;
                ilacekle();
            }
        }
        public void ilacgetir()
        {
            if (textBox1.Text == "")
            {
                dataGridView2.Rows.Clear();
                return;
            }
            try
            {
                using MySqlConnection connection = new MySqlConnection(connectionString);
                {
                    dataGridView2.Rows.Clear();
                    connection.Open();
                    string query = "SELECT * FROM ilaclar WHERE ilac_ad LIKE @ilacad";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@ilacad", "%" + textBox1.Text + "%");

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            List<ilaclar> ilaclarlist = new List<ilaclar>();
                            while (reader.Read())
                            {
                                ilaclar ilac = new ilaclar
                                {
                                    ilac_id = reader.GetInt32(0),
                                    ilac_ad = reader.GetString(1),
                                };
                                ilaclarlist.Add(ilac);
                                dataGridView2.Rows.Add(ilac.ilac_id, ilac.ilac_ad);
                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ilacekle()
        {
            int ilacid = int.Parse(dataGridView2.Rows[rowIndex].Cells["ilac_id"].Value.ToString());
            string ilacad = dataGridView2.Rows[rowIndex].Cells["ilac_ad"].Value.ToString();
            List<ilaclar> recete = new List<ilaclar>();
            if (ilacad == null || ilacid == 0)
            {
                return;
            }
            ilaclar recete1 = new ilaclar
            {
                ilac_id = ilacid,
                ilac_ad = ilacad,
                ilac_adet = ilacadedi
            };
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["ilac_ad2"].Value != null && row.Cells["ilac_ad2"].Value.ToString() == ilacad)
                {
                    int mevcutAdet = Convert.ToInt32(row.Cells["ilac_adet2"].Value);
                    row.Cells["ilac_adet2"].Value = mevcutAdet + ilacadedi;
                    return;
                }
            }
            dataGridView1.Rows.Add(recete1.ilac_id, recete1.ilac_ad, recete1.ilac_adet);
        }
        public void receteyaz()
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(connectionString);
                {
                    conn.Open();
                    string query = "insert into recete (ilac_id, ilac_adet,hasta_id,recete_tarihi) values (@ilac_id,@ilac_adet,@hasta_id,@recete_tarihi)";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        foreach (DataGridViewRow row in dataGridView1.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                int ilac_id = Convert.ToInt32(row.Cells["ilac_id2"].Value);
                                int ilac_adet = Convert.ToInt32(row.Cells["ilac_adet2"].Value);
                                cmd.Parameters.Clear();
                                cmd.Parameters.AddWithValue("hasta_id", hastaid);
                                cmd.Parameters.AddWithValue("ilac_id", ilac_id);
                                cmd.Parameters.AddWithValue("ilac_adet", ilac_adet);
                                cmd.Parameters.AddWithValue("recete_tarihi", DateTime.Now);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                }
                textBox1.Clear();
                dataGridView1.Rows.Clear();
                dataGridView2.Rows.Clear();
                MessageBox.Show("Kayıt tamamlandı");
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        public void yazdır()
        {
            string outputFilePath = "C:\\Users\\Emek\\Documents\\recete.pdf";
            using (var writer = new PdfWriter(outputFilePath))
            {
                using (var pdf = new PdfDocument(writer))
                {
                    var document = new Document(pdf);
                    document.Add(new Paragraph("Emek Hastanesi"));
                    document.Add(new Paragraph("REÇETE"));
                    document.Add(new Paragraph("ADI: " + h_ad + " SOYADI: " + h_soyad));
                    document.Add(new Paragraph("TC KİMLİK NUMARASI: " + h_tcno));
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells["ilac_ad2"].Value != null && row.Cells["ilac_adet2"] !=null)
                        {
                            string ilacAd = row.Cells["ilac_ad2"].Value.ToString();
                            string ilacaded = row.Cells["ilac_adet2"].Value.ToString();
                            document.Add(new Paragraph(ilacAd + " Adet: " + ilacaded));                           
                        }
                    }
                    string tarih = Convert.ToString(DateTime.Now);
                    document.Add(new Paragraph(tarih));
                }
            }
            MessageBox.Show("PDF dosyası başarıyla oluşturuldu!");
        }
    }
}
