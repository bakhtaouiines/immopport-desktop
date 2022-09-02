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
                        throw new Exception("Pas de contenu");
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
                    ErrorMessage = "Pas de r�ponse d'employ� " + StatusCode;
                }
            }
            return null;
        }

        public async Task<PropertyResponse?> GetProperty()
        {
            try
            {
                PropertyResponse? property = await GetApi<PropertyResponse?>("/employee/allProperties", true);
                
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
                    ErrorMessage = "Pas d'employés répertoriés. " + StatusCode;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

        public async Task<AgenciesList?> GetAgencies()
        {
            try
            {
                AgenciesList? agencies = await GetApi<AgenciesList?>("/contact", true);
                //MessageBox.Show(agencies.ToString()+"1");

                if (agencies != null)
                {
                    //MessageBox.Show(agencies.ToString()+"2");

                    return agencies;
                }
                else
                {
                    ErrorMessage = "Pas d'agences répertories. " + StatusCode;
                    MessageBox.Show(ErrorMessage);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return null;
        }

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

        public async Task<PropertyResponse?> GetPropertyEmployee()
        {
            try
            {
                PropertyResponse? property = await GetApi<PropertyResponse?>("/employee/properties", true);

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
    }
}