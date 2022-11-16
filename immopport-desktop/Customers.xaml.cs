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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace immopport_desktop
{
    public partial class Customers : UserControl
    {
        public Customers()
        {
            API user;

            InitializeComponent();

            if (Application.Current != null && Application.Current.Properties["user"] != null)
            {
                user = (API)Application.Current.Properties["user"];

                try
                {
                    Task<CustomerList?>? customers = Task.Run(() => user?.GetCustomers());

                    if (customers != null)
                    {
                        List<Customer> items = new List<Customer>(customers.Result.Customer);
                        CustomersList.ItemsSource = items;
                    }
                    else
                    {
                        MessageBox.Show(user?.ErrorMessage);
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
        }

        void DeleteClient(object sender, RoutedEventArgs e)
        {
            var customerId = (sender as Button).Tag.ToString();
            API user;

            try
            {
                if (Application.Current != null && Application.Current.Properties["user"] != null)
                {
                    user = (API)Application.Current.Properties["user"];
                    Task<CustomerResponse?>? customer = Task.Run(() => user?.DeleteCustomer(customerId));

                    MessageBox.Show("Le client a bien été supprimé");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
