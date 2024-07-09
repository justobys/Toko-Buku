using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjectUAS1
{
    public partial class LoginForm : Form
    {
        public static string currentUsername; // Tambahkan ini untuk menyimpan username
        public static string currentPassword;

        public LoginForm()
        {
            InitializeComponent();
            txtUsername.Focus();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
                            string storedPassword = reader["password"].ToString();
                            string enteredPassword = txtPassword.Text;

                            if (enteredPassword == storedPassword)
                            {
                                currentUsername = reader["username"].ToString();
                                string level = reader["level"].ToString();
                                MenuForm menuForm = new MenuForm(currentUsername, level);
                                menuForm.Show();
                                menuForm.SetUsernameLabel(currentUsername);
                                this.Hide();
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
    }
}