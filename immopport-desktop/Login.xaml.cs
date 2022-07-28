﻿using immopport_desktop;
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
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    /// 
    public partial class Login : Window
    {
        API api { get; set; }
        public Login()
        {
            InitializeComponent();
            api = new API();
        }
        private async void LogIn(int matricule, string password)
        {
             Task task = api.Auth(matricule, password);
           /* int i = 0;
            while (!task.IsCompleted)
            {
                //On affiche une baree de chargement

                MessageBox.Show("On attend " +i);
                i++;
            }*/
        }
        private  void btnLogin_ClickAsync(object sender, RoutedEventArgs e)
        {

            if (txtMatricule.Text.Length != 0 && txtPassword.Password.Length != 0)
            {
                int matricule = int.Parse(txtMatricule.Text);
                string password = txtPassword.Password;
                LogIn(matricule,password);
                MessageBox.Show(api.AccessToken);

                /*_ = login.Auth(matricule, password).Wait(9000);*/
                /* bool completed = login.Auth(matricule, password).IsCompleted;

                 if (! completed)
                 {
                     MessageBox.Show("ok");
                 }
                 else
                 {
                     MessageBox.Show(login.AccessToken);
                 }
 */

                /*if (login.AccessToken != string.Empty)
                {
                    MessageBox.Show(login.AccessToken);
                    Application.Current.Properties["user"] = login;

                    *//*Hide();
                    (new Dashboard()).Show();*//*
                } 
                else
                {
                    MessageBox.Show("OKKKKKKKKKKKKKK");
                    
                }*/
            }
            
            else
            {
                errormessage.Text = "Le formulaire ne peut être vide.";
            }
        }
    }
}
