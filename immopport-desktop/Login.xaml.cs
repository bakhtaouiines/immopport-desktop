using immopport_desktop;
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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            if (txtMatricule.Text.Length == 0)
            {
                errormessage.Text = "Veuillez renseigner votre matricule.";
                txtMatricule.Focus();
            } 
            else
            {
                string matricule = txtMatricule.Text;
                string password = txtPassword.Password;

                API login = new API();
                //_ = login.Auth();

                Hide();
                (new Dashboard()).Show();
            }
            
        }
    }
}
