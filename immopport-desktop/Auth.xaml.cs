using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Authentication
{

    class Auth
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main(string[] args)
        {
            try
            {
                // Obtain a JWT token.
                StringContent httpContent = new StringContent(@"{ ""matricule"": ""14747"", ""password"": ""Password14!"" }", System.Text.Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.GetAsync("http://api.immopport.cda.ve.manusien-ecolelamanu.fr/api/public/authentification/employee");

                // Save the token for further requests.
                var token = await response.Content.ReadAsStringAsync();

                // Set the authentication header. 
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                // Send a request to fetch data.
                string requestAddress = "http://api.immopport.cda.ve.manusien-ecolelamanu.fr/api/public/authentification/employee/dashboard";
                var employees = await client.GetStringAsync($"{requestAddress}");
            }
            catch (HttpRequestException e)
            {
                
            }
        }
    }
}