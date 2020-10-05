using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Models;

namespace DNPAssignment1.Data
{
    public class FamilyService : IFamilyService
    {
        private string familyFile = "families.json";
        private IList<Family> families;

        public FamilyService()
        {
            if (!File.Exists(familyFile))
            {
                throw new System.NotImplementedException();
            }
            else
            {
                string content = File.ReadAllText(familyFile);
                families = JsonSerializer.Deserialize<IList<Family>>(content);
                System.Console.WriteLine(families);
            }
        }


        public IList<Family> GetFamilies()
        {
            List<Family> tmp = new List<Family>(families);
            return tmp;
        }

        public void AddFamily(Family family)
        {
            families.Add(family);
            WriteFamiliesFile();
        }

        public void RemoveFamily(string StreetName, int HouseNumber)
        {
            Family toRemove = families.First(f => (f.StreetName == StreetName && f.HouseNumber == HouseNumber));
            families.Remove(toRemove);
            WriteFamiliesFile();
        }

        public void AddPet(string StreetName, int HouseNumber, Pet pet)
        {
            Family toUpdate = families.First(f => (f.StreetName == StreetName && f.HouseNumber == HouseNumber));
            toUpdate.Pets.Add(pet);
            WriteFamiliesFile();
        }

        public void AddAdult(Adult adult, Family family)
        {
            family.Adults.Add(adult);
        }


        private void WriteFamiliesFile()
        {
            string productsAsJson = JsonSerializer.Serialize(families);
            File.WriteAllText(familyFile, productsAsJson);
        }
    }
}