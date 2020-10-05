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
            }
        }


        public IList<Family> GetFamilies()
        {
            List<Family> tmp = new List<Family>();
            return tmp;
        }

        public void AddFamily(Family family)
        {
            int max = families.Max(family => family.Id);
            family.Id = (++max);
            families.Add(family);
            WriteFamiliesFile();
        }

        public void RemoveFamily(int familyID)
        {
            Family toRemove = families.First(f => f.Id == familyID);
            families.Remove(toRemove);
            WriteFamiliesFile();
        }

        public void AddPet(int familyID, Pet pet)
        {
            Family toUpdate = families.First(f => f.Id == familyID);
            toUpdate.Pets.Add(pet);
            WriteFamiliesFile();
        }
        

        private void WriteFamiliesFile()
        {
            string productsAsJson = JsonSerializer.Serialize(families);
            File.WriteAllText(familyFile, productsAsJson);
        }
    }
}