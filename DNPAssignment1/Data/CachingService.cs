using System.Collections.Generic;
using DNPAssignment1.Models;
using Models;

namespace DNPAssignment1.Data
{
    public class CachingService : ICachingService
    {
        private Family family;
        private IList<Adult> adults = new List<Adult>();
        private IList<Child> children = new List<Child>();
        private IList<Pet> pets = new List<Pet>();
        
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
            if (family == null)
                family = new Family();
            family.StreetName = streetname;
        }

        public void AddHouseNumber(int housenumber)
        {
            if (family == null)
                family = new Family();
            family.HouseNumber = housenumber;
        }

        public Family GetFamily()
        {
            family.Adults = (List<Adult>)adults;
            family.Children = (List<Child>) children;
            family.Pets = (List<Pet>) pets;
            return family;
        }
    }
}