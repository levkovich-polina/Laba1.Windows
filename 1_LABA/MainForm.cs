namespace _1_LABA
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            PersonDetailsForm form = new PersonDetailsForm();
            form.IsAdmin = false;
            form.Mode = PersonEditingMode.Edit;
            form.Show();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            PersonDetailsForm form = new PersonDetailsForm();
            form.IsAdmin = false;
            form.Mode = PersonEditingMode.Edit;
            form.Show();
        }

        private void DeletButton_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("Do you want to delete the selected one?", "DELETE", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (r == DialogResult.Yes)
            {
                // listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }
    }
}