using System.Windows;

namespace WPF_Facit_LIST
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBoxNamn.Text) && !string.IsNullOrEmpty(txtBoxNumber.Text))
            {
                string contact = $"{txtBoxNamn.Text} - {txtBoxNumber.Text}";
                ContactList.Items.Add(contact);
                txtBoxNamn.Clear();
                txtBoxNumber.Clear();
            }


        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            if (ContactList.SelectedItem != null)
            {
                ContactList.Items.Remove(ContactList.SelectedItem);
                txtBoxNamn.Clear();
                txtBoxNumber.Clear();
            }
            else
            {
                MessageBox.Show("Select a item");
            }

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (ContactList.SelectedItem != null)
            {
                int selectedIndex = ContactList.SelectedIndex;
                ContactList.Items[selectedIndex] = $"{txtBoxNamn.Text} - {txtBoxNumber.Text}";
            }
        }

        private void ContactList_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (ContactList.SelectedItem != null)
            {
                string SelectedItem = ContactList.SelectedItem.ToString();
                string[] temp = SelectedItem.Split(" - ");
                txtBoxNamn.Text = temp[0];
                txtBoxNumber.Text = temp[1];
            }
        }
    }
}