using MySql.Data.MySqlClient;

namespace HastaneOtomasyon
{
    public partial class Form1 : Form
    {
        private readonly string connectionStr = "server=localhost;database=hastane;user=root;pwd=";
        int doktor_id;
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
            label1.BackColor = Color.White;
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "HH:mm";
            renkdegis();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value.Date;
            DateTime time = dateTimePicker2.Value;
            DateTime combinedDateTime = date.Add(time.TimeOfDay);
            textBox1.Text = combinedDateTime.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        public void renkdegis()
        {
            if (label1.BackColor == Color.White)
            {

                label1.ForeColor = Color.Red;
                Thread.Sleep(200);
                //renkdegis();
            }
            else
            {

                label1.ForeColor = Color.Black;
                Thread.Sleep(200);
                //renkdegis();
            }
            //renkdegis();
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
                                MessageBox.Show("kullanýcý adý veya þifre hatalý");
                            }
                            else 
                            {
                                doktor_id = int.Parse(reader["doktor_id"].ToString());
                                Form2 form2 = new Form2(doktor_id);
                                form2.ShowDialog();
                                this.Close();
                            }
                        }
                    }
                }
                //this.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void label1_ForeColorChanged(object sender, EventArgs e)
        {
            renkdegis();
        }
    }
}
