using MySql.Data.MySqlClient;

namespace HastaneOtomasyon
{
    public partial class Form1 : Form
    {
        private readonly string connectionStr = "server=localhost;database=hastane;user=root;pwd=";
        int doktor_id;
        private bool k�rm�z�M� = false;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            giris();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            timer1.Start();
        }
        public async void giris()
        {
            try
            {
                await using MySqlConnection connection = new MySqlConnection(connectionStr);
                {
                    connection.Open();
                    string query = "select * from doktorlar where sifre=@sifre and tc_no=@tc_no";
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@tc_no", textBox1.Text);
                        cmd.Parameters.AddWithValue("@sifre", textBox2.Text);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show("kullan�c� ad� veya �ifre hatal�");
                            }
                            else
                            {
                                doktor_id = int.Parse(reader["doktor_id"].ToString());
                                MessageBox.Show("Ho�geldiniz");
                                Form2 form2 = new Form2(doktor_id);
                                form2.ShowDialog();
                                this.Close();
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
            if (k�rm�z�M�)
            {
                label1.BackColor = Color.Transparent;
            }
            else { label1.BackColor = Color.Red; }
        }
    }
}
