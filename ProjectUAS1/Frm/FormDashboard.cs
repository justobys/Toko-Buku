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
    public partial class FormDashboard : Form
    {
        public FormDashboard(string role)
        {
            InitializeComponent();
            btnTambah.Visible = btnHapus.Visible = btnEdit.Visible = role == "admin";
            pnlTotalBuku.Visible = pnlTotalTransaksi.Visible = pnlStockBuku.Visible = role == "admin" ;
            if (role == "public")
            {
                btnCari.Location = new Point(19, 99);
                dgvTableBuku.Location = new Point(19, 150);
                dgvTableBuku.Size = new Size(761, 480);
            }
        }
    }
}
