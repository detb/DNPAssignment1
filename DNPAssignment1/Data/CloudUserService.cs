using DNPAssignment1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DNPAssignment1.Data
{
    public class CloudUserService : IUserService
    {

        private string uri = "https://localhost:44352";
        private readonly HttpClient client;

        public CloudUserService()
        {
            client = new HttpClient();
        }


        public async Task<User> ValidateUser(string userName, string pass)
        {
            Task<string> stringAsync = client.GetStringAsync($"{uri}/api/userlogin?userName={userName}&pass={pass}");
            string message = await stringAsync;

            User result = JsonConvert.DeserializeObject<User>(message);
            return result;
        }
    }
}
