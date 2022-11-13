namespace _1_LABA.Forms
{
    public partial class AuthenticationForm : Form
    {
        private readonly AuthenticationManager _authenticationManager;

        public AuthenticationForm(AuthenticationManager authenticationManager)
        {
            _authenticationManager = authenticationManager;
            InitializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            LoginComboBox.SelectedIndex = 0;
        }


        private void LoginComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
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
            try
            {
                _authenticationManager.Login(login, password);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Authentication failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show("Authenticated successfully as " + _authenticationManager.AuthenticatedUser, "Success",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            Close();
        }
    }
}