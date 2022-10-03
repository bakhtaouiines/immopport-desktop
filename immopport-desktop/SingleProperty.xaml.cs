using immopport_desktop.Type;
using System;
using System.Collections.Generic;
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

namespace immopport_desktop
{
    public partial class SingleProperty : UserControl
    {
        public SingleProperty(string propertyId)
        {
            InitializeComponent();

            API user;

            if (Application.Current != null && Application.Current.Properties["user"] != null)
            {
                user = (API)Application.Current.Properties["user"];
                Task<PropertyResponse?>? property = Task.Run(() => user?.GetSingleProperty(propertyId));

                if (property != null)
                {
                    MessageBox.Show(property.Result.Property.Address);

                    List<Property> items = new List<Property>((IEnumerable<Property>)property.Result.Property);
                    PropertyDisplay.ItemsSource = items;
                }
                else
                {
                    MessageBox.Show(user?.ErrorMessage);
                }

            }
        }
    }
}
