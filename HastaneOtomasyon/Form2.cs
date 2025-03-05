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
    public partial class Form2 : Form
    {
        private string connectionString = "server=localhost;database=hastane;user=root;pwd=;";
        int doktor_id;
        int bolum;
        private bool KırmızıMı;
        public Form2(int doktor_id)
        {
            InitializeComponent();
            this.doktor_id = doktor_id;
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //string yatakhane = bolum;
            doktorbilgi();
            hastaListele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                receteac(rowIndex);
            }
            else
            {
                MessageBox.Show("Lütfen bir satır seçin!");
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                hastabilgi(rowIndex);
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir satır seçin");
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentCell != null)
            {
                int rowIndex = dataGridView1.CurrentCell.RowIndex;
                randevual(rowIndex);
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir satır seçiniz");
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //if (textBox1.Text == "") { hastaListele();return; }
            hastaara();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            hastaekle();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) return;
            receteac(e.RowIndex);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex == -1) { return; }
            //hastabilgi(e.RowIndex);
        }
        public void hastabilgi(int rowIndex)
        {
            int hastaid = int.Parse(dataGridView1.Rows[rowIndex].Cells["hasta_id"].Value.ToString());
            //textBox3.Text = Convert.ToString(hastaid);
            Form3 form3 = new Form3(hastaid);
            form3.ShowDialog();
        }
        public void receteac(int rowIndex)
        {
            int hastaid = int.Parse(dataGridView1.Rows[rowIndex].Cells["hasta_id"].Value.ToString());
            Form4 form4 = new Form4(hastaid);
            form4.ShowDialog();
        }
        public void randevual(int rowIndex)
        {
            int hastaid = int.Parse(dataGridView1.Rows[rowIndex].Cells["hasta_id"].Value.ToString());
            Form5 form5 = new Form5(hastaid, bolum, doktor_id);
            form5.ShowDialog();
        }
        public void hastaekle()
        {
            Form6 form6 = new Form6(bolum);
            form6.ShowDialog();
        }
        public void hastaara()
        {
            dataGridView1.Rows.Clear();
            try
            {
                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM hastalar WHERE bolum_id = @bolum_id AND CAST(tc_no AS CHAR) LIKE @tcno";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@bolum_id", bolum);
                        cmd.Parameters.AddWithValue("@tcno", "%" + textBox1.Text.Trim() + "%");
                        using (MySqlDataReader rdr = cmd.ExecuteReader())
                        {
                            while (rdr.Read())
                            {
                                Hasta hasta = new Hasta
                                {
                                    hasta_id = rdr.GetInt32("hasta_id"),
                                    ad = rdr.GetString("ad"),
                                    soyad = rdr.GetString("soyad"),
                                    tc_no = rdr.GetDecimal("tc_no")
                                };
                                dataGridView1.Rows.Add(hasta.hasta_id, hasta.ad, hasta.soyad, hasta.tc_no);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
        public void hastaListele()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(connectionString))
                {
                    con.Open();
                    string query = "select hasta_id,ad,soyad,tc_no from hastalar where bolum_id=@bolum_id";
                    using (MySqlCommand cmd3 = new MySqlCommand(query, con))
                    {
                        cmd3.Parameters.AddWithValue("@bolum_id", bolum);
                        using (MySqlDataReader dr = cmd3.ExecuteReader())
                        {
                            //List<Hasta> hastalar = new List<Hasta>();
                            while (dr.Read())
                            {
                                Hasta hastane = new Hasta
                                {
                                    hasta_id = dr.GetInt32("hasta_id"),
                                    ad = dr.GetString("ad"),
                                    soyad = dr.GetString("soyad"),
                                    tc_no = dr.GetDecimal("tc_no")
                                };
                                dataGridView1.Rows.Add(hastane.hasta_id, hastane.ad, hastane.soyad, hastane.tc_no);
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

        public void doktorbilgi()
        {
            try
            {
                using (MySqlConnection con5 = new MySqlConnection(connectionString))
                {
                    con5.Open();
                    string query = "select d.ad, d.soyad, d.bolum_id, b.bolum_adi from doktorlar d join bolumler b on d.bolum_id = b.bolum_id where doktor_id=@doktor_id";
                    using (MySqlCommand cmd = new MySqlCommand(query, con5))
                    {
                        cmd.Parameters.AddWithValue("@doktor_id", doktor_id);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                label1.Text = reader["ad"].ToString();
                                label2.Text = reader["soyad"].ToString();
                                label3.Text = reader["bolum_adi"].ToString();
                                bolum = int.Parse(reader["bolum_id"].ToString());
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

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (KırmızıMı)
            {
                label4.BackColor = Color.Red;
            }
            else { label4.BackColor = Color.Transparent; }
            KırmızıMı = !KırmızıMı;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedCells!=null) { int rowIndex= dataGridView1.CurrentCell.RowIndex; taniyaz(rowIndex); }
        }
        public void taniyaz(int rowIndex)
        {
            int hastaid = int.Parse(dataGridView1.Rows[rowIndex].Cells["hasta_id"].Value.ToString());
            Form7 form7 = new Form7(hastaid);
            form7.ShowDialog();
        }
    }
}
