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
    public partial class Employees : UserControl
    {
        public Employees()
        {
            API user;
            this.DataContext = this;

            if (Application.Current != null && Application.Current.Properties["user"] != null)
            {
                user = (API)Application.Current.Properties["user"];

                try
                {
                    Task<EmployeesList?>? employees = Task.Run(() => user?.GetEmployees());
/*                    employees.Wait();
 *                    
*/                    if (employees != null)
                    {

                        MessageBox.Show(employees.Result.Employee[0].Phone);
                        /*Parallel.ForEach<EmployeeResponse>(employees, employee =>
                        {
                            MessageBox.Show(employee.Employee.Lastname);

                        });*/

                        foreach(var employee in employees)
                        {
                            employee.Employees.Clear();
                        }

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

        private void DisplayProperty(object sender, RoutedEventArgs e)
        {

        }
    }
}
