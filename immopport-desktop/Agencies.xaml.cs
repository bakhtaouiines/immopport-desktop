using immopport_desktop.Type;
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
    public partial class Agencies : UserControl
    {
        public Agencies()
        {
            API user;
            InitializeComponent();


            if (Application.Current != null && Application.Current.Properties["user"] != null)
            {
                user = (API)Application.Current.Properties["user"];

                try
                {
                    Task<AgenciesList?>? agencies = Task.Run(() => user?.GetAgencies());
                    //agencies.Wait();

                    if (agencies != null)
                    {
                        List<Agency> items = new List<Agency>(agencies.Result.Agency);
                        agenciesList.ItemsSource = items;
                    }
                    else
                    {
                        MessageBox.Show("ERREUR");
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
            }
           

        }
    }
}
