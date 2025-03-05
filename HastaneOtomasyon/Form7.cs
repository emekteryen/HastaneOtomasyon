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
        public Form7(int hasta_id)
        {
            InitializeComponent();
            this.hastaid = hasta_id;
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

        }
    }
}
