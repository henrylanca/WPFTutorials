using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace HelloWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<User> users = new ObservableCollection<User>();

        public MainWindow()
        {
            InitializeComponent();
            //this.DataContext = this;

            users.Add(new User() { Name = "John Doe" });
            users.Add(new User() {Name="Jane Doe"});

            this.lbUsers.ItemsSource = users;
        }

        private void pnlMainGrid_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("You clicked me at " + e.GetPosition(this).ToString());
        }

        private void txtName_SelectionChanged(object sender, RoutedEventArgs e)
        {
            TextBox txtBox = sender as TextBox;
            txtMail.Text = txtBox.SelectedText;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BindingExpression binding = txtTitle.GetBindingExpression(TextBox.TextProperty);
            binding.UpdateSource();
        }

        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            if(!string.IsNullOrEmpty(this.txtName.Text))
                users.Add(new User() { Name = this.txtName.Text });
        }

        private void btnChangeUser_Click(object sender, RoutedEventArgs e)
        {
            if (this.lbUsers.SelectedItem != null)
                (lbUsers.SelectedItem as User).Name = "Random Name";
        }

        private void btnDeleteUser_Click(object sender, RoutedEventArgs e)
        {
            if (this.lbUsers.SelectedItem != null)
                users.Remove(this.lbUsers.SelectedItem as User);
        }
    }

    public class User : INotifyPropertyChanged
    {
        private string name;

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    this.NotifyPropertyChanged("Name");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }
    }
}
