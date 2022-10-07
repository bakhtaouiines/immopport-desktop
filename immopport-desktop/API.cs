using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using immopport_desktop.Type;
namespace immopport_desktop
{
    public class API
    {
         private string baseURL = "http://api.immopport.cda.ve.manusien-ecolelamanu.fr/api/public/";
        //private string baseURL = "http://api-immopport/";
        private HttpClient client = new HttpClient();
        public string AccessToken {get;set;} = String.Empty;
        public string ErrorMessage { get; set; } = String.Empty;
        private string TokenType { get; set; } = String.Empty;
        public HttpStatusCode StatusCode { get; set; }

        //Constructeur de la classe
        public API()
        {
            client.BaseAddress = new Uri(baseURL);
            // add content type
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // add UTF-8
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("UTF8"));
        }

        // generic method 
        private async Task<T?> GetApi<T>(string URI, bool isProtected = false)
        {
            try
            {
                if (isProtected)
                {
                    // Set the authentication header. 
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(TokenType, AccessToken);
                }
                // fetch JTW token
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + URI);
                response.EnsureSuccessStatusCode();
                // save the token for further requests.
                T? content = JsonSerializer.Deserialize<T>(response.Content.ReadAsStream());

                StatusCode = response.StatusCode;

                if (content != null)
                {
                    return content;
                }
                else
                {
                    throw new Exception("Pas de contenu.");
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return default(T);
            }
        }

        private async Task<T?> PutApi<T>(string URI, bool isProtected = false)
        {
            try
            {
                if (isProtected)
                {
                    // Set the authentication header. 
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(TokenType, AccessToken);
                }
                // fetch JTW token
                HttpResponseMessage response = await client.PutAsync(client.BaseAddress + URI, null);
                response.EnsureSuccessStatusCode();
                // save the token for further requests.
                T? content = JsonSerializer.Deserialize<T>(response.Content.ReadAsStream());

                StatusCode = response.StatusCode;

                if (content != null)
                {
                    return content;
                }
                else
                {
                    throw new Exception("Pas de contenu.");
                }
            }
            catch (Exception e)
            {
                ErrorMessage = e.Message;
                return default(T);
            }
        }

        private bool IsLogged()
        {
            return AccessToken != null;
        }

        public async Task Auth(int matricule, string password)
        {
            try
            {
                Token? TokenResponse = await GetApi<Token?>("/authentification/employee?matricule=" + matricule + "&password=" + password);

                if (TokenResponse != null)
                {
                    AccessToken = TokenResponse.AccessToken;
                    TokenType = TokenResponse.TokenType;
                }
                else
                {
                    ErrorMessage = "Le token est vide!";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public async Task<EmployeeResponse?> GetProfile()
        {
            if (IsLogged())
            {
                EmployeeResponse? employee = await GetApi<EmployeeResponse?>("/employee/dashboard", true);

                if (employee != null)
                {
                    return employee;
                }
                else
                {
                    ErrorMessage = "Pas de réponse d'employé " + StatusCode;
                }
            }
            return null;
        }

        /* display  all properties of an agency */
        public async Task<PropertyList?> GetProperty()
        {
            try
            {
                PropertyList? property = await GetApi<PropertyList?>("/employee/properties", true);

                if (property != null)
                {
                    return property;
                }
                else
                {
                    ErrorMessage = "Pas de réponse d'annonce " + StatusCode;
                    MessageBox.Show(ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        /* display all employees according to auth employee id_role */
        public async Task<EmployeesList?> GetEmployees()
        {
            try
            {
                EmployeesList? employees = await GetApi<EmployeesList?>("/employee", true);

                if (employees != null)
                {
                    return employees;
                }
                else
                {
                    ErrorMessage = "Pas de réponse d'employés " + StatusCode;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        /* display all agencies informations (contact page) */
        public async Task<AgenciesList?> GetAgencies()
        {
            try
            {
                AgenciesList? agencies = await GetApi<AgenciesList?>("/contact", true);

                if (agencies != null)
                {
                    return agencies;
                }
                else
                {
                    ErrorMessage = "Pas de réponse d\'agences " + StatusCode;

                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        /* display all customers */
        public async Task<CustomerList?> GetCustomers()
        {
            try
            {
                CustomerList? customers = await GetApi<CustomerList?>("/customer", true);

                if (customers != null)
                {
                    return customers;
                }
                else
                {
                    ErrorMessage = "Pas de clients répertoriés. " + StatusCode;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        /* display auth employee rdv */
        public async Task<RDVList?> GetAuthEmployeeRDV()
        {
            try
            {
                RDVList? employeeRDV = await GetApi<RDVList?>("/rdv", true);
                if (employeeRDV != null)
                {
                    return employeeRDV;
                }
                else
                {
                    ErrorMessage = "Pas de RDV répertoriés. " + StatusCode;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        /* display all employee's properties */
        public async Task<PropertyList?> GetPropertyEmployee()
        {
            try
            {
                PropertyList? property = await GetApi<PropertyList?>("/employee/my-properties", true);

                if (property != null)
                {
                    return property;
                }
                else
                {
                    MessageBox.Show(property.Property.ToString());
                    ErrorMessage = "Pas de réponse d'annonce " + StatusCode;
                    MessageBox.Show(ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        /* display a property by its id */
        public async Task<PropertyResponse?> GetSingleProperty(string propertyId)
        {
            try
            {
                PropertyResponse? property = await GetApi<PropertyResponse?>("/property/" + propertyId);

                if (property != null)
                {
                    return property;
                }
                else
                {
                    ErrorMessage = "Pas de réponse d'annonce !!! " + StatusCode;
                    MessageBox.Show(ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }

        /* update status (is_prospect) */
        public async Task<PropertyResponse?> UpdatePropertyStatus(string propertyId)
        {
            try
            {
                PropertyResponse? property = await PutApi<PropertyResponse?>("/property/status/" + propertyId, true);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return null;
        }
    }
}