using immopport_desktop.Type;
using System;
using System.Collections.Generic;
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

namespace immopport_desktop
{
    /// <summary>
    /// Logique d'interaction pour Dashboard.xaml
    /// </summary>
    public partial class Dashboard : Window
    {
        public Dashboard()
        {
            API user;

            if (Application.Current != null && Application.Current.Properties["user"] != null) 
            {

                user = (API)Application.Current.Properties["user"];

                try
                {
                    
                    MessageBox.Show("okk");
                    MessageBox.Show(user.AccessToken);

                    
                    Task <Employee?>? employee = user?.GetProfile();
                    if (employee != null)
                    {
                        MessageBox.Show(employee.Result.Firstname);
                    }
                    else
                    {
                        MessageBox.Show(user?.ErrorMessage);
                    }
                }
                catch(Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
            InitializeComponent();
            this.contentControl.Content = new Annonces();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //this.Hide(); 
            //(new Login()).Show();
            this.contentControl.Content = new Annonces();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new Employees();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = "Hello";

        }
    }
}
