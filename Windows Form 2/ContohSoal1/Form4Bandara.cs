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
    public partial class Form4Bandara : Form
    {
        BandaraEntities db = new BandaraEntities(); // membuat koneksi ke database
        private int idBandara = -1; // menyimpan id bandara yang sedang diedit (-1 mode tambah, jika > 0 mode update)

        private void Form4Bandara_Load(object sender, EventArgs e)
        {
            LoadNegara(); // menampilkan daftar negara ke combobox
            LoadBandara(); // menampilkan semua data bandara ke dalam dataGridView

            dataGridBandara.AutoGenerateColumns = false;
            dataGridBandara.AllowUserToAddRows = false;
            dataGridBandara.ReadOnly = true;
        }
        
        private void LoadNegara()
        {
            countryBox.DataSource = db.Negaras.OrderBy(n => n.Nama).ToList();
            countryBox.DisplayMember = "Nama";
            countryBox.ValueMember = "ID";
            countryBox.SelectedIndex = -1;
        }

        private void LoadBandara()
        {
            dataGridBandara.DataSource = db.Bandaras.Include("Negara") // Include() mengambil data dari
            .OrderBy(b => b.Nama) // urutkan berdasarkan nama, dari
            .Select(b => new // select() memilih kolom yang akan
            {
                b.ID,
                b.Nama,
                b.KodeIATA,
                b.Kota,
                Negara = b.Negara.Nama,
                b.JumlahTerminal,
                b.Alamat,
            }).ToList();
        }

        private void ResetForm()
        {
            nameTxt.Clear();
            iataTxt.Clear();
            cityTxt.Clear();
            addressTxt.Clear();
            countryBox.SelectedIndex = -1;
            terminalCount.Value = 1;
            idBandara = -1; // kembali ke mode tambah data
            saveBtn.Text = "Simpan";
        }

        public Form4Bandara()
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

        private void saveBtn_Click(object sender, EventArgs e)
        {

        }

        private void dataGridBandara_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            ResetForm();
        }
    }
}
