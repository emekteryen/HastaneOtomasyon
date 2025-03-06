using MySql.Data.MySqlClient;
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
    public partial class Form3 : Form
    {
        private readonly string constr = "server=localhost;database=hastane;user=root;pwd=;";
        int hastaid;
        public Form3(int hastaid)
        {
            InitializeComponent();
            this.hastaid = hastaid;
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            //textBox1.Text = hastaid;
            label4.Text = "randevular";
            label5.Text = "reçeteler";
            hastabilgi();
            randevugetir();
            recetegetir();
            tanigetir();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                int secim = dataGridView1.CurrentCell.RowIndex;
                randevusil(secim);

            }
            else { MessageBox.Show("Hata"); }
        }
        public void hastabilgi()
        {
            try
            {
                using MySqlConnection connection = new MySqlConnection(constr);
                {
                    connection.Open();
                    string query = "select * from hastalar where hasta_id=@hasta_id";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@hasta_id", hastaid);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                label1.Text = reader["ad"].ToString();
                                label2.Text = reader["soyad"].ToString();
                                label3.Text = reader["tc_no"].ToString();
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
        public void randevugetir()
        {
            try
            {
                using MySqlConnection conn = new MySqlConnection(constr);
                {
                    conn.Open();
                    string query = "select d.ad,d.soyad,r.randevu_tarihi,b.bolum_adi,d.ad from randevular r" +
                        " join doktorlar d on" +
                        " d.doktor_id=r.doktor_id join bolumler b on b.bolum_id=r.bolum_id where r.hasta_id=@hasta_id and " +
                        "r.randevu_tarihi >@randevu_tarihi order by randevu_tarihi";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@hasta_id", hastaid);
                        cmd.Parameters.AddWithValue("@randevu_tarihi", DateTime.Now);
                        using (MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            da.SelectCommand = cmd;
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void recetegetir()
        {
            try
            {
                using MySqlConnection con = new MySqlConnection(constr);
                {
                    con.Open();
                    string query = "select h.ad, h.soyad, i.ilac_ad, r.ilac_adet, r.recete_tarihi" +
                        " from recete r join hastalar h on r.hasta_id=h.hasta_id join ilaclar i on r.ilac_id=i.ilac_id where r.hasta_id=@hasta_id" +
                        " order by recete_tarihi";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@hasta_id", hastaid);
                        cmd.Parameters.AddWithValue("@recete_tarihi", DateTime.Now);
                        using (MySqlDataAdapter d = new MySqlDataAdapter())
                        {
                            d.SelectCommand = cmd;
                            DataTable dt = new DataTable();
                            d.Fill(dt);
                            dataGridView2.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void randevusil(int secim)
        {
            try
            {
                DateTime tarih = Convert.ToDateTime(dataGridView1.Rows[secim].Cells["randevu_tarihi"].Value.ToString());
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    con.Open();
                    string query = "delete from randevular where randevu_tarihi=@randevu_tarihi";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@randevu_tarihi", tarih);
                        int sonuc = cmd.ExecuteNonQuery(); // Komutu çalıştır

                        if (sonuc > 0)
                            MessageBox.Show("Randevu başarıyla silindi.");
                        else
                            MessageBox.Show("Silinecek randevu bulunamadı.");
                    }
                }
                //dataGridView1.Rows.Clear();
                randevugetir();
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        public void tanigetir()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    con.Open();
                    string query = "select tani_verisi,tani_tarihi from tani where hasta_id=@hasta_id";
                    using(MySqlCommand cm = new MySqlCommand(query, con))
                    {
                        cm.Parameters.AddWithValue("@hasta_id", hastaid);
                        using(MySqlDataAdapter da = new MySqlDataAdapter())
                        {
                            da.SelectCommand = cm;
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dataGridView3.DataSource = dt;
                        }
                        
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}