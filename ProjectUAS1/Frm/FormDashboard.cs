using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ProjectUAS1.Frm
{
    public partial class FormDashboard : Form
    {
        string connectionString = "server=localhost;user=root;password=;database=db_tokobuku;";
        private string userRole;
        public FormDashboard(string role)
        {
            InitializeComponent();
            userRole = role;
            IsiComboBoxKategori();
            btnTambah.Visible = btnHapus.Visible = btnEdit.Visible = role == "admin";
            pnlTotalBuku.Visible = pnlTotalTransaksi.Visible = pnlStockBuku.Visible = role == "admin";

            if (role == "public")
            {
                btnCari.Location = new Point(19, 99);
                dgvTableBuku.Location = new Point(19, 150);
                dgvTableBuku.Size = new Size(761, 480);
                lblProfit.Visible = txtProfit.Visible = label10.Visible = false; // Sembunyikan komponen profit
            }

            dgvTableBuku.CellClick += new DataGridViewCellEventHandler(dgvTableBuku_CellClick);
            IsiDataGridView();
            txtID.Text = GenerateIdBuku();
        }

        // Generate idBuku
        private string GenerateIdBuku()
        {
            string lastId = GetLastIdFromDatabase();
            if (string.IsNullOrEmpty(lastId))
            {
                return "IB001";
            }
            int numberPart = int.Parse(lastId.Substring(2));
            numberPart += 1;
            return "IB" + numberPart.ToString("D3");
        }

        private string GetLastIdFromDatabase()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT idBuku FROM tbl_buku ORDER BY id DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                return result == null ? null : result.ToString();
            }
        }

        //Method untuk menampilkan data didalam DGV
        void IsiDataGridView()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT tbl_buku.idBuku, tbl_buku.judul_buku, tbl_buku.author, tbl_kategori.kategori, 
                         tbl_buku.jumlah, tbl_buku.harga, tbl_buku.harga_jual, tbl_buku.profit, tbl_buku.lokasi_buku 
                         FROM tbl_buku 
                         INNER JOIN tbl_kategori ON tbl_buku.id_kategori = tbl_kategori.id_kategori";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvTableBuku.DataSource = dt;

                if (userRole == "public")
                {
                    dgvTableBuku.Columns["harga"].Visible = false;
                    dgvTableBuku.Columns["profit"].Visible = false;
                    dgvTableBuku.Columns["harga_jual"].HeaderText = "Harga";
                }

                dgvTableBuku.Columns["idBuku"].HeaderText = "ID";
                dgvTableBuku.Columns["judul_buku"].HeaderText = "Judul Buku";
                dgvTableBuku.Columns["author"].HeaderText = "Author";
                dgvTableBuku.Columns["kategori"].HeaderText = "Kategori";
                dgvTableBuku.Columns["jumlah"].HeaderText = "Stock";
                dgvTableBuku.Columns["harga"].HeaderText = "Harga";
                dgvTableBuku.Columns["harga_jual"].HeaderText = "Harga Jual";
                dgvTableBuku.Columns["profit"].HeaderText = "Profit";
                dgvTableBuku.Columns["lokasi_buku"].HeaderText = "Lokasi Buku";

                dgvTableBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvTableBuku.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                dgvTableBuku.DefaultCellStyle.Font = new Font("Poppins", 10);
                dgvTableBuku.ColumnHeadersDefaultCellStyle.Font = new Font("Poppins", 10, FontStyle.Bold);
                dgvTableBuku.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
                dgvTableBuku.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvTableBuku.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                dgvTableBuku.Columns["harga"].DefaultCellStyle.Format = "C0";
                dgvTableBuku.Columns["harga"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("id-ID");
                dgvTableBuku.Columns["harga_jual"].DefaultCellStyle.Format = "C0";
                dgvTableBuku.Columns["harga_jual"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("id-ID");
                dgvTableBuku.Columns["profit"].DefaultCellStyle.Format = "C0";
                dgvTableBuku.Columns["profit"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("id-ID");
            }
        }

        //Method untuk mengambil data kategori dan dimasukkan kedalam combobox
        void IsiComboBoxKategori()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM tbl_kategori";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                Dictionary<string, int> kategoriItems = new Dictionary<string, int>();
                while (reader.Read())
                {
                    kategoriItems.Add(reader["kategori"].ToString(), Convert.ToInt32(reader["id_kategori"]));
                }
                cmbKategori.DataSource = new BindingSource(kategoriItems, null);
                cmbKategori.DisplayMember = "Key";
                cmbKategori.ValueMember = "Value";
            }
        }

        //Method untuk menambahkan buku
        void TambahBuku(string id_buku, string judul_buku, string author, int id_kategori, int jumlah, decimal harga, decimal profit, decimal harga_jual, string lokasi_buku)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"INSERT INTO tbl_buku (idBuku, judul_buku, author, id_kategori, jumlah, harga, profit, harga_jual, lokasi_buku) 
                         VALUES (@idBuku, @judul, @author, @kategori, @jumlah, @harga, @profit, @harga_jual, @lokasi_buku)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idBuku", id_buku);
                cmd.Parameters.AddWithValue("@judul", judul_buku);
                cmd.Parameters.AddWithValue("@author", author);
                cmd.Parameters.AddWithValue("@kategori", id_kategori);
                cmd.Parameters.AddWithValue("@jumlah", jumlah);
                cmd.Parameters.AddWithValue("@harga", harga);
                cmd.Parameters.AddWithValue("@profit", profit);
                cmd.Parameters.AddWithValue("@harga_jual", harga_jual);
                cmd.Parameters.AddWithValue("@lokasi_buku", lokasi_buku);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data berhasil ditambahkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInput();
                IsiDataGridView();
            }
        }


        void UbahBuku(string id_buku, string judul_buku, string author, int id_kategori, int jumlah, decimal harga, decimal profit, decimal harga_jual, string lokasi_buku)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"UPDATE tbl_buku 
                         SET judul_buku = @judul, author = @author, id_kategori = @kategori, jumlah = @jumlah, 
                             harga = @harga, profit = @profit, harga_jual = @harga_jual, lokasi_buku = @lokasi_buku
                         WHERE idBuku = @idBuku";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idBuku", id_buku);
                cmd.Parameters.AddWithValue("@judul", judul_buku);
                cmd.Parameters.AddWithValue("@author", author);
                cmd.Parameters.AddWithValue("@kategori", id_kategori);
                cmd.Parameters.AddWithValue("@jumlah", jumlah);
                cmd.Parameters.AddWithValue("@harga", harga);
                cmd.Parameters.AddWithValue("@profit", profit);
                cmd.Parameters.AddWithValue("@harga_jual", harga_jual);
                cmd.Parameters.AddWithValue("@lokasi_buku", lokasi_buku);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data berhasil diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInput();
                IsiDataGridView();
            }
        }


        //Method Hapus
        // Fungsi untuk menghapus buku
        void HapusBuku(string id_buku)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"DELETE FROM tbl_buku WHERE idBuku = @idBuku";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idBuku", id_buku);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Data berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearInput();
                IsiDataGridView();
            }
        }


        DataTable CariBuku(string judul_buku, string author, string kategori)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT tbl_buku.idBuku, tbl_buku.judul_buku, tbl_buku.author, tbl_kategori.kategori, 
                                 tbl_buku.jumlah, tbl_buku.harga 
                                 FROM tbl_buku 
                                 INNER JOIN tbl_kategori ON tbl_buku.id_kategori = tbl_kategori.id_kategori 
                                 WHERE (@judul = '' OR tbl_buku.judul_buku LIKE @judul) AND 
                                       (@author = '' OR tbl_buku.author LIKE @author) AND 
                                       (@kategori = '' OR tbl_kategori.kategori LIKE @kategori)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@judul", string.IsNullOrEmpty(judul_buku) ? "" : "%" + judul_buku + "%");
                cmd.Parameters.AddWithValue("@author", string.IsNullOrEmpty(author) ? "" : "%" + author + "%");
                cmd.Parameters.AddWithValue("@kategori", string.IsNullOrEmpty(kategori) ? "" : "%" + kategori + "%");
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }

        private void dgvTableBuku_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dgvTableBuku.Rows[e.RowIndex];
                    if (row != null)
                    {
                        txtID.Text = row.Cells["idBuku"]?.Value?.ToString();
                        txtJudulBuku.Text = row.Cells["judul_buku"]?.Value?.ToString();
                        txtAuthor.Text = row.Cells["author"]?.Value?.ToString();
                        cmbKategori.Text = row.Cells["kategori"]?.Value?.ToString();
                        txtJumlah.Text = row.Cells["jumlah"]?.Value?.ToString();
                        txtLokasiBuku.Text = row.Cells["lokasi_buku"]?.Value.ToString();

                        if (userRole == "public")
                        {
                            txtHarga.Text = row.Cells["harga_jual"]?.Value?.ToString();
                        }
                        else
                        {
                            txtHarga.Text = row.Cells["harga"]?.Value?.ToString();
                        }
                    }
                }
            }
            catch (NullReferenceException ex)
            {
                MessageBox.Show("Terjadi kesalahan saat mengambil data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnTambah_Click(object sender, EventArgs e)
        {
            // Validasi input
            if (string.IsNullOrWhiteSpace(txtID.Text) ||
                string.IsNullOrWhiteSpace(txtJudulBuku.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                cmbKategori.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtJumlah.Text) ||
                string.IsNullOrWhiteSpace(txtHarga.Text) ||
                string.IsNullOrWhiteSpace(txtProfit.Text) ||
                string.IsNullOrWhiteSpace(txtLokasiBuku.Text))
            {
                MessageBox.Show("Semua kolom wajib diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int jumlah;
            decimal harga, profitPercent, profit, harga_jual;

            // Validasi angka untuk jumlah, harga, dan profit
            if (!int.TryParse(txtJumlah.Text, out jumlah) ||
                !decimal.TryParse(txtHarga.Text, out harga) ||
                !decimal.TryParse(txtProfit.Text, out profitPercent))
            {
                MessageBox.Show("Jumlah, Harga, dan Profit harus diisi dengan angka yang valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Dapatkan data dari input form
            string id_buku = txtID.Text;
            string judul_buku = txtJudulBuku.Text;
            string author = txtAuthor.Text;
            int id_kategori = ((KeyValuePair<string, int>)cmbKategori.SelectedItem).Value;
            string lokasi_buku = txtLokasiBuku.Text;

            // Hitung profit sebagai persentase dari harga
            profit = harga * (profitPercent / 100);

            // Hitung harga_jual
            harga_jual = harga + profit;

            try
            {
                // Panggil metode TambahBuku
                TambahBuku(id_buku, judul_buku, author, id_kategori, jumlah, harga, profit, harga_jual, lokasi_buku);
                MessageBox.Show("Buku berhasil ditambahkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Validasi input
            if (string.IsNullOrWhiteSpace(txtID.Text) ||
                string.IsNullOrWhiteSpace(txtJudulBuku.Text) ||
                string.IsNullOrWhiteSpace(txtAuthor.Text) ||
                cmbKategori.SelectedIndex == -1 ||
                string.IsNullOrWhiteSpace(txtJumlah.Text) ||
                string.IsNullOrWhiteSpace(txtHarga.Text) ||
                string.IsNullOrWhiteSpace(txtProfit.Text) ||
                string.IsNullOrWhiteSpace(txtLokasiBuku.Text))
            {
                MessageBox.Show("Semua kolom wajib diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int jumlah;
            decimal harga, profitPercent, profit, harga_jual;

            // Validasi angka untuk jumlah, harga, dan profit
            if (!int.TryParse(txtJumlah.Text, out jumlah) ||
                !decimal.TryParse(txtHarga.Text, out harga) ||
                !decimal.TryParse(txtProfit.Text, out profitPercent))
            {
                MessageBox.Show("Jumlah, Harga, dan Profit harus diisi dengan angka yang valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Dapatkan data dari input form
            string id_buku = txtID.Text;
            string judul_buku = txtJudulBuku.Text;
            string author = txtAuthor.Text;
            int id_kategori = ((KeyValuePair<string, int>)cmbKategori.SelectedItem).Value;
            string lokasi_buku = txtLokasiBuku.Text;

            // Hitung profit sebagai persentase dari harga
            profit = harga * (profitPercent / 100);

            // Hitung harga_jual
            harga_jual = harga + profit;

            try
            {
                // Panggil metode UbahBuku
                UbahBuku(id_buku, judul_buku, author, id_kategori, jumlah, harga, profit, harga_jual, lokasi_buku);
                MessageBox.Show("Buku berhasil diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string judul_buku = txtJudulBuku.Text;
            string author = txtAuthor.Text;
            string kategori = cmbKategori.Text;

            DataTable hasilPencarian = CariBuku(judul_buku, author, kategori);
            dgvTableBuku.DataSource = hasilPencarian;
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            // Dapatkan ID buku dari input form
            string id_buku = txtID.Text;

            // Konfirmasi penghapusan
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin menghapus data buku ini?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Panggil metode HapusBuku
                HapusBuku(id_buku);
            }
        }

        private void ClearInput()
        {
            txtID.Text = GenerateIdBuku();
            txtJudulBuku.Clear();
            txtAuthor.Clear();
            cmbKategori.SelectedIndex = -1;
            txtJumlah.Clear();
            txtHarga.Clear();
            txtProfit.Clear();
            txtLokasiBuku.Clear(); // Tambahkan ini
        }


        //Menhitung Total Buku, Total Transaksi, Stock Buku
        int HitungTotalBuku()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM tbl_buku";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                object result = cmd.ExecuteScalar();
                return result == DBNull.Value ? 0 : Convert.ToInt32(result);
            }
        }

        int HitungTotalTransaksi()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM tbl_transaksi";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                object result = cmd.ExecuteScalar();
                return result == DBNull.Value ? 0 : Convert.ToInt32(result);
            }
        }

        int HitungStockBuku()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT SUM(jumlah) FROM tbl_buku";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                object result = cmd.ExecuteScalar();
                return result == DBNull.Value ? 0 : Convert.ToInt32(result);
            }
        }

        private void FormDashboard_Load(object sender, EventArgs e)
        {
            lblTotalBuku.Text = HitungTotalBuku().ToString();
            lblTotalTransaksi.Text = HitungTotalTransaksi().ToString();
            lblStockBuku.Text = HitungStockBuku().ToString();
        }
    }
}
