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
    public partial class Form6 : Form
    {
        private readonly string constr = "server=localhost;database=hastane;user=root;pwd=;";
        int bolum;
        public Form6(int bolum)
        {
            this.bolum = bolum;
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ekle();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }
        public void ekle()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    con.Open();
                    string query = "insert into hastalar (ad,soyad,tc_no,bolum_id,yatis_tarihi) values" +
                        " (@ad,@soyad,@tc_no,@bolum_id,@yatis_tarihi)";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@ad", textBox1.Text);
                        cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
                        cmd.Parameters.AddWithValue("@tc_no", textBox3.Text);
                        cmd.Parameters.AddWithValue("@bolum_id", bolum);
                        cmd.Parameters.AddWithValue("@yatis_tarihi", DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Hata " +ex.Message);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
