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

namespace ProjectUAS1.Frm
{
    public partial class FormUserProfile : Form
    {
        private string currentUsername;

        public FormUserProfile(string username)
        {
            InitializeComponent();
            currentUsername = username;
            txtPasswordLama.Focus();

            // Tambahkan pemeriksaan untuk memastikan username diteruskan dengan benar
            if (!string.IsNullOrEmpty(currentUsername))
            {
                txtUsername.Text = currentUsername;
            }
            else
            {
                MessageBox.Show("Username tidak tersedia.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            if (txtPasswordBaru.Text == txtKonfirmasiPassword.Text)
            {
                bool result = UpdatePassword(currentUsername, txtPasswordLama.Text, txtPasswordBaru.Text);
                if (result)
                {
                    MessageBox.Show("Password berhasil diubah.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password lama salah atau error lainnya.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Password baru dan konfirmasi tidak cocok.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private bool UpdatePassword(string username, string oldPassword, string newPassword)
        {
            string connectionString = "server=localhost;user=root;password=;database=db_tokobuku;";
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT password FROM tbl_user WHERE username=@username";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string storedPassword = reader["password"].ToString();
                            if (storedPassword == oldPassword)
                            {
                                reader.Close();
                                query = "UPDATE tbl_user SET password=@newPassword WHERE username=@username";
                                cmd.CommandText = query;
                                cmd.Parameters.AddWithValue("@newPassword", newPassword);
                                cmd.ExecuteNonQuery();
                                return true;
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBatal_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}