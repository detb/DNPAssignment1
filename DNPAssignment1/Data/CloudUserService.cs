using DNPAssignment1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using DNPAssignment1.Models;

namespace DNPAssignment1.Data
{
    public class CloudUserService : IUserService
    {

        private string uri = "https://192.168.1.69:5003";
        private readonly HttpClient client;

        public CloudUserService()
        {
            client = getNewHttpClient();
        }


        public async Task<User> ValidateUser(string userName, string pass)
        {
            Task<string> stringAsync = client.GetStringAsync($"{uri}/api/userlogin?userName={userName}&pass={pass}");
            string message = await stringAsync;

            User result = JsonConvert.DeserializeObject<User>(message);
            return result;
        }
        
        private HttpClient getNewHttpClient()
        {
            //HttpClient client = new HttpClient();
            //Workaround: https://stackoverflow.com/questions/52939211/the-ssl-connection-could-not-be-established

            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            // Pass the handler to httpclient(from you are calling api)
            return new HttpClient(clientHandler);
        }
    }
}
