using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace HelloWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            NewWindow wnd = new NewWindow();
            wnd.Title = "Something else";

            //if (e.Args.Length == 1)
            //    MessageBox.Show("Now Opening File : \n\n" + e.Args[0]);
            //else
            //    MessageBox.Show(string.Format("Number of Arguments : {0}", e.Args.Length));

            wnd.Show();
        }
    }
}
