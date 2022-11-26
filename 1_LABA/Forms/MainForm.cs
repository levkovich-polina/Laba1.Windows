namespace _1_LABA.Forms
{
    public partial class MainForm : Form
    {
        private readonly AuthenticationManager _authenticationManager;
        private readonly ScreenPartWatcher _screenPartWatcher;
        private readonly Vault _vault;

        public MainForm(AuthenticationManager authenticationManager, ScreenPartWatcher screenPartWatcher, Vault vault)
        {
            _authenticationManager = authenticationManager;
            _authenticationManager.LoggedIn += _authenticationManager_LoggedIn;
            _screenPartWatcher = screenPartWatcher;
            _screenPartWatcher.ScreenPartChanged += _screenPartWatcher_ScreenPartChanged;
            _vault = vault;
            _vault.Unlocked += _vault_Unlocked;
            InitializeComponent();
            PersonsListBox.Items.Add(new Person(12345, "Polina", new DateTime(2003, 8, 20)));
        }


        private void _vault_Unlocked()
        {
            throw new NotImplementedException();
        }

        private ScreenPart _screenPartWatcher_ScreenPartChanged()
        {
            throw new NotImplementedException();
            _vault.Enter;
        }

        private void _authenticationManager_LoggedIn()
        {
            if (_authenticationManager.IsAdmin)
            {
                BackColor = ColorManager.GetRandomColor();
                var buttonBackColor = ColorManager.GetRandomColor();
                CreateButton.BackColor = buttonBackColor;
                EditButton.BackColor = buttonBackColor;
                DeleteButton.BackColor = buttonBackColor;
            }
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            PersonDetailsForm form = new PersonDetailsForm(_authenticationManager, null);
            form.ShowDialog(this);
            if (form.Person != null)
            {
                PersonsListBox.Items.Add(form.Person);
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (PersonsListBox.SelectedItem != null)
            {
                Person person = (Person)PersonsListBox.SelectedItems[0];
                PersonDetailsForm form = new PersonDetailsForm(_authenticationManager, person);
                form.ShowDialog(this);
                PersonsListBox.Items.Remove(person);
                PersonsListBox.Items.Add(form.Person);
            }
            else
            {
                MessageBox.Show(Text = "You must choose a person to change");
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            if (PersonsListBox.SelectedItem != null)
            {
                var dialogResult = MessageBox.Show("Do you want to delete the selected one?", "DELETE",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);
                if (dialogResult == DialogResult.Yes)
                {
                    PersonsListBox.Items.Remove(PersonsListBox.SelectedItem);
                }
            }
            else
            {
                MessageBox.Show("To delete,you need to select person.", "DELETE", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
        }
    }
}