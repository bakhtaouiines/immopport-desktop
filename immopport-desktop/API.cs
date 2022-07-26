using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using immopport_desktop.Type;

namespace immopport_desktop
{
    public class API 
    {
        static readonly string baseURL = "http://api.immopport.cda.ve.manusien-ecolelamanu.fr/api/public/";
        static readonly HttpClient client = new HttpClient();

        public object? Token //property
        {
            get;
            set;
        }

        //Constructeur de la classe
        public  API() {
            client.BaseAddress = new Uri(baseURL);
            // add content type
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // add UTF-8
            client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("UTF8"));
        }

        private  async Task<T?> GetApi<T>(string URI)
        {
            try
            {
                // fetch JTW token
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + URI);
                // save the token for further requests.
                T? token = JsonSerializer.Deserialize<T>(response.Content.ReadAsStream());
                Application.Current.Properties["access_token"] = token;

                return token;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return default(T);
            }
        }

        public async Task<Token?> Auth()
        {
            try
            {
                return await GetApi<Token?>("/authentification/employee?matricule=14747&password=Password14!");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return default(Token);
            }
        }

        public async Task<EmployeeResponse?> GetProfile()
        {
            try
            {
                if (Auth() != null)
                {
                    MessageBox.Show(TokenType);
                    // Set the authentication header. 
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(TokenType, AccessToken);

                    // get employee informations
                    HttpResponseMessage employees = await GetApi<EmployeeResponse?>("/employee/dashboard");

                    EmployeeResponse? responseBody = JsonSerializer.Deserialize<EmployeeResponse>(employees.Content.ReadAsStream());
                    if (responseBody != null && responseBody.Employee != null)
                    {
                        MessageBox.Show(responseBody.Employee.Firstname);
                    }
                    else
                    {
                        throw new Exception("Pas de réponse d'employé " + employees.StatusCode);
                    }
                }
                else
                {
                    throw new Exception("Identifiant invalide");
                }      
            }
            catch ( Exception e)
            {
                MessageBox.Show(e.Message);
                return default(EmployeeResponse);
            }
        }

        /*public async Task GetAllEmployees()
        {
            client.BaseAddress = new Uri(baseURL);

            try
            {
                // add content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // add UTF-8
                client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("UTF8"));

                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "/employee/");

            } catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }*/
    }
}