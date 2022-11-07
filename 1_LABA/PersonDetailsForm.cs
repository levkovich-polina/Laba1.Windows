using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace _1_LABA
{
    public partial class PersonDetailsForm : Form
    {
        public bool IsAdmin { get; set; }
        public PersonEditingMode Mode { get; set; }
        private int button;
        private readonly int create = 0;
        private readonly int edit = 1;
        private readonly string notEmpty = "";
        public Person person;

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
                IsAdmin = true;
            }

            if (IsAdmin)
            {
                this.DateBirthdayPicker.Enabled = true;
                this.CardTextBox.Enabled = true;
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            var name = NameTextBox.Text;
            var cardNumber = CardTextBox.Text;
            var birthday = DateBirthdayPicker.Value.Date;
            if (button == create)
            {
                if (name != notEmpty && cardNumber != notEmpty &&
                    birthday <= new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day))
                {
                    int card;
                    if (int.TryParse(cardNumber, out card))
                    {
                        person = new Person(card, name, birthday);
                        DialogResult = DialogResult.Yes;
                    }
                }
                else
                {
                    MessageBox.Show(Text = "Incorrect data");
                }
            }
            else if (button == edit)
            {
                if (IsAdmin && name != notEmpty && birthday <= DateTime.Now)
                {
                    int card;
                    if (int.TryParse(cardNumber, out card))
                    {
                        person = new Person(card, name, birthday);
                        DialogResult = DialogResult.Yes;
                    }
                }
                else
                {
                    MessageBox.Show(Text = "Incorrect data");
                }
            }
        }

        private void CardTextBox_KeyPress(object sender, KeyPressEventArgs e) //в CardTextBox вводятся только числа
        {
            char ch = e.KeyChar;
            if (!Char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void NameTextBox_KeyPress(object sender, KeyPressEventArgs e) //в NameTextBox вводятся только буквы
        {
            e.Handled = (e.KeyChar == (char)Keys.Space);
        }

        private void AcceptButton_MouseMove(object sender, MouseEventArgs e)
        {
            var name = NameTextBox.Text;
            var cardNumber = CardTextBox.Text;
            var birthday = DateBirthdayPicker.Value.Date;

            Random x = new Random();
            Random y = new Random();
            int xx = Convert.ToInt32(x.Next(124, 300));
            int yy = Convert.ToInt32(y.Next(35, 250));
            AcceptButton.Location = new Point(xx, yy);
            if (button == edit && IsAdmin && name != notEmpty &&
                birthday <= new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day))
            {
            }
            
        }
    }
}