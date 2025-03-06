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
    public partial class Form7 : Form
    {
        int hastaid;
        private readonly string constr = "server=localhost;database=hastane;user=root;pwd=";
        public Form7(int hastaid)
        {
            InitializeComponent();
            this.hastaid = hastaid;
        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            kaydet();
        }
        public void kaydet()
        {
            try
            {
                using (MySqlConnection con = new MySqlConnection(constr))
                {
                    con.Open();
                    string query = "insert into tani (hasta_id,tani_verisi,tani_tarihi) values (@hasta_id,@tani_verisi,@tani_tarihi)";
                    using (MySqlCommand cmd = new MySqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@hasta_id",hastaid);
                        cmd.Parameters.AddWithValue("tani_verisi",);
                        cmd.Parameters.AddWithValue("tani_tarihi",DateTime.Now);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Kaydedildi");
                this.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
    }
}
