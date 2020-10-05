using System.Collections.Generic;
using Models;

namespace DNPAssignment1.Data
{
    public interface IFamilyService
    {
        IList<Family> GetFamilies();
        void AddFamily(Family family);
        void RemoveFamily(string StreetName, int HouseNumber);
        void AddPet(string StreetName, int HouseNumber, Pet pet);

        void AddAdult(Adult adult, Family family);
    }
}