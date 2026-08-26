using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kalkulator_Lembur
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Mengatur font dan warna secara otomatis saat aplikasi berjalan
            label1.Font = new Font("Times New Roman", 10, FontStyle.Bold);
            label1.ForeColor = Color.Blue;

            button1.Click += btnHitung_Click;   // <-- baris baru
        }
        

        // --- DIBIARKAN SAJA (Bawaan Klik Otomatis) ---

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        // --- TARUH KODE UTAMA DI SINI ---
        private void btnHitung_Click(object sender, EventArgs e)
        {
            // Validasi Input
            if (!double.TryParse(textBox1.Text, out double gajiBulanan) || gajiBulanan <= 0)
            {
                MessageBox.Show("Masukkan nominal gaji bulanan yang valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(textBox2.Text, out double jamLembur) || jamLembur <= 0)
            {
                MessageBox.Show("Masukkan jumlah jam lembur yang valid!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 1. Rumus Tarif Lembur Per Jam (1/173 dari Gaji Bulanan)
            double upahPerJam = gajiBulanan / 173.0;

            // 2. Perhitungan Berjenjang Jam Lembur
            double perkalianJamPertama = 0;
            double perkalianJamBerikutnya = 0;
            double totalUpahLembur = 0;

            if (jamLembur <= 1)
            {
                perkalianJamPertama = jamLembur * 1.5;
                totalUpahLembur = perkalianJamPertama * upahPerJam;
            }
            else
            {
                perkalianJamPertama = 1.0 * 1.5;
                perkalianJamBerikutnya = (jamLembur - 1) * 2.0;
                totalUpahLembur = (perkalianJamPertama + perkalianJamBerikutnya) * upahPerJam;
            }

            // Format Mata Uang Rupiah
            CultureInfo cultureIndo = new CultureInfo("id-ID");

            // Menampilkan Hasil di textBox3
            textBox3.Text = totalUpahLembur.ToString("C", cultureIndo);
        }
    }
}
