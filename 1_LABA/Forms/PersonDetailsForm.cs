namespace _1_LABA.Forms
{
    public partial class PersonDetailsForm : Form
    {
        private readonly AuthenticationManager _authenticationManager;

        private Coordinates _coordinates;

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
            var wordCount = name.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;
            if (name == string.Empty)
            {
                MessageBox.Show(Text = "Incorrect name! The name field should not be empty");
            }

            if (wordCount != 2)
            {
                MessageBox.Show(Text = "Incorrect name! The name field must consist of two words");
            }
            else
            {
                if (cardNumber == string.Empty || CardTextBox.TextLength < 5)
                {
                    MessageBox.Show(Text = "Incorrect card number! The card number must consist of 5 digits");
                }
                else
                {
                    if (birthday >= DateTime.Now)
                    {
                        MessageBox.Show(Text =
                            "Incorrect birthday! It is not possible to set the date of birthday in the future");
                    }
                    else
                    {
                        if (int.TryParse(cardNumber, out var card))
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
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

        private void AcceptButton_MouseMove(object sender, MouseEventArgs e)
        {
            var name = NameTextBox.Text;
            var cardNumber = CardTextBox.Text;
            var birthday = DateBirthdayPicker.Value.Date;
            if (!IsEditMode)
                return;

            if (!_authenticationManager.IsAdmin || name == string.Empty || birthday > DateTime.Now)
                return;

            if (!int.TryParse(cardNumber, out var card))
                return;

            if (card == Person.CardNumber)
                return;


            if (AcceptButton.Left < Coordinates.ButtonMoveStep ||
                AcceptButton.Right + Coordinates.ButtonMoveStep > _coordinates.FormWidth ||
                AcceptButton.Top < Coordinates.ButtonMoveStep ||
                AcceptButton.Bottom + Coordinates.ButtonMoveStep > _coordinates.FormHeight)
            {
                Random rd = new Random();
                AcceptButton.Left = rd.Next(0, _coordinates.FormWidth - _coordinates.Width);
                AcceptButton.Top = rd.Next(0, _coordinates.FormHeight - _coordinates.Height);
                return;
            }

            Point newButtonLocation = new Point();

            if (AcceptButton.Left > 0 && AcceptButton.Right < _coordinates.FormWidth)
                newButtonLocation.X =
                    e.X < _coordinates.MiddleX ? Coordinates.ButtonMoveStep :
                    e.X == _coordinates.MiddleX ? 0 : -Coordinates.ButtonMoveStep;
            if (AcceptButton.Top > 0 && AcceptButton.Bottom < _coordinates.FormHeight)
                newButtonLocation.Y =
                    e.Y < _coordinates.MiddleY ? Coordinates.ButtonMoveStep :
                    e.Y == _coordinates.MiddleY ? 0 : -Coordinates.ButtonMoveStep;
            if (DateTime.Now.Millisecond % 3 == 0)
            {
                AcceptButton.Left += newButtonLocation.X;
                AcceptButton.Top += newButtonLocation.Y;
            }
        }

        private void PersonDetailsForm_Load(object sender, EventArgs e)
        {
            _coordinates = new Coordinates(Width, Height, AcceptButton.Width, AcceptButton.Height);
        }

        private void CardTextBox_TextChanged(object sender, EventArgs e)
        {
            var digits = CardTextBox.Text.Where(char.IsDigit).ToArray();
            CardTextBox.Text = new string(digits);
        }
    }
}