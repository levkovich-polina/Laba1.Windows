using System.Drawing;
using System;

namespace _1_LABA
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            listBox1.Items.Add(new Person(12345, "Polina", new DateTime(2003, 8, 20)));
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            PersonDetailsForm form = new PersonDetailsForm(null);
            form.IsAdmin = false;
            form.Mode = PersonEditingMode.Create;
            DialogResult result = form.ShowDialog(this);
            if (form.person != null)
            {
                listBox1.Items.Add(form.person);
            }

            form.Close();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                Person person = (Person)listBox1.SelectedItems[0];
                PersonDetailsForm form = new PersonDetailsForm(person);
                form.IsAdmin = false;
                form.Mode = PersonEditingMode.Edit;
                DialogResult show = form.ShowDialog(this);

                if (show == DialogResult.Yes || show == DialogResult.Cancel)
                {
                    form.Close();
                }

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
            if (listBox1.SelectedItem != null)
            {
                var r = MessageBox.Show("Do you want to delete the selected one?", "DELETE", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Error);
                if (r == DialogResult.Yes)
                {
                    listBox1.Items.Remove(listBox1.SelectedItem);
                }
            }
            else
            {
                var r = MessageBox.Show("To delete,you need to select person.", "DELETE", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
    }
}