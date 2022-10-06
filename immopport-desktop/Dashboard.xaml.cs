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
    public partial class Dashboard : Window
    {
        public string? EmployeeInfo { get; }
        public Dashboard()
        {
            API user;
            this.DataContext = this;

            if (Application.Current != null && Application.Current.Properties["user"] != null) 
            {
                user = (API)Application.Current.Properties["user"];

                try
                {
                    Task <EmployeeResponse?>? employee = Task.Run(() => user?.GetProfile());

                    if (employee != null)
                    {
                        TextBlock txtBlockEmployeeInfo = new TextBlock();

                        txtBlockEmployeeInfo.DataContext  = employee.Result.Employee.Lastname + " " + employee.Result.Employee.Firstname + " - " + employee.Result.Employee.Matricule.ToString();

                        EmployeeInfo  = (string?)txtBlockEmployeeInfo.DataContext;
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

        private void Button_Click_Annonce(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new Annonces();
        }

        private void Button_Click_AnnonceEmploye(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new EmployeeAnnonces();

        }

        private void Button_Click_Employe(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new Employees();

        }

        private void Button_Click_RDV(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new EmployeeRDV();

        }

        private void Button_Click_Client(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new Customers();

        }

        private void Button_Click_Contact(object sender, RoutedEventArgs e)
        {
            this.contentControl.Content = new Agencies();
        }

        private void Button_Click_Deconnexion(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
