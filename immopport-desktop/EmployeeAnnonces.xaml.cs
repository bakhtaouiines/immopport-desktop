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
    /// <summary>
    /// Logique d'interaction pour EmployeeAnnonces.xaml
    /// </summary>
    public partial class EmployeeAnnonces : UserControl
    {
        public EmployeeAnnonces()
        {
            InitializeComponent();
            API user;
            this.DataContext = this;

            if (Application.Current != null && Application.Current.Properties["user"] != null)
            {
                user = (API)Application.Current.Properties["user"];

                try
                {
                    Task<PropertyList?>? property = Task.Run(() => user?.GetPropertyEmployee());

                    if (property != null)
                    {
                        List<Property> items = new List<Property>(property.Result.Property);
                        employeeAnnonces.ItemsSource = items;
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
    }
}
