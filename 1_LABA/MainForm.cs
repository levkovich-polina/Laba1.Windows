namespace _1_LABA
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            listBox1.Items.Add(new Person(12, "Polina", new DateTime(2003, 8, 20)));
        }

        public void CreateButton_Click(object sender, EventArgs e)
        {
            PersonDetailsForm form = new PersonDetailsForm();
            form.IsAdmin = false;
            form.Mode = PersonEditingMode.Create;
            form.ShowDialog();
        }

        public void EditButton_Click(object sender, EventArgs e)
        {
            PersonDetailsForm form = new PersonDetailsForm();
            form.IsAdmin = false;
            form.Mode = PersonEditingMode.Edit;
            form.ShowDialog();
        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        public void DeleteButton_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("Do you want to delete the selected one?", "DELETE", MessageBoxButtons.YesNo,
                MessageBoxIcon.Error);
            if (r == DialogResult.Yes)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }
    }
}