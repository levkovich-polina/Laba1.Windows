namespace _1_LABA
{
    public partial class MainForm : Form
    {
        private readonly int ADD = 0;
        private readonly int EDIT = 1;

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
            DialogResult dr = form.ShowDialog(this);
            if (dr == DialogResult.Yes)
            {
                listBox1.Items.Add(form.person);
            }

            form.Close();
        }

        public void EditButton_Click(object sender, EventArgs e)
        {
            // Edit button logic
            if (listBox1.SelectedItems.Count == 1)
            {
                PersonDetailsForm form = new PersonDetailsForm();
                form.IsAdmin = false;
                form.Mode = PersonEditingMode.Edit;
                form.ShowDialog();
                Person person = (Person)listBox1.SelectedItems[1];
                DialogResult dr = form.ShowDialog(this);
                if (dr == DialogResult.Yes || dr == DialogResult.Cancel)
                {
                    form.Close();
                }

                // Replace person
                listBox1.Items.Remove(person);
                listBox1.Items.Add((Person)form.person);
            }
            else
            {
                MessageBox.Show(Text = "You must choose a person to change");
            }
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