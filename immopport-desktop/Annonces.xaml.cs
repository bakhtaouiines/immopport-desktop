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
using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing;
using Image = System.Windows.Controls.Image;
using System.Security.Policy;

namespace immopport_desktop
{

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
                    Task<PropertyList?>? property = Task.Run(() => user?.GetProperty());

                    if (property != null)
                    {
                        List<Property> items = new List<Property>(property.Result.Property);
                        PropertiesList.ItemsSource = items;
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
        private void DisplayProperty(object sender, RoutedEventArgs e)
        {
            goNext(sender, e);
            goBack(sender, e);

            var propertyId = (sender as Button).Tag.ToString();
            API user;

            if (Application.Current != null && Application.Current.Properties["user"] != null)
            {
                user = (API)Application.Current.Properties["user"];
                Task<PropertyResponse?>? property = Task.Run(() => user?.GetSingleProperty(propertyId));

                if (property != null)
                {
                    PropertyPictures[] picture = property.Result.Property.PropertyPictures;

                    PropertyPicture.Source = new BitmapImage(new Uri("/Assets/not-found-img.png", UriKind.Relative));

                    foreach (PropertyPictures pic in picture)
                    {
                        Uri? uri = new Uri(pic.Path);
                        ImageSource imgSource = new BitmapImage(uri);
                        PropertyPicture.Source = imgSource;
                    }

                    txtBlockName.Text = property.Result.Property.Name + " - " + property.Result.Property.PropertyTransactionType?.Name;

                    txtBlockAddress.Text = property.Result.Property.Address + ", " + property.Result.Property.City + ", " + property.Result.Property.Zipcode.ToString();

                    txtBlockPrice.Text = property.Result.Property.Price.ToString() + " € | " + property.Result.Property.Surface?.ToString() + " m² | " + property.Result.Property.PropertyType?.Name + " | " + property.Result.Property.PropertyCategory?.Name;
                    
                    txtBlockDescription.Text = property.Result.Property.Description;
                    
                    txtBlockKitchen.Text = property.Result.Property.Kitchen?.Name;
                    
                    txtBlockHeater.Text = property.Result.Property.Heater?.Name;
                    
                    if (property.Result.Property.AdditionAddress != null)
                    {
                        txtBlockAddAddress.Text = property.Result.Property.AdditionAddress;
                    }
                    else
                    {
                        txtBlockAddAddress.Visibility = Visibility.Collapsed;
                    }
                    
                    Room[] rooms = property.Result.Property.Rooms;
                    txtBlockRoom.Text = "Pièces: ";
                    foreach (Room r in rooms)
                    {
                        txtBlockRoom.Text += r.Name + " ";
                    }
                    
                    FeaturesList[] features = property.Result.Property.FeaturesList;
                    txtBlockFeatures.Text = "Annexes: ";

                    foreach (FeaturesList fl in features)
                    {
                        txtBlockFeatures.Text += fl.Name + " ";
                    }

                    if (property.Result.Property.IsFurnished)
                    {
                        txtBlockFurnished.Text = "Bien meublé: oui";
                    }
                    else
                    {
                        txtBlockFurnished.Text = "Bien meublé: non";
                    }

                }

                else
                {
                    MessageBox.Show(user?.ErrorMessage);
                }

            }
        }

        private void goNext(object sender, RoutedEventArgs e)
        {
            next.Visibility = Visibility.Visible;
        }

        private void goBack(object sender, RoutedEventArgs e)
        {
            back.Visibility = Visibility.Visible;
        }
    }
}
