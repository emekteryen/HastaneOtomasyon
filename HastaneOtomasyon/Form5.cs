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
    public partial class Form5 : Form
    {
        DateTime tarih;
        DateTime saat;
        int hastaid;
        int doktor_id;
        int bolum;
        DateTime randevusaat;
        private readonly string constr = "server=localhost;database=hastane;user=root;pwd=;";
        public Form5(int hastaid, int doktor_id, int bolum)
        {
            InitializeComponent();
            this.hastaid = hastaid;
            this.doktor_id = doktor_id;
            this.bolum = bolum;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            saatal();
            textBox1.Text = randevusaat.ToString();
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            saatal();
            textBox1.Text = randevusaat.ToString();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "HH:mm";
            dateTimePicker2.ShowUpDown = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saatal();
            if(randevusaat < DateTime.Now) { MessageBox.Show("Geçmiş bir tarihe randevu veremezsiniz!");return; }
            randevual();
        }
        public void saatal()
        {
            tarih = dateTimePicker1.Value.Date;
            saat = dateTimePicker2.Value;
            TimeSpan zaman = new TimeSpan(saat.Hour, saat.Minute, 0);
            randevusaat = tarih.Add(zaman);

        }
        public void randevual()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    con.Open();
                    string query2 = "select * from randevular where randevu_tarihi=@randevu_tarihi and doktor_id=@doktor_id";
                    using (MySqlCommand cmnd = new MySqlCommand(query2, con))
                    {
                        cmnd.Parameters.AddWithValue("@randevu_tarihi", randevusaat);
                        cmnd.Parameters.AddWithValue("@doktor_id", doktor_id);
                        using MySqlDataReader reader = cmnd.ExecuteReader();
                        if (reader.Read()) { MessageBox.Show(randevusaat + " tarihinde zaten randevu verdiniz! Başka tarih seçin.");return; }
                    }

                        string query = "INSERT INTO randevular (bolum_id, doktor_id, hasta_id, randevu_tarihi) " +
                                       "VALUES (@bolum_id, @doktor_id, @hasta_id, @randevu_tarihi)";

                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@bolum_id", bolum);
                        cmd.Parameters.AddWithValue("@doktor_id", doktor_id);
                        cmd.Parameters.AddWithValue("@hasta_id", hastaid);
                        cmd.Parameters.AddWithValue("@randevu_tarihi", randevusaat);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Randevu başarıyla eklendi.");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Randevu eklenirken hata oluştu.");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


    }
}
