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
        public async Task Auth()
        {
            string baseURL = "http://api.immopport.cda.ve.manusien-ecolelamanu.fr/api/public/";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseURL);

            try
            {
                // add content type
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // add UTF-8
                client.DefaultRequestHeaders.AcceptEncoding.Add(new StringWithQualityHeaderValue("UTF8"));
                // fetch JTW token
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "/authentification/employee?matricule=14747&password=Password14!");
                // save the token for further requests.
                Token? token = JsonSerializer.Deserialize<Token>(response.Content.ReadAsStream());

                if (token != null)
                {                  
                    // Set the authentication header. 
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.AccessToken);
                    
                    // get employee informations
                    HttpResponseMessage employees = await client.GetAsync(client.BaseAddress + "/employee/dashboard");

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
            }
        }
    }
}