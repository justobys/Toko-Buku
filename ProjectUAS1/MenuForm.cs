using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using ProjectUAS1.Frm;

namespace ProjectUAS1
{
    public partial class MenuForm : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int nRigthRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse
            );
        private string userRole;
        public MenuForm(string role)
        {
            InitializeComponent();
            this.userRole = role;

            UpdateUIBasedOnUserRole(this.userRole);

            // Jika role adalah kasir, tampilkan form transaksi
            if (this.userRole == "kasir")
            {
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 7, 7));
                PnlNav.Height = btnTransaksi.Height;
                PnlNav.Top = btnTransaksi.Top;
                PnlNav.Left = btnTransaksi.Left;
                btnTransaksi.BackColor = Color.FromArgb(106, 212, 221);
                btnTransaksi.ForeColor = Color.FromArgb(240, 240, 240);

                pnlTextTopNav.Text = "Transaksi";
                this.PnlFormLoader.Controls.Clear();
                FormTransaksi frmTransaksi_vrb = new FormTransaksi() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                frmTransaksi_vrb.FormBorderStyle = FormBorderStyle.None;
                this.PnlFormLoader.Controls.Add(frmTransaksi_vrb);
                frmTransaksi_vrb.Show();
            }
            else
            {
                Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 7, 7));
                PnlNav.Height = btnDashboard.Height;
                PnlNav.Top = btnDashboard.Top;
                PnlNav.Left = btnDashboard.Left;
                btnDashboard.BackColor = Color.FromArgb(106, 212, 221);
                btnDashboard.ForeColor = Color.FromArgb(240, 240, 240);

                //Untuk Menampilkan form dashboard diawal
                pnlTextTopNav.Text = "Dashboard";
                this.PnlFormLoader.Controls.Clear();
                FormDashboard frmdashboard_vrb = new FormDashboard(userRole) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
                frmdashboard_vrb.FormBorderStyle = FormBorderStyle.None;
                this.PnlFormLoader.Controls.Add(frmdashboard_vrb);
                frmdashboard_vrb.Show();
            }
        }
        public void SetUsernameLabel(string username)
        {
            lblUsername.Text = username;
        }

        public void UpdateUIBasedOnUserRole(string role)
        {
            // Tampilkan btnTransaksi jika role adalah 'kasir'
            btnTransaksi.Visible = role == "kasir";

            // Sembunyikan atau tampilkan tombol lain berdasarkan role
            btnDashboard.Visible = role != "kasir";
            btnTransaksi.Visible = role != "public"; // Pastikan Anda memiliki btnKasir di form Anda

            // Anda dapat menambahkan logika tambahan untuk peran 'publik' jika diperlukan
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }
        public void LoadFormIntoPanel(Form childForm)
        {
            PnlFormLoader.Controls.Clear(); // Bersihkan panel sebelum memuat form baru
            childForm.TopLevel = false; // Set form sebagai child form
            PnlFormLoader.Controls.Add(childForm); // Tambahkan form ke panel
            childForm.Show(); // Tampilkan form
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            PnlNav.Height = btnDashboard.Height;
            PnlNav.Top = btnDashboard.Top;
            PnlNav.Left = btnDashboard.Left;
            btnDashboard.BackColor = Color.FromArgb(106, 212, 221);
            btnDashboard.ForeColor = Color.FromArgb(240, 240, 240);

            //Untuk Menampilkan form dashboard
            pnlTextTopNav.Text = "Dashboard";
            this.PnlFormLoader.Controls.Clear();
            FormDashboard frmdashboard_vrb = new FormDashboard(userRole) { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmdashboard_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(frmdashboard_vrb);
            frmdashboard_vrb.Show();
        }

        private void btnTransaksi_Click(object sender, EventArgs e)
        {
            PnlNav.Height = btnTransaksi.Height;
            PnlNav.Top = btnTransaksi.Top;
            btnTransaksi.BackColor = Color.FromArgb(106, 212, 221);
            btnTransaksi.ForeColor = Color.FromArgb(240, 240, 240);

            //Untuk Menampilkan form transaksi
            pnlTextTopNav.Text = "Transaksi";
            this.PnlFormLoader.Controls.Clear();
            FormTransaksi frmtransaksi_vrb = new FormTransaksi() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmtransaksi_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(frmtransaksi_vrb);
            frmtransaksi_vrb.Show();
        }

        private void btnBantuan_Click(object sender, EventArgs e)
        {
            PnlNav.Height = btnBantuan.Height;
            PnlNav.Top = btnBantuan.Top;
            btnBantuan.BackColor = Color.FromArgb(106, 212, 221);
            btnBantuan.ForeColor = Color.FromArgb(240, 240, 240);

            //Untuk Menampilkan form transaksi
            pnlTextTopNav.Text = "Bantuan";
            this.PnlFormLoader.Controls.Clear();
            FormBantuan frmbantuan_vrb = new FormBantuan() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            frmbantuan_vrb.FormBorderStyle = FormBorderStyle.None;
            this.PnlFormLoader.Controls.Add(frmbantuan_vrb);
            frmbantuan_vrb.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            PnlNav.Height = btnLogOut.Height;
            PnlNav.Top = btnLogOut.Top;
            btnLogOut.BackColor = Color.FromArgb(106, 212, 221);
            btnLogOut.ForeColor = Color.FromArgb(240, 240, 240);

            // Tampilkan MessageBox dengan pilihan Ya atau Tidak
            DialogResult dialogResult = MessageBox.Show("Apakah Anda yakin ingin logout?", "Konfirmasi Logout", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                // Jika pengguna memilih Ya, lakukan proses logout
                if (userRole == "public")
                {
                    // Jika pengguna adalah public, tampilkan puzzle
                    string puzzleAnswer = Microsoft.VisualBasic.Interaction.InputBox("Selesaikan puzzle ini untuk logout: Apa yang selalu di depan matamu tetapi tidak bisa kamu lihat?", "Puzzle Logout", "");
                    if (puzzleAnswer != "Masa depan" && puzzleAnswer != "masa depan")
                    {
                        // Jika jawaban puzzle salah, batalkan proses logout
                        MessageBox.Show("Jawaban puzzle salah. Proses logout dibatalkan.");
                        return;
                    }
                }
                MessageBox.Show("Berhasil Log Out");
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
            else if (dialogResult == DialogResult.No)
            {
                // Jika pengguna memilih Tidak, batalkan proses logout
                // Tidak perlu melakukan apa-apa karena proses logout dibatalkan
            }
        }


        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(151, 231, 225);
            btnDashboard.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void btnTransaksi_Leave(object sender, EventArgs e)
        {
            btnTransaksi.BackColor = Color.FromArgb(151, 231, 225);
            btnTransaksi.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void btnBantuan_Leave(object sender, EventArgs e)
        {
            btnBantuan.BackColor = Color.FromArgb(151, 231, 225);
            btnBantuan.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void btnLogOut_Leave(object sender, EventArgs e)
        {
            btnLogOut.BackColor = Color.FromArgb(151, 231, 225);
            btnLogOut.ForeColor = Color.FromArgb(0, 0, 0);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
