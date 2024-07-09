namespace ProjectUAS1.Frm
{
    partial class FormTransaksi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtTotalHarga = new System.Windows.Forms.TextBox();
            this.btnHapus = new System.Windows.Forms.Button();
            this.btnTambah = new System.Windows.Forms.Button();
            this.dgvPembayaranBuku = new System.Windows.Forms.DataGridView();
            this.dgvListBuku = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIDBuku = new System.Windows.Forms.TextBox();
            this.txtJudulBuku = new System.Windows.Forms.TextBox();
            this.txtJumlahBuku = new System.Windows.Forms.TextBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnCetak = new System.Windows.Forms.Button();
            this.btnBayar = new System.Windows.Forms.Button();
            this.txtBayar = new System.Windows.Forms.TextBox();
            this.txtKembalian = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtIDTransaksi = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtHarga = new System.Windows.Forms.TextBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPembayaranBuku)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListBuku)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Poppins Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 40);
            this.label1.TabIndex = 24;
            this.label1.Text = "Judul Buku";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Poppins Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 183);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 40);
            this.label3.TabIndex = 26;
            this.label3.Text = "Jumlah Buku";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Poppins", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(213, 366);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 40);
            this.label4.TabIndex = 35;
            this.label4.Text = "List Buku";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(232, 714);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(263, 22);
            this.dateTimePicker1.TabIndex = 36;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Poppins", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(626, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(231, 40);
            this.label5.TabIndex = 38;
            this.label5.Text = "Pembayaran Buku";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(162)))), ((int)(((byte)(184)))));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(501, 366);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(529, 71);
            this.panel1.TabIndex = 39;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Poppins", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(3, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 40);
            this.label6.TabIndex = 0;
            this.label6.Text = "Bayar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Poppins Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(505, 608);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(154, 40);
            this.label7.TabIndex = 45;
            this.label7.Text = "Kembalian";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Poppins Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(505, 524);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 40);
            this.label8.TabIndex = 43;
            this.label8.Text = "Bayar";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Poppins Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(505, 440);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(166, 40);
            this.label9.TabIndex = 41;
            this.label9.Text = "Total Harga";
            // 
            // txtTotalHarga
            // 
            this.txtTotalHarga.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotalHarga.Location = new System.Drawing.Point(511, 483);
            this.txtTotalHarga.Multiline = true;
            this.txtTotalHarga.Name = "txtTotalHarga";
            this.txtTotalHarga.Size = new System.Drawing.Size(519, 38);
            this.txtTotalHarga.TabIndex = 40;
            // 
            // btnHapus
            // 
            this.btnHapus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnHapus.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnHapus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHapus.FlatAppearance.BorderSize = 0;
            this.btnHapus.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(34)))), ((int)(((byte)(45)))));
            this.btnHapus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHapus.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHapus.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnHapus.Image = global::ProjectUAS1.Properties.Resources.reset_1__1_;
            this.btnHapus.Location = new System.Drawing.Point(173, 296);
            this.btnHapus.Name = "btnHapus";
            this.btnHapus.Size = new System.Drawing.Size(131, 53);
            this.btnHapus.TabIndex = 50;
            this.btnHapus.Text = "Ulang";
            this.btnHapus.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHapus.UseVisualStyleBackColor = false;
            this.btnHapus.Click += new System.EventHandler(this.btnHapus_Click);
            // 
            // btnTambah
            // 
            this.btnTambah.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnTambah.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnTambah.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTambah.FlatAppearance.BorderSize = 0;
            this.btnTambah.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(116)))), ((int)(((byte)(47)))));
            this.btnTambah.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTambah.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTambah.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnTambah.Image = global::ProjectUAS1.Properties.Resources.add_1;
            this.btnTambah.Location = new System.Drawing.Point(12, 296);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(155, 53);
            this.btnTambah.TabIndex = 49;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTambah.UseVisualStyleBackColor = false;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // dgvPembayaranBuku
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPembayaranBuku.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPembayaranBuku.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPembayaranBuku.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPembayaranBuku.Location = new System.Drawing.Point(501, 58);
            this.dgvPembayaranBuku.Name = "dgvPembayaranBuku";
            this.dgvPembayaranBuku.RowHeadersWidth = 51;
            this.dgvPembayaranBuku.RowTemplate.Height = 24;
            this.dgvPembayaranBuku.Size = new System.Drawing.Size(529, 291);
            this.dgvPembayaranBuku.TabIndex = 51;
            // 
            // dgvListBuku
            // 
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvListBuku.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvListBuku.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvListBuku.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvListBuku.Location = new System.Drawing.Point(19, 409);
            this.dgvListBuku.Name = "dgvListBuku";
            this.dgvListBuku.RowHeadersWidth = 51;
            this.dgvListBuku.RowTemplate.Height = 24;
            this.dgvListBuku.Size = new System.Drawing.Size(476, 294);
            this.dgvListBuku.TabIndex = 52;
            this.dgvListBuku.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvListBuku_CellClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Poppins Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 40);
            this.label2.TabIndex = 54;
            this.label2.Text = "ID Buku";
            // 
            // txtIDBuku
            // 
            this.txtIDBuku.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDBuku.Location = new System.Drawing.Point(19, 58);
            this.txtIDBuku.Multiline = true;
            this.txtIDBuku.Name = "txtIDBuku";
            this.txtIDBuku.Size = new System.Drawing.Size(179, 38);
            this.txtIDBuku.TabIndex = 53;
            // 
            // txtJudulBuku
            // 
            this.txtJudulBuku.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJudulBuku.Location = new System.Drawing.Point(19, 142);
            this.txtJudulBuku.Multiline = true;
            this.txtJudulBuku.Name = "txtJudulBuku";
            this.txtJudulBuku.ReadOnly = true;
            this.txtJudulBuku.Size = new System.Drawing.Size(179, 38);
            this.txtJudulBuku.TabIndex = 55;
            // 
            // txtJumlahBuku
            // 
            this.txtJumlahBuku.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJumlahBuku.Location = new System.Drawing.Point(19, 226);
            this.txtJumlahBuku.Multiline = true;
            this.txtJumlahBuku.Name = "txtJumlahBuku";
            this.txtJumlahBuku.Size = new System.Drawing.Size(179, 38);
            this.txtJumlahBuku.TabIndex = 56;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnReset.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderSize = 0;
            this.btnReset.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(34)))), ((int)(((byte)(45)))));
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReset.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnReset.Location = new System.Drawing.Point(884, 702);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(146, 53);
            this.btnReset.TabIndex = 59;
            this.btnReset.Text = "Reset";
            this.btnReset.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnCetak
            // 
            this.btnCetak.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(193)))), ((int)(((byte)(7)))));
            this.btnCetak.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCetak.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCetak.FlatAppearance.BorderSize = 0;
            this.btnCetak.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(178)))), ((int)(((byte)(135)))), ((int)(((byte)(4)))));
            this.btnCetak.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCetak.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCetak.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCetak.Location = new System.Drawing.Point(692, 702);
            this.btnCetak.Name = "btnCetak";
            this.btnCetak.Size = new System.Drawing.Size(160, 53);
            this.btnCetak.TabIndex = 58;
            this.btnCetak.Text = "Cetak Transaksi";
            this.btnCetak.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCetak.UseVisualStyleBackColor = false;
            this.btnCetak.Click += new System.EventHandler(this.btnCetak_Click);
            // 
            // btnBayar
            // 
            this.btnBayar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnBayar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnBayar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnBayar.FlatAppearance.BorderSize = 0;
            this.btnBayar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(116)))), ((int)(((byte)(47)))));
            this.btnBayar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBayar.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBayar.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnBayar.Location = new System.Drawing.Point(512, 702);
            this.btnBayar.Name = "btnBayar";
            this.btnBayar.Size = new System.Drawing.Size(146, 53);
            this.btnBayar.TabIndex = 57;
            this.btnBayar.Text = "Bayar";
            this.btnBayar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBayar.UseVisualStyleBackColor = false;
            this.btnBayar.Click += new System.EventHandler(this.btnBayar_Click);
            // 
            // txtBayar
            // 
            this.txtBayar.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBayar.Location = new System.Drawing.Point(511, 567);
            this.txtBayar.Multiline = true;
            this.txtBayar.Name = "txtBayar";
            this.txtBayar.Size = new System.Drawing.Size(519, 38);
            this.txtBayar.TabIndex = 60;
            this.txtBayar.TextChanged += new System.EventHandler(this.txtBayar_TextChanged);
            this.txtBayar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBayar_KeyPress);
            // 
            // txtKembalian
            // 
            this.txtKembalian.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKembalian.Location = new System.Drawing.Point(511, 651);
            this.txtKembalian.Multiline = true;
            this.txtKembalian.Name = "txtKembalian";
            this.txtKembalian.Size = new System.Drawing.Size(519, 38);
            this.txtKembalian.TabIndex = 61;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 714);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(122, 30);
            this.label10.TabIndex = 62;
            this.label10.Text = "ID Transaksi :";
            // 
            // txtIDTransaksi
            // 
            this.txtIDTransaksi.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDTransaksi.Location = new System.Drawing.Point(131, 709);
            this.txtIDTransaksi.Multiline = true;
            this.txtIDTransaksi.Name = "txtIDTransaksi";
            this.txtIDTransaksi.Size = new System.Drawing.Size(81, 38);
            this.txtIDTransaksi.TabIndex = 63;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Poppins Medium", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(225, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(95, 40);
            this.label11.TabIndex = 65;
            this.label11.Text = "Harga";
            // 
            // txtHarga
            // 
            this.txtHarga.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHarga.Location = new System.Drawing.Point(232, 58);
            this.txtHarga.Multiline = true;
            this.txtHarga.Name = "txtHarga";
            this.txtHarga.ReadOnly = true;
            this.txtHarga.Size = new System.Drawing.Size(179, 38);
            this.txtHarga.TabIndex = 64;
            // 
            // btnCari
            // 
            this.btnCari.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(231)))), ((int)(((byte)(225)))));
            this.btnCari.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnCari.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCari.FlatAppearance.BorderSize = 0;
            this.btnCari.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(154)))), ((int)(((byte)(150)))));
            this.btnCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCari.Font = new System.Drawing.Font("Poppins", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCari.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCari.Image = global::ProjectUAS1.Properties.Resources.search_1;
            this.btnCari.Location = new System.Drawing.Point(310, 296);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(133, 53);
            this.btnCari.TabIndex = 66;
            this.btnCari.Text = "Cari";
            this.btnCari.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCari.UseVisualStyleBackColor = false;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // FormTransaksi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1066, 767);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtHarga);
            this.Controls.Add(this.txtIDTransaksi);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txtKembalian);
            this.Controls.Add(this.txtBayar);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnCetak);
            this.Controls.Add(this.btnBayar);
            this.Controls.Add(this.txtJumlahBuku);
            this.Controls.Add(this.txtJudulBuku);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIDBuku);
            this.Controls.Add(this.dgvPembayaranBuku);
            this.Controls.Add(this.btnHapus);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtTotalHarga);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvListBuku);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTransaksi";
            this.Text = "FormTransaksi";
            this.Load += new System.EventHandler(this.FormTransaksi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPembayaranBuku)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvListBuku)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtTotalHarga;
        private System.Windows.Forms.Button btnHapus;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.DataGridView dgvPembayaranBuku;
        private System.Windows.Forms.DataGridView dgvListBuku;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIDBuku;
        private System.Windows.Forms.TextBox txtJudulBuku;
        private System.Windows.Forms.TextBox txtJumlahBuku;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnCetak;
        private System.Windows.Forms.Button btnBayar;
        private System.Windows.Forms.TextBox txtBayar;
        private System.Windows.Forms.TextBox txtKembalian;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtIDTransaksi;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtHarga;
        private System.Windows.Forms.Button btnCari;
    }
}