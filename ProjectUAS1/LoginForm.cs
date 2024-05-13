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
using BCrypt;
using Org.BouncyCastle.Crypto.Generators;

namespace ProjectUAS1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;password=;database=db_tokobuku;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT username, password, level FROM tbl_user WHERE username=@username";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", txtUsername.Text);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPasswordHash = reader["password"].ToString();
                            string enteredPassword = txtPassword.Text;

                            if (BCrypt.Net.BCrypt.Verify(enteredPassword, storedPasswordHash))
                            {
                                string username = reader["username"].ToString();
                                string level = reader["level"].ToString();
                                switch (level)
                                {
                                    case "admin":
                                        // Akses admin: tampilkan semua tombol dan transaksi
                                        MenuForm adminForm = new MenuForm(level);
                                        adminForm.Show();
                                        adminForm.SetUsernameLabel(username);
                                        this.Hide();
                                        break;
                                    case "public":
                                        // Akses publik: sembunyikan tombol tertentu dan tampilan transaksi
                                        MenuForm publicForm = new MenuForm(level);
                                        // Sesuaikan DashboardForm untuk menyembunyikan/menonaktifkan elemen tertentu
                                        publicForm.Show();
                                        publicForm.SetUsernameLabel(username);
                                        this.Hide();
                                        break;
                                    case "kasir":
                                        // Akses publik: sembunyikan tombol tertentu dan tampilan transaksi
                                        MenuForm kasirForm = new MenuForm(level);
                                        // Sesuaikan DashboardForm untuk menyembunyikan/menonaktifkan elemen tertentu
                                        kasirForm.Show();
                                        kasirForm.SetUsernameLabel(username);
                                        this.Hide();
                                        break;
                                    default:
                                        MessageBox.Show("Akses ditolak");
                                        return;
                                }
                            }
                            else
                            {
                                MessageBox.Show("Username atau password salah");
                                // Membersihkan isian txtPassword & txtUsername
                                txtPassword.Clear();
                                txtUsername.Clear();
                                // Fokus kembali ke txtUsername
                                txtUsername.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Username tidak ditemukan");
                            // Membersihkan isian txtPassword & txtUsername
                            txtPassword.Clear();
                            txtUsername.Clear();
                            // Fokus kembali ke txtUsername
                            txtUsername.Focus();
                        }
                    }
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
