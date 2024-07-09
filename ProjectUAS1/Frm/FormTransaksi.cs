using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Globalization;
using System.Windows.Forms;

namespace ProjectUAS1.Frm
{
    public partial class FormTransaksi : Form
    {
        string connectionString = "server=localhost;user=root;password=;database=db_tokobuku;";
        private TransaksiData lastTransaksi;
        private PrintDocument printDocument1 = new PrintDocument();
        private PrintPreviewDialog printPreviewDialog1 = new PrintPreviewDialog();

        public FormTransaksi()
        {
            InitializeComponent();
            txtIDTransaksi.Text = GenerateIdTransaksi();
            IsiListBuku();
            IsiPembayaranBuku();
        }

        private string GenerateIdTransaksi()
        {
            string lastId = GetLastIdFromDatabase();

            // Generate new transaction ID
            if (string.IsNullOrEmpty(lastId) || lastId.Length < 3)
            {
                return "IDT001";
            }

            if (!int.TryParse(lastId.Substring(3), out int numberPart))
            {
                MessageBox.Show("Invalid last ID!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return "IDT001";
            }

            numberPart += 1;

            return "IDT" + numberPart.ToString("D3");
        }

        private string GetLastIdFromDatabase()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT idTransaksi FROM tbl_transaksi ORDER BY idTransaksi DESC LIMIT 1";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                object result = cmd.ExecuteScalar();
                return result == null ? null : result.ToString();
            }
        }

        void IsiListBuku()
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT idBuku, judul_buku, jumlah, harga_jual FROM tbl_buku";

