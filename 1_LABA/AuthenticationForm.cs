using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            var r = MessageBox.Show("Do you want to exit the form?", "DELETE", MessageBoxButtons.YesNo,
                MessageBoxIcon.Error);
            if (r == DialogResult.Yes)
            {

                Close();
            }
        }
    }
}