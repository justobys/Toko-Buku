﻿using System;
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
    public partial class FormTambah : Form
    {
        public FormTambah()
        {
            InitializeComponent();
        }

        private void btnHapus_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
