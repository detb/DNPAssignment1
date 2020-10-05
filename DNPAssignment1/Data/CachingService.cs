using System.Collections.Generic;
using Models;

namespace DNPAssignment1.Data
{
    public class CachingService : ICachingService
    {
        private Family family;
        private IList<Adult> adults;
        private IList<Child> children;
        private IList<Pet> pets;
        
        public IList<Adult> GetAdults()
        {
            List<Adult> tmp = new List<Adult>(adults);
            return tmp;
        }
        
        public IList<Child> GetChildren()
        {
            List<Child> tmp = new List<Child>(children);
            return tmp;
        }

        public IList<Pet> GetPets()
        {
            List<Pet> tmp = new List<Pet>(pets);
            return tmp;
        }

        public void AddChild(Child child)
        {
            children.Add(child);
        }

        public void AddAdult(Adult adult)
        {
            adults.Add(adult);
        }

        public void AddPet(Pet pet)
        {
            pets.Add(pet);
        }

        public void AddStreetName(string streetname)
        {
            family.StreetName = streetname;
        }

        public void AddHouseNumber(int housenumber)
        {
            family.HouseNumber = housenumber;
        }

        public Family GetFamily()
        {
            family.Adults = (List<Adult>) GetAdults();
            family.Children = (List<Child>) GetChildren();
            family.Pets = (List<Pet>) GetPets();
            return family;
        }
    }
}