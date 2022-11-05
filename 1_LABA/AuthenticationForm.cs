﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace _1_LABA
{
    public partial class AuthenticationForm : Form
    {
        public AuthenticationForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            LoginComboBox.SelectedIndex = 0;
        }

        public static string CreateMD5(string input)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(hashBytes);
            }
        }

        private void LoginComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PasswordTextBox.Enabled = (LoginComboBox.SelectedItem == "admin");
            if (!PasswordTextBox.Enabled)
            {
                PasswordTextBox.Text = String.Empty;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            var dialogResult = MessageBox.Show("Do you want to exit the form?", "Exit", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Close();
            }
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            var login = LoginComboBox.SelectedItem.ToString();
            var password = PasswordTextBox.Text;
            var passwordHash = CreateMD5(login + password);
            const string adminPasswordHash = "C93CCD78B2076528346216B3B2F701E6";
            if (passwordHash == adminPasswordHash)
            {
                MessageBox.Show("Authenticated successfully", "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show("Password is not correct", "Authentication failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
           
        }
    }
}