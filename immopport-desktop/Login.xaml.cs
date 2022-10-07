using immopport_desktop;
using immopport_desktop.Type;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    public partial class Login : Window
    {
        API api { get; set; }
        public Login()
        {
            InitializeComponent();

            api = new API();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (txtMatricule.Text.Length != 0 && txtPassword.Password.Length != 0)
            {
                string password = txtPassword.Password;
                bool IsNumber = int.TryParse(txtMatricule.Text.Trim(), out int matricule);

                if (IsNumber)
                {
                    Task t = Task.Run(() => api.Auth(matricule, password));

                    t.Wait();

                    if (api.AccessToken != string.Empty)
                    {
                        Application.Current.Properties["user"] = api;

                        Hide();
                        (new Dashboard()).Show();
                    }
                    else
                    {
                        MessageBox.Show("Authentification impossible. Veuillez vérifier vos informations de connexion.");
                    }
                }
                else
                {
                    MessageBox.Show("Le matricule doit être un nombre.");
                }
            }
            
            else
            {
                errormessage.Text = "Le formulaire ne peut être vide.";
            }
        }
    }
}
