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
        private int actions;
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
                    birthday <= DateTime.Now)
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

        public static int d = 5;

        public struct Coords
        {
            public int formWidth;
            public int formHeight;
            public int Width;
            public int Height;
            public int MiddleX;
            public int MiddleY;

            public Coords(int formWidth, int formHeight, int Width, int Height)
            {
                this.formWidth = formWidth - 9 - d;
                this.formHeight = formHeight - 38 - d;
                this.Width = Width;
                this.Height = Height;
                MiddleX = Width / 2;
                MiddleY = Height / 2;
            }
        }

        System.Drawing.Point p = new System.Drawing.Point();
        Coords coords;

        private void AcceptButton_MouseMove(object sender, MouseEventArgs e)
        {
            var name = NameTextBox.Text;
            var cardNumber = CardTextBox.Text;
            var birthday = DateBirthdayPicker.Value.Date;
            actions = 1;
            if (actions == edit)
            {
                if (IsAdmin && name != notEmpty &&
                    birthday <= DateTime.Now)
                {
                    int card;
                    if (int.TryParse(cardNumber, out card))
                    {
                        if (AcceptButton.Left < d || AcceptButton.Right + d > coords.formWidth ||
                            AcceptButton.Top < d || AcceptButton.Bottom + d > coords.formHeight)
                        {
                            Random rd = new Random();
                            AcceptButton.Left = rd.Next(0, coords.formWidth - coords.Width);
                            AcceptButton.Top = rd.Next(0, coords.formHeight - coords.Height);
                            return;
                        }

                        if (AcceptButton.Left > 0 && AcceptButton.Right < coords.formWidth)
                            p.X = e.X < coords.MiddleX ? d : e.X == coords.MiddleX ? 0 : -d;
                        if (AcceptButton.Top > 0 && AcceptButton.Bottom < coords.formHeight)
                            p.Y = e.Y < coords.MiddleY ? d : e.Y == coords.MiddleY ? 0 : -d;
                        if (DateTime.Now.Millisecond % 3 == 0)
                        {
                            AcceptButton.Left += p.X;
                            AcceptButton.Top += p.Y;
                        }
                    }
                }
            }
        }

        private void PersonDetailsForm_Load(object sender, EventArgs e)
        {
            coords = new Coords(Width, Height, AcceptButton.Width, AcceptButton.Height);
        }
    }
}