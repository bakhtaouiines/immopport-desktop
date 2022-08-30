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
using Newtonsoft.Json;


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
                        
                        //PropertyResponse jsonObj = (PropertyResponse)JsonConvert.DeserializeObject(property.Result.ToString());

                        foreach (var obj in property.Result.Property)
                        {
                            Run idP = new Run();
                            Run titre = new Run();
                            Run address = new Run();

                            titre.DataContext = obj.Titre;
                            idP.DataContext = obj.PropertyId;
                            address.DataContext = obj.Adresse;

                            IdProperty = (int?)idP.DataContext;
                            Titre = (string?)titre.DataContext;
                            Address = (string?)address.DataContext;

                        }


                        // PropertyResponse result = JsonConvert.DeserializeObject<Property>(property.Result.);
                        //MessageBox.Show(property.Result.Property[0].Titre);


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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
