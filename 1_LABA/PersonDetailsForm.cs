using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _1_LABA
{
    public partial class PersonDetailsForm : Form
    {
        public bool IsAdmin { get; set; }
        public PersonEditingMode Mode { get; set; }


        public PersonDetailsForm()
        {
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.CardTextBox.Enabled = Mode == PersonEditingMode.Create || IsAdmin;
            this.DateBirthdayPicker.Enabled = Mode == PersonEditingMode.Create || IsAdmin;
        }

        private void PersonDetailsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers.HasFlag(Keys.Control) && e.Modifiers.HasFlag(Keys.Shift) &&
                e.KeyCode == Keys.L) //При нажатии Ctrl + Shift + L
            {
                AuthenticationForm form = new AuthenticationForm();
                form.Show();
            }
        }
    }
}