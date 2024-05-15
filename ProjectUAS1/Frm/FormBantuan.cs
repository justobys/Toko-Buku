using ProjectUAS1.Bantuan;
using System; 
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectUAS1.Frm
{
    public partial class FormBantuan : Form
    {
        public FormBantuan()
        {
            InitializeComponent();
        }
        private void ShowHelpForm(string title, string content)
        {
            // Asumsikan bahwa Anda memiliki referensi ke instance MenuForm
            MenuForm menuForm = (MenuForm)this.ParentForm;
            bantuan_form helpForm = new bantuan_form();
            menuForm.LoadFormIntoPanel(helpForm); // Panggil metode untuk memuat form
            helpForm.Judul = title;
            helpForm.Isi = content;
            helpForm.Show();
        }

        private void btnTutor1_Click(object sender, EventArgs e)
        {
            string judul = "Pertanyaan Umum Aplikasi TokoBuku";
            string isiContent = PertanyaanUmum();

            ShowHelpForm(judul, isiContent);
        }

        private string PertanyaanUmum()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1. Bagaimana cara membuat akun?");
            sb.AppendLine("Untuk pembuatan akun, untuk saat ini hanya dibatasi untuk kasir saja.");
            sb.AppendLine();
            sb.AppendLine("2. Bagaimana cara mencari buku?");
            sb.AppendLine("Anda dapat mencari buku dengan menggunakan fitur pencarian di bagian dashboard. Masukkan judul buku, penulis, atau kata kunci lainnya, lalu tekan ‘Enter’.");
            sb.AppendLine();
            sb.AppendLine("3. Bagaimana cara membeli buku?");
            sb.AppendLine("Setelah menemukan buku yang Anda inginkan, pergilah ke etalase yang dituju. Setelah itu bawa buku yang diinginkan ke kasir untuk melakukan pembayaran. Ikuti petunjuk yang ada untuk menyelesaikan transaksi.");
            sb.AppendLine();
            sb.AppendLine("4. Apa metode pembayaran yang tersedia?");
            sb.AppendLine("Kami menerima berbagai metode pembayaran termasuk kartu kredit, transfer bank, dan pembayaran digital.");
            sb.AppendLine();
            sb.AppendLine("5. Bagaimana jika saya ingin mengembalikan buku?");
            sb.AppendLine("Kami memiliki kebijakan pengembalian dan penukaran. Silakan baca kebijakan tersebut di halaman ‘Kebijakan Pengembalian’ untuk informasi lebih lanjut.");

            return sb.ToString();
        }

        private void btnTutor2_Click(object sender, EventArgs e)
        {
            string judul = "Topik Bantuan";
            string isiContent = TopikBantuan();

            ShowHelpForm(judul, isiContent);
        }
        private string TopikBantuan()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("1. Mencari Buku");
            sb.AppendLine("Untuk melakukan pencarian buku, pertama masuk ke halaman 'Dahsboard'. Selanjutnya masukkan judul/author/Kategori buku yang diinginkan. Setelah memasukkan judul, klik cari buku. Nanti buku tersebut akan muncul didalam tabel.");
            sb.AppendLine();
            sb.AppendLine("2. Membeli Buku");
            sb.AppendLine("Setelah menemukan buku yang di inginkan. Pergi ke kasir untuk melakukan transaksi pembayaran");
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
