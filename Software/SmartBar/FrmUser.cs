﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SmartBar
{
    public partial class FrmUser : Form
    {
        public FrmUser()
        {
            InitializeComponent();
        }

        private void btnReceipts_Click(object sender, EventArgs e)
        {
            FrmReceipts frmReceipts = new FrmReceipts();
            Hide();
            frmReceipts.ShowDialog();
            Close();
        }
    }
}