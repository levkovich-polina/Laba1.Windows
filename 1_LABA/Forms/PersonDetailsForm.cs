using System.Windows.Forms;

namespace _1_LABA.Forms
{
    public partial class PersonDetailsForm : Form
    {
        private readonly AuthenticationManager _authenticationManager;

        public PersonDetailsForm(AuthenticationManager authenticationManager, Person person)
        {
            _authenticationManager = authenticationManager;
            _authenticationManager.LoggedIn += AuthenticationManager_LoggedIn;
            InitializeComponent();
            Person = person;
        }

        public Person Person { get; private set; }

        private bool IsCreateMode
        {
            get { return Person == null; }
        }
        private bool IsEditMode
        {
            get { return Person != null; }
        }
        private void AuthenticationManager_LoggedIn()
        {
            UpdateTextBoxAvailability();
            if (_authenticationManager.IsAdmin)
            {
                BackColor = ColorManager.GetRandomColor();
                var buttonColor = ColorManager.GetRandomColor();
                AcceptButton.BackColor = buttonColor;
                CancelButton.BackColor = buttonColor;
            }
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            UpdateTextBoxAvailability();
            if (IsEditMode)
            {
                NameTextBox.Text = Person.Name;
                DateBirthdayPicker.Value = Person.Birthday;
                CardTextBox.Text = Person.CardNumber.ToString();
            }
        }

        private void UpdateTextBoxAvailability()
        {
            CardTextBox.Enabled = IsCreateMode || _authenticationManager.IsAdmin;
            DateBirthdayPicker.Enabled = IsCreateMode || _authenticationManager.IsAdmin;
        }

        private void PersonDetailsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers.HasFlag(Keys.Control) && e.Modifiers.HasFlag(Keys.Shift) &&
                e.KeyCode == Keys.L)
            {
                AuthenticationForm form = new AuthenticationForm(_authenticationManager);
                form.Show();
            }
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            var name = NameTextBox.Text;
            var cardNumber = CardTextBox.Text;
            var birthday = DateBirthdayPicker.Value.Date;
            if (name == string.Empty)
            {
                MessageBox.Show(Text = "Incorrect name");
            }
            else
            {
                if (cardNumber == string.Empty && (CardTextBox.TextLength < 5 && CardTextBox.TextLength >= 6))
                {
                    MessageBox.Show(Text = "Incorrect card number");
                }
                else
                {
                    if (birthday >= DateTime.Now)
                    {
                        MessageBox.Show(Text = "Incorrect birthday");
                    }
                    else
                    {
                        int card;
                        if (int.TryParse(cardNumber, out card))
                        {
                            Person = new Person(card, name, birthday);
                            DialogResult = DialogResult.Yes;
                        }
                    }
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

        Point p = new Point();
        Coords coords;

        private void AcceptButton_MouseMove(object sender, MouseEventArgs e)
        {
            var name = NameTextBox.Text;
            var cardNumber = CardTextBox.Text;
            var birthday = DateBirthdayPicker.Value.Date;
            if (Person != null)
            {
                if (_authenticationManager.IsAdmin && name != string.Empty &&
                    birthday <= DateTime.Now)
                {
                    int card;
                    if (int.TryParse(cardNumber, out card))
                    {
                        if (card != Person.CardNumber)
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
        }

        private void PersonDetailsForm_Load(object sender, EventArgs e)
        {
            coords = new Coords(Width, Height, AcceptButton.Width, AcceptButton.Height);
        }

        private void CardTextBox_TextChanged(object sender, EventArgs e)
        {
            var digits = CardTextBox.Text.Where(char.IsDigit).ToArray();
            CardTextBox.Text = new string(digits);
        }
    }
}