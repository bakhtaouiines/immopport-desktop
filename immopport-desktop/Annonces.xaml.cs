using System;
using immopport_desktop.Type;
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
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class Annonces : UserControl
    {
        public Annonces()
        {
            API user;
            this.DataContext = this;

            if (Application.Current != null && Application.Current.Properties["user"] != null)
            {
                user = (API)Application.Current.Properties["user"];

                try
                {
                    Task<PropertyResponse?>? property = Task.Run(() => user?.GetProperty());
                    property.Wait();

                    if (property != null)
                    {
                        MessageBox.Show(property.Result.Property[0].Name);
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
            InitializeComponent();
        }

        private void PostProperty(object sender, RoutedEventArgs e)
        {

        }
        private void DisplayProperty(object sender, RoutedEventArgs e)
        {

        }
    }
}
