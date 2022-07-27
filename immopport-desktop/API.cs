using System;
using System.Net;
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
        private string baseURL = "http://api.immopport.cda.ve.manusien-ecolelamanu.fr/api/public/";
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
                // save the token for further requests.
                T? content = JsonSerializer.Deserialize<T>(response.Content.ReadAsStream());
                StatusCode = response.StatusCode;
                MessageBox.Show(StatusCode.ToString());
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

       
        public async Task<bool> Auth(int matricule, string password)
        {
            MessageBox.Show("toto");
            Token? TokenResponse = await GetApi<Token?>("/authentification/employee?matricule="+matricule+"&password="+password);
            MessageBox.Show("token " + TokenResponse.AccessToken);
            if (TokenResponse != null)
            {
                AccessToken = TokenResponse.AccessToken;
                TokenType = TokenResponse.TokenType;
            }
            else
            {
                ErrorMessage = "Ca va pas";
                return false;
            }
            return true;
        }

        public async Task<Employee?> GetProfile()
        {
            if (IsLogged())
            {
                // get employee informations
                Employee? employee = await GetApi<Employee?>("/employee/dashboard", true);

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

    }
}