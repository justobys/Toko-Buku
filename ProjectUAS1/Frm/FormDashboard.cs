using ProjectUAS1.Bantuan;
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
using System.Globalization;

namespace ProjectUAS1.Frm
{
    public partial class FormDashboard : Form
    {

        string connectionString = "server=localhost;user=root;password=;database=db_tokobuku;";
        public FormDashboard(string role)
        {
            InitializeComponent();
            IsiComboBoxKategori();
            btnTambah.Visible = btnHapus.Visible = btnEdit.Visible = role == "admin";
            pnlTotalBuku.Visible = pnlTotalTransaksi.Visible = pnlStockBuku.Visible = role == "admin" ;
            if (role == "public")
            {
                btnCari.Location = new Point(19, 99);
                dgvTableBuku.Location = new Point(19, 150);
                dgvTableBuku.Size = new Size(761, 480);
            }
            // Tambahkan event handler untuk CellClick
            dgvTableBuku.CellClick += new DataGridViewCellEventHandler(dgvTableBuku_CellClick);
            IsiDataGridView();
        }

        //Method untuk menampilkan data didalam DGV
        void IsiDataGridView()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT tbl_buku.id, tbl_buku.judul_buku, tbl_buku.author, tbl_kategori.kategori, tbl_buku.jumlah, tbl_buku.harga FROM tbl_buku INNER JOIN tbl_kategori ON tbl_buku.id_kategori = tbl_kategori.id_kategori";
                MySqlDataAdapter da = new MySqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Set DataGridView source to data table
                dgvTableBuku.DataSource = dt;

                // Rename columns
                dgvTableBuku.Columns["id"].HeaderText = "ID";
                dgvTableBuku.Columns["judul_buku"].HeaderText = "Judul Buku";
                dgvTableBuku.Columns["author"].HeaderText = "Author";
                dgvTableBuku.Columns["kategori"].HeaderText = "Kategori";
                dgvTableBuku.Columns["jumlah"].HeaderText = "Stock";
                dgvTableBuku.Columns["harga"].HeaderText = "Harga";

                // Atur lebar kolom secara otomatis
                dgvTableBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                // Atur AutoSizeMode untuk semua kolom
                dgvTableBuku.Columns["ID"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvTableBuku.Columns["author"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvTableBuku.Columns["kategori"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvTableBuku.Columns["jumlah"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
                dgvTableBuku.Columns["harga"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

                // Atur warna baris bergantian
                dgvTableBuku.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

                // Atur gaya font
                dgvTableBuku.DefaultCellStyle.Font = new Font("Poppins", 10);

                // Atur gaya header
                dgvTableBuku.ColumnHeadersDefaultCellStyle.Font = new Font("Poppins", 10, FontStyle.Bold);
                dgvTableBuku.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
                dgvTableBuku.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;

                // Atur padding
                dgvTableBuku.DefaultCellStyle.Padding = new Padding(1);

                // Atur garis grid
                dgvTableBuku.GridColor = Color.LightBlue;

                // Atur mode seleksi
                dgvTableBuku.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Format kolom harga sebagai mata uang
                dgvTableBuku.Columns["harga"].DefaultCellStyle.Format = "C0";
                dgvTableBuku.Columns["harga"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("id-ID");

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
                    // Asumsi bahwa Anda memiliki kolom 'id_kategori' dan 'nama_kategori' di tbl_kategori
                    kategoriItems.Add(reader["kategori"].ToString(), Convert.ToInt32(reader["id_kategori"]));
                }
                cmbKategori.DataSource = new BindingSource(kategoriItems, null);
                cmbKategori.DisplayMember = "Key";
                cmbKategori.ValueMember = "Value";
            }
        }

        //Method untuk menambahkan buku
        void TambahBuku(string judul_buku, string author, int id_kategori, int jumlah, decimal harga)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO tbl_buku (judul_buku, author, id_kategori, jumlah, harga) VALUES (@judul, @author, @kategori, @jumlah, @harga)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@judul", judul_buku);
                cmd.Parameters.AddWithValue("@author", author);
                cmd.Parameters.AddWithValue("@kategori", id_kategori);
                cmd.Parameters.AddWithValue("@jumlah", jumlah);
                cmd.Parameters.AddWithValue("@harga", harga);
                cmd.ExecuteNonQuery();

                // Tampilkan MessageBox
                MessageBox.Show("Data berhasil ditambahkan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Bersihkan semua input
                txtJudulBuku.Text = "";
                txtAuthor.Text = "";
                cmbKategori.SelectedIndex = -1;
                txtJumlah.Text = "";
                txtHarga.Text = "";
                IsiDataGridView();
            }
        }

        void UbahBuku(int id_buku, string judul_buku, string author, int id_kategori, int jumlah, decimal harga)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE tbl_buku SET author = @author, id_kategori = @kategori, jumlah = @jumlah, harga = @harga, judul_buku = @judul WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id_buku);
                cmd.Parameters.AddWithValue("@judul", judul_buku);
                cmd.Parameters.AddWithValue("@author", author);
                cmd.Parameters.AddWithValue("@kategori", id_kategori);
                cmd.Parameters.AddWithValue("@jumlah", jumlah);
                cmd.Parameters.AddWithValue("@harga", harga);
                cmd.ExecuteNonQuery();

                // Tampilkan MessageBox
                MessageBox.Show("Data berhasil diubah!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Bersihkan semua input
                txtID.Text = "";
                txtJudulBuku.Text = "";
                txtAuthor.Text = "";
                cmbKategori.SelectedIndex = -1;
                txtJumlah.Text = "";
                txtHarga.Text = "";
                IsiDataGridView();
            }
        }

