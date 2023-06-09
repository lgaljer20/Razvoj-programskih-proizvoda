﻿using BusinessLogicLayer;
using System;
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
    public partial class Frm2FA : Form
    {
        private string Username { get; set; }
        private TwoFactorService service { get; set; }

        public Frm2FA(string username)
        {
            InitializeComponent();
            Username = username;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            var frmLogin = new FrmLogin();
            Hide();
            frmLogin.ShowDialog();
            Close();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string code = txtMFA.Text;
            int status = service.CheckCode(code);
            switch(status)
            {
                case 0: MessageBox.Show("Uneseni kod nije ispravan!"); break;
                case 1: Redirect(1); break;
                case 2: Redirect(2); break;
            }

        }

        private void Frm2FA_Load(object sender, EventArgs e)
        {
            service = new TwoFactorService();
            try
            {
                service.SendEmail();
            }
            catch
            {
                MessageBox.Show("Greška prilikom slanja maila");
            }
        }

        private void Redirect(int role)
        {
            if (role == 1) 
            { 
                var frmUser = new FrmUser();
                Hide();
                frmUser.ShowDialog();
                Close();
            }
            else
            {
                var frmAdmin = new FrmAdmin();
                Hide();
                frmAdmin.ShowDialog();
                Close();
            }
            
        }
    }
}
