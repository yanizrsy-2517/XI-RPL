using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContohSoal1
{
    public partial class Form3Dashboard : Form
    {
        public Form3Dashboard()
        {
            InitializeComponent();
        }

        private void GoToDashboard(object sender, EventArgs e)
        {
            Form3Dashboard dashboard = new Form3Dashboard();
            this.Close();
            dashboard.Show();
        }

        private void GoToBandara(object sender, EventArgs e)
        {
            Form4Bandara bandara = new Form4Bandara();
            this.Close();
            bandara.Show();
        }

        private void GoToMaskapai(object sender, EventArgs e)
        {
            Form5Maskapai maskapai = new Form5Maskapai();
            this.Close();
            maskapai.Show();
        }

        private void GoToJadwalPenerbangan(object sender, EventArgs e)
        {
            Form6JadwalPenerbangan jadwal = new Form6JadwalPenerbangan();
            this.Close();
            jadwal.Show();
        }

        private void GoToKodePromo(object sender, EventArgs e)
        {
            Form7KodePromo promo = new Form7KodePromo();
            this.Close();
            promo.Show();
        }

        private void GoToUbahStatusPenerbangan(object sender, EventArgs e)
        {
            Form8UbahStatusPenerbangan status = new Form8UbahStatusPenerbangan();
            this.Close();
            status.Show();
        }

        private void Logout(object sender, EventArgs e)
        {
            Form1Login login = new Form1Login();
            this.Close();
            login.Show();
        }
    }
}
