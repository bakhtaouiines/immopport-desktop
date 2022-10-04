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


namespace immopport_desktop
{

    public partial class Annonces : UserControl
    {
        private int totalRooms;

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

                    // property.Result.Property tableau json

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
            var propertyId = (sender as Button).Tag.ToString();
            API user;

            if (Application.Current != null && Application.Current.Properties["user"] != null)
            {
                user = (API)Application.Current.Properties["user"];
                Task<PropertyResponse?>? property = Task.Run(() => user?.GetSingleProperty(propertyId));

                if (property != null)
                {
                    Uri? uri = new Uri(property.Result.Property.PropertyPictures[0].Path);
                    ImageSource imgSource = new BitmapImage(uri);
                    PropertyPicture.Source = imgSource;
                    txtBlockName.Text = property.Result.Property.Name;
                    txtBlockAddress.Text = property.Result.Property.Address + ", " + property.Result.Property.City + ", " + property.Result.Property.Zipcode.ToString();
                    txtBlockPrice.Text = property.Result.Property.Price.ToString() + " € | " + property.Result.Property.Surface?.ToString() + " m² | " + property.Result.Property.PropertyType?.Name + " | " + property.Result.Property.PropertyCategory?.Name;
                    txtBlockDescription.Text = property.Result.Property.Description;
                    txtBlockKitchen.Text = property.Result.Property.Kitchen.Name;
                    txtBlockHeater.Text = property.Result.Property.Heater.Name;

                    RoomType[] rooms = property.Result.Property.RoomType;
                    foreach (RoomType r in rooms)
                    {
                        totalRooms = property.Result.Property.Rooms.Count();
                        txtBlockRoom.Text = totalRooms.ToString() + " pièces: " + r.RoomTypeName + ", ";
                    }

                    if (property.Result.Property.AdditionAddress != null)
                    {
                        txtBlockAddress.Text = property.Result.Property.AdditionAddress;
                    }
                    else
                    {
                        txtBlockAddress.Visibility = Visibility.Collapsed;
                    }
                }
                else
                {
                    MessageBox.Show(user?.ErrorMessage);
                }

            }
        }
    }
}
