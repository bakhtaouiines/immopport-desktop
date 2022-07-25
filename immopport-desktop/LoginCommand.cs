using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;
using immopport_desktop.Type;

namespace immopport_desktop.commands
{

    public class LoginCommand 
    {
        public async Task Main()
        {
            string baseURL = "http://api.immopport.cda.ve.manusien-ecolelamanu.fr/api/public/";
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(baseURL);

            try
            {
                // Obtain a JWT token.
              //  StringContent httpContent = new StringContent(@"{ ""matricule"": ""14747"", ""password"": ""Password14!"" }", System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.GetAsync(client.BaseAddress + "/authentification/employee?matricule=14747&password=Password14!");
                MessageBox.Show("Before token");
                // Save the token for further requests.
                Token? token =  JsonSerializer.Deserialize<Token>(response.Content.ReadAsStream());
                if(token != null)
                {
                    MessageBox.Show(token.AccessToken);
                    // Set the authentication header. 
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(token.TokenType, token.AccessToken);

                    // Send a request to fetch data.
                    string requestAddress = "http://api.immopport.cda.ve.manusien-ecolelamanu.fr/api/public/authentification/employee/dashboard";
                    var employees = await client.GetStringAsync($"{requestAddress}");
                    // response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    MessageBox.Show(token.AccessToken);
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