                    using (MySqlDataAdapter da = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvListBuku.DataSource = dt;

                        dgvListBuku.Columns["idBuku"].HeaderText = "ID";
                        dgvListBuku.Columns["judul_buku"].HeaderText = "Judul Buku";
                        dgvListBuku.Columns["jumlah"].HeaderText = "Jumlah";
                        dgvListBuku.Columns["harga_jual"].HeaderText = "Harga";

                        dgvListBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        dgvListBuku.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
                        dgvListBuku.DefaultCellStyle.Font = new Font("Poppins", 10);
                        dgvListBuku.ColumnHeadersDefaultCellStyle.Font = new Font("Poppins", 10, FontStyle.Bold);
                        dgvListBuku.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
                        dgvListBuku.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                        dgvListBuku.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                        dgvListBuku.Columns["harga_jual"].DefaultCellStyle.Format = "C0";
                        dgvListBuku.Columns["harga_jual"].DefaultCellStyle.FormatProvider = CultureInfo.GetCultureInfo("id-ID");
                    }
                }
                catch (MySqlException sqlEx)
                {
                    MessageBox.Show("Database connection error: " + sqlEx.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void IsiPembayaranBuku()
        {
            dgvPembayaranBuku.Columns.Clear();
            dgvPembayaranBuku.Columns.AddRange(
                new DataGridViewTextBoxColumn { Name = "idBuku", HeaderText = "ID Buku" },
                new DataGridViewTextBoxColumn { Name = "judulBuku", HeaderText = "Judul Buku" },
                new DataGridViewTextBoxColumn { Name = "jumlah", HeaderText = "Jumlah" },
                new DataGridViewTextBoxColumn { Name = "harga", HeaderText = "Harga Satuan" },
                new DataGridViewTextBoxColumn { Name = "total", HeaderText = "Total Harga" }
            );

            dgvPembayaranBuku.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPembayaranBuku.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgvPembayaranBuku.DefaultCellStyle.Font = new Font("Poppins", 9);
            dgvPembayaranBuku.ColumnHeadersDefaultCellStyle.Font = new Font("Poppins", 9, FontStyle.Bold);
            dgvPembayaranBuku.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
            dgvPembayaranBuku.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvPembayaranBuku.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgvPembayaranBuku.EditMode = DataGridViewEditMode.EditProgrammatically;
        }

        private void dgvListBuku_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvListBuku.Rows[e.RowIndex] != null)
            {
                DataGridViewRow row = dgvListBuku.Rows[e.RowIndex];
                txtIDBuku.Text = row.Cells["idBuku"]?.Value?.ToString();
                txtJudulBuku.Text = row.Cells["judul_buku"]?.Value?.ToString();
                txtHarga.Text = row.Cells["harga_jual"]?.Value?.ToString();
            }
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string idBuku = txtIDBuku.Text.Trim();

            if (string.IsNullOrWhiteSpace(idBuku))
            {
                MessageBox.Show("ID Buku tidak boleh kosong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = "SELECT idBuku, judul_buku, jumlah, harga_jual FROM tbl_buku WHERE idBuku LIKE @id_buku OR judul_buku LIKE @id_buku";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id_buku", "%" + idBuku + "%");

                    try
                    {
                        conn.Open();
                        using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            if (dt.Rows.Count > 0)
                            {
                                dgvListBuku.DataSource = dt;
                                IsiListBuku();
                                DataRow firstRow = dt.Rows[0];
                                txtIDBuku.Text = firstRow["idBuku"].ToString();
                                txtJudulBuku.Text = firstRow["judul_buku"].ToString();
                                txtHarga.Text = firstRow["harga_jual"].ToString();
                            }
                            else
                            {
                                MessageBox.Show("Buku tidak ditemukan!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                dgvListBuku.DataSource = null;
                            }
                        }
                    }
                    catch (MySqlException sqlEx)
                    {
                        MessageBox.Show("Database error: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool isJumlahValid = true;

        private void btnTambah_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtJudulBuku.Text) ||
                string.IsNullOrWhiteSpace(txtJumlahBuku.Text) ||
                string.IsNullOrWhiteSpace(txtHarga.Text))
            {
                MessageBox.Show("Semua kolom buku wajib diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(txtJumlahBuku.Text, out int jumlah))
            {
                if (isJumlahValid)
                {
                    MessageBox.Show("Jumlah harus berupa angka yang valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    isJumlahValid = false; // Set flag to false after displaying the message
                }
                return;
            }

            // Reset flag after valid input
            isJumlahValid = true;

            if (!decimal.TryParse(txtHarga.Text, out decimal harga))
            {
                MessageBox.Show("Harga harus berupa angka yang valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (jumlah <= 0)
            {
                MessageBox.Show("Jumlah harus lebih besar dari 0!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (harga <= 0)
            {
                MessageBox.Show("Harga harus lebih besar dari 0!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            foreach (DataGridViewRow row in dgvPembayaranBuku.Rows)
            {
                if (row.Cells["idBuku"].Value?.ToString() == txtIDBuku.Text)
                {
                    MessageBox.Show("Buku sudah ditambahkan ke daftar pembayaran!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Add book to DataGridView pembayaran buku
            dgvPembayaranBuku.Rows.Add(txtIDBuku.Text,
                                        txtJudulBuku.Text,
                                        jumlah.ToString(),
                                        harga.ToString("C0", CultureInfo.GetCultureInfo("id-ID")),
                                        (jumlah * harga).ToString("C0", CultureInfo.GetCultureInfo("id-ID")));

            // Reduce book quantity in database
            if (KurangiJumlahBuku(txtIDBuku.Text, jumlah))
            {
                IsiListBuku();
                HitungTotalHarga();
                ClearInput();
            }
        }


        private bool KurangiJumlahBuku(string idBuku, int jumlah)
        {
            string query = "UPDATE tbl_buku SET jumlah = jumlah - @jumlah WHERE idBuku = @idBuku";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idBuku", idBuku);
                cmd.Parameters.AddWithValue("@jumlah", jumlah);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Jumlah buku tidak cukup!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }
                catch (MySqlException sqlEx)
                {
                    MessageBox.Show("Error mengurangi jumlah buku: " + sqlEx.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void HitungTotalHarga()
        {
            decimal totalHarga = 0;

            foreach (DataGridViewRow row in dgvPembayaranBuku.Rows)
            {
                if (row.Cells["total"].Value != null)
                {
                    if (decimal.TryParse(row.Cells["total"].Value.ToString(), NumberStyles.Currency, CultureInfo.GetCultureInfo("id-ID"), out decimal hargaTotal))
                    {
                        totalHarga += hargaTotal;
                    }
                    else
                    {
                        MessageBox.Show("Error menghitung total harga!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            txtTotalHarga.Text = totalHarga.ToString("C0", CultureInfo.GetCultureInfo("id-ID"));
        }

        void ClearInput()
        {
            txtIDBuku.Clear();
            txtJudulBuku.Clear();
            txtJumlahBuku.Clear();
            txtHarga.Clear();
        }

        private void HitungKembalian()
        {
            decimal totalTransaksi;
            decimal bayar;

            if (!decimal.TryParse(txtTotalHarga.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("id-ID"), out totalTransaksi))
            {
                MessageBox.Show("Total transaksi harus berupa angka yang valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtBayar.Text, out bayar))
            {
                MessageBox.Show("Bayar harus berupa angka yang valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal kembalian = bayar - totalTransaksi;
            txtKembalian.Text = kembalian.ToString("C0", CultureInfo.GetCultureInfo("id-ID"));
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            ClearInput();
        }

        private void txtBayar_TextChanged(object sender, EventArgs e)
        {
            HitungKembalian();
        }

        private void btnBayar_Click(object sender, EventArgs e)
        {
            if (dgvPembayaranBuku.Rows.Count == 0)
            {
                MessageBox.Show("Belum ada buku yang ditambahkan ke pembayaran!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtBayar.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("id-ID"), out decimal pembayaran))
            {
                MessageBox.Show("Pembayaran tidak valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!decimal.TryParse(txtTotalHarga.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("id-ID"), out decimal total_transaksi))
            {
                MessageBox.Show("Total transaksi tidak valid!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            decimal kembalian = pembayaran - total_transaksi;
            if (kembalian < 0)
            {
                MessageBox.Show("Pembayaran kurang!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string insertQuery = "INSERT INTO tbl_transaksi (idTransaksi, tanggal, total_transaksi, pembayaran, kembalian) VALUES (@idTransaksi, @tanggal, @total_transaksi, @pembayaran, @kembalian)";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    MySqlCommand insertCmd = new MySqlCommand(insertQuery, conn, transaction);
                    insertCmd.Parameters.AddWithValue("@idTransaksi", txtIDTransaksi.Text);
                    insertCmd.Parameters.AddWithValue("@tanggal", DateTime.Now);
                    insertCmd.Parameters.AddWithValue("@total_transaksi", total_transaksi);
                    insertCmd.Parameters.AddWithValue("@pembayaran", pembayaran);
                    insertCmd.Parameters.AddWithValue("@kembalian", kembalian);
                    insertCmd.ExecuteNonQuery();

                    foreach (DataGridViewRow row in dgvPembayaranBuku.Rows)
                    {
                        if (row.Cells["idBuku"].Value != null)
                        {
                            string idBuku = row.Cells["idBuku"].Value.ToString();
                            int jumlah = Convert.ToInt32(row.Cells["jumlah"].Value);

                            string updateStokQuery = "UPDATE tbl_buku SET jumlah = jumlah - @jumlah WHERE idBuku = @idBuku";

                            MySqlCommand updateStokCmd = new MySqlCommand(updateStokQuery, conn, transaction);
                            updateStokCmd.Parameters.AddWithValue("@jumlah", jumlah);
                            updateStokCmd.Parameters.AddWithValue("@idBuku", idBuku);
                            updateStokCmd.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit();
                    MessageBox.Show("Pembayaran berhasil! Stok buku telah diperbarui.", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearInput();
                }
                catch (MySqlException sqlEx)
                {
                    transaction.Rollback();
                    MessageBox.Show("Database error: " + sqlEx.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void ResetFormTransaksi()
        {
            txtIDTransaksi.Text = GenerateIdTransaksi();
            txtIDBuku.Clear();
            txtJudulBuku.Clear();
            txtJumlahBuku.Clear();
            txtHarga.Clear();
            txtTotalHarga.Clear();
            txtBayar.Clear();
            txtKembalian.Clear();


            // Iterate through each row in dgvPembayaranBuku
            foreach (DataGridViewRow row in dgvPembayaranBuku.Rows)
            {
                if (row.Cells["idBuku"].Value != null && row.Cells["jumlah"].Value != null)
                {
                    string idBuku = row.Cells["idBuku"].Value.ToString();
                    int jumlah = Convert.ToInt32(row.Cells["jumlah"].Value);

                    // Call TambahJumlahBuku to increase book quantity
                    if (!TambahJumlahBuku(idBuku, jumlah))
                    {
                        MessageBox.Show("Gagal mengembalikan jumlah buku untuk ID: " + idBuku, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return; // Stop reset process if failed to increase book quantity
                    }
                }
            }

            // Clear DataGridView pembayaran buku after resetting
            dgvPembayaranBuku.Rows.Clear();

            // Refresh list of books in DataGridView list buku
            IsiListBuku();
        }

        private bool TambahJumlahBuku(string idBuku, int jumlah)
        {
            string query = "UPDATE tbl_buku SET jumlah = jumlah + @jumlah WHERE idBuku = @idBuku";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@idBuku", idBuku);
                cmd.Parameters.AddWithValue("@jumlah", jumlah);

                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Gagal mengembalikan jumlah buku untuk ID: " + idBuku, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                catch (MySqlException sqlEx)
                {
                    MessageBox.Show("Error menambah jumlah buku: " + sqlEx.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }

        private void FormTransaksi_Load(object sender, EventArgs e)
        {
            txtBayar.TextChanged += new EventHandler(txtBayar_TextChanged);
            txtBayar.KeyPress += new KeyPressEventHandler(txtBayar_KeyPress);
        }

        private void txtBayar_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFormTransaksi();
        }

        public class TransaksiData
        {
            public string IdTransaksi { get; set; }
            public DateTime Tanggal { get; set; }
            public decimal TotalTransaksi { get; set; }
            public decimal Pembayaran { get; set; }
            public decimal Kembalian { get; set; }
            public List<DetailTransaksi> DetailTransaksi { get; set; }
        }

        public class DetailTransaksi
        {
            public string IdBuku { get; set; }
            public string JudulBuku { get; set; }
            public int Jumlah { get; set; }
            public decimal Harga { get; set; }
            public decimal Total { get; set; }
        }

        private void btnCetak_Click(object sender, EventArgs e)
        {
            if (dgvPembayaranBuku.Rows.Count == 0)
            {
                MessageBox.Show("Tidak ada data transaksi yang dapat dicetak!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Simpan data transaksi ke dalam objek TransaksiData
            lastTransaksi = new TransaksiData
            {
                IdTransaksi = txtIDTransaksi.Text,
                Tanggal = DateTime.Now,
                TotalTransaksi = decimal.Parse(txtTotalHarga.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("id-ID")),
                Pembayaran = decimal.Parse(txtBayar.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("id-ID")),
                Kembalian = decimal.Parse(txtKembalian.Text, NumberStyles.Currency, CultureInfo.GetCultureInfo("id-ID")),
                DetailTransaksi = new List<DetailTransaksi>()
            };

            foreach (DataGridViewRow row in dgvPembayaranBuku.Rows)
            {
                if (row.Cells["idBuku"].Value != null)
                {
                    lastTransaksi.DetailTransaksi.Add(new DetailTransaksi
                    {
                        IdBuku = row.Cells["idBuku"].Value.ToString(),
                        JudulBuku = row.Cells["judulBuku"].Value.ToString(),
                        Jumlah = int.Parse(row.Cells["jumlah"].Value.ToString()),
                        Harga = decimal.Parse(row.Cells["harga"].Value.ToString(), NumberStyles.Currency, CultureInfo.GetCultureInfo("id-ID")),
                        Total = decimal.Parse(row.Cells["total"].Value.ToString(), NumberStyles.Currency, CultureInfo.GetCultureInfo("id-ID"))
                    });
                }
            }

            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Set up fonts
            Font fontRegular = new Font("Arial", 10, FontStyle.Regular);
            Font fontBold = new Font("Arial", 10, FontStyle.Bold);
            Font fontTitle = new Font("Arial", 12, FontStyle.Bold);

            // Set up margins and positions
            int leftMargin = 50;
            int topMargin = 20;
            int lineHeight = fontRegular.Height + 5;
            int rightAlign = e.PageBounds.Width - 50;

            // Drawing title
            e.Graphics.DrawString("Toko Buku Sejahtera", fontTitle, Brushes.Black, new Rectangle(leftMargin, topMargin, e.PageBounds.Width - 100, lineHeight), new StringFormat() { Alignment = StringAlignment.Center });
            topMargin += lineHeight;

            // Store info
            e.Graphics.DrawString("Jl. Buku No. 123, Jakarta", fontRegular, Brushes.Black, new Rectangle(leftMargin, topMargin, e.PageBounds.Width - 100, lineHeight), new StringFormat() { Alignment = StringAlignment.Center });
            topMargin += lineHeight;
            e.Graphics.DrawString("Tel: 081234567890", fontRegular, Brushes.Black, new Rectangle(leftMargin, topMargin, e.PageBounds.Width - 100, lineHeight), new StringFormat() { Alignment = StringAlignment.Center });
            topMargin += lineHeight * 2;

            // Transaction info
            e.Graphics.DrawString($"Tanggal: {DateTime.Now:dd-MM-yyyy HH:mm}", fontRegular, Brushes.Black, leftMargin, topMargin);
            topMargin += lineHeight;
            e.Graphics.DrawString($"ID Transaksi: {txtIDTransaksi.Text}", fontRegular, Brushes.Black, leftMargin, topMargin);
            topMargin += lineHeight * 2;

            // Drawing header for the items
            e.Graphics.DrawString("Qty", fontBold, Brushes.Black, leftMargin, topMargin);
            e.Graphics.DrawString("Item", fontBold, Brushes.Black, leftMargin + 30, topMargin);
            e.Graphics.DrawString("Harga", fontBold, Brushes.Black, rightAlign - 100, topMargin, new StringFormat() { Alignment = StringAlignment.Far });
            e.Graphics.DrawString("Total", fontBold, Brushes.Black, rightAlign, topMargin, new StringFormat() { Alignment = StringAlignment.Far });
            topMargin += lineHeight;

            // Drawing the separator
            e.Graphics.DrawLine(Pens.Black, leftMargin, topMargin, rightAlign, topMargin);
            topMargin += 2;

            // Drawing items
            foreach (DataGridViewRow row in dgvPembayaranBuku.Rows)
            {
                string qty = row.Cells["jumlah"].Value?.ToString() ?? "0";
                string item = row.Cells["judulBuku"].Value?.ToString() ?? "N/A";
                string harga = row.Cells["harga"].Value?.ToString() ?? "0";
                string total = row.Cells["total"].Value?.ToString() ?? "0";

                e.Graphics.DrawString(qty, fontRegular, Brushes.Black, leftMargin, topMargin);
                e.Graphics.DrawString(item, fontRegular, Brushes.Black, leftMargin + 30, topMargin);
                e.Graphics.DrawString(harga, fontRegular, Brushes.Black, rightAlign - 100, topMargin, new StringFormat() { Alignment = StringAlignment.Far });
                e.Graphics.DrawString(total, fontRegular, Brushes.Black, rightAlign, topMargin, new StringFormat() { Alignment = StringAlignment.Far });
                topMargin += lineHeight;
            }

            // Drawing the separator
            e.Graphics.DrawLine(Pens.Black, leftMargin, topMargin, rightAlign, topMargin);
            topMargin += lineHeight;

            // Drawing totals
            e.Graphics.DrawString("Total Belanja", fontBold, Brushes.Black, leftMargin, topMargin);
            e.Graphics.DrawString(txtTotalHarga.Text, fontBold, Brushes.Black, rightAlign, topMargin, new StringFormat() { Alignment = StringAlignment.Far });
            topMargin += lineHeight;
            e.Graphics.DrawString("Bayar", fontBold, Brushes.Black, leftMargin, topMargin);
            e.Graphics.DrawString(txtBayar.Text, fontBold, Brushes.Black, rightAlign, topMargin, new StringFormat() { Alignment = StringAlignment.Far });
            topMargin += lineHeight;
            e.Graphics.DrawString("Kembalian", fontBold, Brushes.Black, leftMargin, topMargin);
            e.Graphics.DrawString(txtKembalian.Text, fontBold, Brushes.Black, rightAlign, topMargin, new StringFormat() { Alignment = StringAlignment.Far });
            topMargin += lineHeight * 2;

            // Drawing footer
            e.Graphics.DrawString("Terima Kasih!", fontRegular, Brushes.Black, new Rectangle(leftMargin, topMargin, e.PageBounds.Width - 100, lineHeight), new StringFormat() { Alignment = StringAlignment.Center });
            topMargin += lineHeight;
            e.Graphics.DrawString("Semoga Hari Anda Menyenangkan!", fontRegular, Brushes.Black, new Rectangle(leftMargin, topMargin, e.PageBounds.Width - 100, lineHeight), new StringFormat() { Alignment = StringAlignment.Center });
        }


    }
}
