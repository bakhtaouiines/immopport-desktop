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

    public partial class EmployeeRDV : UserControl
    {
        public EmployeeRDV()
        {
            API user;

            InitializeComponent();

            if (Application.Current != null && Application.Current.Properties["user"] != null)
            {
                user = (API)Application.Current.Properties["user"];

                try
                {
                    Task<RDVList?>? employeeRDV = Task.Run(() => user?.GetAuthEmployeeRDV());

                    if (employeeRDV != null)
                    {
/*                        MessageBox.Show(employeeRDV.Result.RDV[0].IsVisit.ToString());
*/                        List<RDV> items = new List<RDV>(employeeRDV.Result.RDV);
                        RDVList.ItemsSource = items;
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
    }
}
