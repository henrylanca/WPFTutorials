using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Shapes;

namespace HelloWPF
{
    /// <summary>
    /// Interaction logic for Win2.xaml
    /// </summary>
    public partial class Win2 : Window
    {
        public Win2()
        {
            InitializeComponent();

            List<NewUser> items = new List<NewUser>();
            items.Add(new NewUser() { Name = "John Doe", Age = 42, Mail = "http://www.yahoo.com" });
            items.Add(new NewUser() { Name = "Joan Doe", Age = 39, Mail = "http://www.google.com" });
            items.Add(new NewUser() { Name = "Sammy Doe", Age = 7, Mail = "http://www.msn.com" });

            this.lvUsers.ItemsSource = items;

        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            this.txtEditor.Text = "";
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
    }

    public class NewUser
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string Mail { get; set; }
    }
}
