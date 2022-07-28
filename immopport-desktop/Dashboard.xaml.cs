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
