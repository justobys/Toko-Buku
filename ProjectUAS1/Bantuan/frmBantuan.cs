using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectUAS1.Bantuan
{
    public partial class bantuan_form : Form
    {
        public bantuan_form()
        {
            InitializeComponent();
            // Set the AutoScroll property to true to enable scrolling.
            pnlBantuan.AutoScroll = true;

            // Initialize the TextBox for the help content.
            isiText.Multiline = true;
            isiText.ReadOnly = true;
            isiText.ScrollBars = ScrollBars.Vertical;
            isiText.WordWrap = true;
            //iText.Dock = DockStyle.Fill; // This will ensure the TextBox fills the pnlBantuan.
        }

        public string Judul
        {
            get { return lblJudul.Text; }
            set { lblJudul.Text = value; }
        }

        public string Isi
        {
            get { return isiText.Text; }
            set { isiText.Text = value; }
        }
    }
}