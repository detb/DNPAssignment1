using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using DNPAssignment1.Models;
using Models;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace DNPAssignment1.Data
{
    public class CloudFamilyService : IFamilyService
    {
        private string uri = "https://localhost:44352";
        private readonly HttpClient client;

        public CloudFamilyService() {
            client = new HttpClient();
        }
        
        public async Task<IList<Family>> GetFamiliesAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/api/allfamilies");
            string message = await stringAsync;

            List<Family> result = JsonConvert.DeserializeObject<List<Family>>(message);
            return result;
        }

        public async Task AddFamilyAsync(Family family)
        {
            string todoAsJson = JsonSerializer.Serialize(family);
            HttpContent content = new StringContent(todoAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync(uri+"/family", content);
        }

        public async Task RemoveFamilyAsync(string StreetName, int HouseNumber)
        {
            await client.DeleteAsync($"{uri}/family?streetName={StreetName}&houseNumber={HouseNumber}");
        }

        public async Task AddPetAsync(string StreetName, int HouseNumber, Pet pet)
        {
            throw new System.NotImplementedException();
        }

        public void updateFamilyList()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Family> GetFamilyAsync(string StreetName, int HouseNumber)
        {
            Task<string> stringAsync = client.GetStringAsync($"{uri}/family?streetName={StreetName}&houseNumber={HouseNumber}");
            string message = await stringAsync;

            Family result = JsonConvert.DeserializeObject<Family>(message);
            return result;
        }

        public async Task AddAdultAsync(Adult adult, Family family)
        {
            throw new System.NotImplementedException();
        }

        public async Task<User> LogInUser(string userName, string pass)
        {
            Task<string> stringAsync = client.GetStringAsync($"{uri}/api/userlogin?userName={userName}&pass={pass}");
            string message = await stringAsync;

            User result = JsonConvert.DeserializeObject<User>(message);
            return result;
        }
    }
}