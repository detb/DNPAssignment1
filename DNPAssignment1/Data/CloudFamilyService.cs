using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Models;

namespace DNPAssignment1.Data
{
    public class CloudFamilyService : IFamilyService
    {
        private string uri = "https://localhost:5003";
        private readonly HttpClient client;

        public CloudFamilyService() {
            client = new HttpClient();
        }
        
        public async Task<IList<Family>> GetFamiliesAsync()
        {
            Task<string> stringAsync = client.GetStringAsync(uri + "/family");
            string message = await stringAsync;
            List<Family> result = JsonSerializer.Deserialize<List<Family>>(message);
            return result;
        }

        public async Task AddFamilyAsync(Family family)
        {
            throw new System.NotImplementedException();
        }

        public async Task RemoveFamilyAsync(string StreetName, int HouseNumber)
        {
            throw new System.NotImplementedException();
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
            throw new System.NotImplementedException();
        }

        public async Task AddAdultAsync(Adult adult, Family family)
        {
            throw new System.NotImplementedException();
        }
    }
}