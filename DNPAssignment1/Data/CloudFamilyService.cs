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
        private string uri = "https://10.152.210.25:5003";
        private readonly HttpClient client;

        public CloudFamilyService() {
            client = getNewHttpClient();
        }
        
        public async Task<IList<Family>> GetFamiliesAsync()
        {
            string message = await client.GetStringAsync(uri + "/api/allfamilies");
            
            List<Family> result = JsonConvert.DeserializeObject<List<Family>>(message);
            return result;
        }

        public async Task AddFamilyAsync(Family family)
        {
            string todoAsJson = JsonSerializer.Serialize(family);
            HttpContent content = new StringContent(todoAsJson,
                Encoding.UTF8,
                "application/json");
            await client.PostAsync(uri+"/api/family", content);
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
            Task<string> stringAsync = client.GetStringAsync($"{uri}/api/family?streetName={StreetName}&houseNumber={HouseNumber}");
            string message = await stringAsync;

            Family result = JsonConvert.DeserializeObject<Family>(message);
            return result;
        }

        public async Task AddAdultAsync(Adult adult, Family family)
        {
            throw new System.NotImplementedException();
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