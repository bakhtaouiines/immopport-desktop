﻿using System;
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
using Microsoft.VisualBasic.ApplicationServices;


namespace immopport_desktop
{
    /// <summary>
    /// Logique d'interaction pour UserControl1.xaml
    /// </summary>
    public partial class Annonces : UserControl
    {
        public int? IdProperty { get; set; }
        public string? Titre { get; set; }
        public string? Address { get; set; }
        public Annonces()
        {
            InitializeComponent();
            API user;
            this.DataContext = this;

            if (Application.Current != null && Application.Current.Properties["user"] != null)
            {
                user = (API)Application.Current.Properties["user"];

                try
                {
                    Task<PropertyResponse?>? property = Task.Run(() => user?.GetProperty());

                    // property.Result.Property tableau json

                    if (property != null)
                    {
                        /*List<Property> items = new List<Property>(property.Result.Property);

                        PropertiesList.ItemsSource = items;*/

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

        private void PostProperty(object sender, RoutedEventArgs e)
        {

        }
        public void DisplayProperty(object sender, RoutedEventArgs e)
        {
            API user;

            if (Application.Current != null && Application.Current.Properties["user"] != null)
            {
                user = (API)Application.Current.Properties["user"];

                    Task<PropertyResponse?>? property = Task.Run(() => user?.GetSingleProperty());

                    if (property != null)
                    {
                        MessageBox.Show(property.ToString());
                       /* List<Property> items = new List<Property>(property.Result.Property);
                        PropertiesList.ItemsSource = items;*/
                    }
                    else
                    {
                        MessageBox.Show(user?.ErrorMessage);
                    }
                
            }
        }
    }
}