        //Method Hapus
        // Fungsi untuk menghapus buku
        void HapusBuku(int id_buku)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "DELETE FROM tbl_buku WHERE id = @id";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id_buku);
                cmd.ExecuteNonQuery();

                // Tampilkan MessageBox
                MessageBox.Show("Data berhasil dihapus!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Fungsi untuk mencari buku berdasarkan judul, penulis, atau kategori
        DataTable CariBuku(string judul_buku, string author, string kategori)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = @"
    SELECT 
        tbl_buku.id, 
        tbl_buku.judul_buku, 
        tbl_buku.author, 
        tbl_kategori.kategori, 
        tbl_buku.jumlah, 
        tbl_buku.harga 
    FROM 
        tbl_buku 
    INNER JOIN 
        tbl_kategori ON tbl_buku.id_kategori = tbl_kategori.id_kategori 
    WHERE 
        (@judul = '' OR tbl_buku.judul_buku LIKE @judul) AND 
        (@author = '' OR tbl_buku.author LIKE @author) AND 
        (@kategori = '' OR tbl_kategori.kategori LIKE @kategori)";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@judul", judul_buku == "" ? "" : "%" + judul_buku + "%");
                cmd.Parameters.AddWithValue("@author", author == "" ? "" : "%" + author + "%");
                cmd.Parameters.AddWithValue("@kategori", kategori == "" ? "" : "%" + kategori + "%");
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                return dt;
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            string judul_buku = txtJudulBuku.Text;
            string author = txtAuthor.Text;
            int id_kategori = ((KeyValuePair<string, int>)cmbKategori.SelectedItem).Value;
            int jumlah = int.Parse(txtJumlah.Text);
            decimal harga = decimal.Parse(txtHarga.Text);

            // Panggil metode TambahBuku dengan data dari form
            TambahBuku(judul_buku, author, id_kategori, jumlah, harga);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id_buku = int.Parse(txtID.Text);
            string judul_buku = txtJudulBuku.Text;
            string author = txtAuthor.Text;
            int id_kategori = ((KeyValuePair<string, int>)cmbKategori.SelectedItem).Value;
            int jumlah = int.Parse(txtJumlah.Text);
            decimal harga = decimal.Parse(txtHarga.Text);

            // Panggil metode UbahBuku dengan data dari form
            UbahBuku(id_buku, judul_buku, author, id_kategori, jumlah, harga);
        }


        private void dgvTableBuku_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Ambil indeks baris yang diklik
            int rowIndex = e.RowIndex;

            // Pastikan baris yang valid diklik
            if (rowIndex >= 0)
            {
                // Ambil data dari baris yang diklik
                DataGridViewRow row = dgvTableBuku.Rows[rowIndex];

                // Asumsi bahwa Anda memiliki kolom 'judul_buku', 'author', 'kategori', 'jumlah', dan 'harga' di DataGridView
                txtID.Text = row.Cells["id"].Value.ToString();
                txtJudulBuku.Text = row.Cells["judul_buku"].Value.ToString();
                txtAuthor.Text = row.Cells["author"].Value.ToString();
                cmbKategori.SelectedItem = row.Cells["kategori"].Value.ToString();
                txtJumlah.Text = row.Cells["jumlah"].Value.ToString();
                txtHarga.Text = row.Cells["harga"].Value.ToString();
            }
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            // Ambil ID buku dari form
            int id_buku = int.Parse(txtID.Text); // asumsi Anda memiliki TextBox untuk ID buku

            // Panggil metode HapusBuku dengan ID buku dari form
            HapusBuku(id_buku);

            // Muat ulang DataGridView untuk menampilkan data terbaru
            IsiDataGridView();
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string judul_buku = txtJudulBuku.Text;
            string author = txtAuthor.Text;
            string kategori = cmbKategori.Text; // Pastikan ini mengembalikan teks yang benar

            DataTable hasilPencarian = CariBuku(judul_buku, author, kategori);
            dgvTableBuku.DataSource = hasilPencarian;
        }


        //Menhitung Total Buku, Total Transaksi, Stock Buku
        int HitungTotalBuku()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM tbl_buku";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        int HitungTotalTransaksi()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM tbl_transaksi"; //sum(total_transaksi)
                MySqlCommand cmd = new MySqlCommand(query, conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        int HitungStockBuku()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT SUM(jumlah) FROM tbl_buku";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                return Convert.ToInt32(cmd.ExecuteScalar());
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
