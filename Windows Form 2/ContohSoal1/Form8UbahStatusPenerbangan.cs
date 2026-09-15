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
    public partial class Form8UbahStatusPenerbangan : Form
    {
        BandaraEntities db = new BandaraEntities();
        private int idStatus;

        public Form8UbahStatusPenerbangan()
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

        private void Logout(object sender, EventArgs e)
        {
            Form1Login login = new Form1Login();
            this.Close();
            login.Show();
        }

        private void LoadStatus()
        {
            statusBox.DataSource = db.StatusPenerbangans.ToList();
            statusBox.ValueMember = "ID";
            statusBox.DisplayMember = "Nama";

            statusBox.SelectedIndex = -1;
        }

        private void LoadData()
        {
            dataGridStatus.DataSource = db.PerubahanStatusJadwalPenerbangans.Select(s => new
            {
                s.ID,
                s.JadwalPenerbanganID,
                kodePenerbangan = s.JadwalPenerbangan.KodePenerbangan,
                bandaraAwal = s.JadwalPenerbangan.Bandara.Nama,
                bandaraTujuan = s.JadwalPenerbangan.Bandara1.Nama,
                maskapai = s.JadwalPenerbangan.Maskapai.Nama,
                tanggalKeberangkatan = s.JadwalPenerbangan.TanggalWaktuKeberangkatan,
                durasiPenerbangan = (s.JadwalPenerbangan.DurasiPenerbangan / 60) + " Jam " + (s.JadwalPenerbangan.DurasiPenerbangan % 60) + " Menit ",
                statusPenerbangan = s.StatusPenerbangan.Nama,
                s.WaktuPerubahanTerjadi
            }).ToList();
        }

        private void dataGridStatus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            idStatus = Convert.ToInt32(dataGridStatus.Rows[e.RowIndex].Cells["ID"].Value);
        }
    }
}
