using System.Collections.Generic;
using Models;

namespace DNPAssignment1.Data
{
    public interface ICachingService
    {
        public IList<Adult> GetAdults();
        public IList<Child> GetChildren();
        public IList<Pet> GetPets();

        public void AddChild(Child child);
        public void AddAdult(Adult adult);
        public void AddPet(Pet pet);
        public void AddStreetName(string streetname);
        public void AddHouseNumber(int housenumber);
        public Family GetFamily();

    }
}