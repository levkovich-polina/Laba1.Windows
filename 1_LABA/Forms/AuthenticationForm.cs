namespace _1_LABA.Forms
{
    public partial class AuthenticationForm : Form
    {
        public string AuthenticatedUser { get; private set; }

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
            if (login == "admin")
            {
                if (passwordHash == adminPasswordHash)
                {
                    MessageBox.Show("Authenticated successfully as "+login, "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    AuthenticatedUser = login;
                    Close();
                }
                else
                {
                    MessageBox.Show("Password is not correct", "Authentication failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Authenticated successfully as " + login, "Success",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                AuthenticatedUser = login;
                Close();
            }
        }
    }
}