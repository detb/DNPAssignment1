using System.Collections.Generic;
using Models;

namespace DNPAssignment1.Data
{
    public interface IFamilyService
    {
        IList<Family> GetFamilies();
        void AddFamily(Family family);
        void RemoveFamily(int familyID);
        void AddPet(int familyID, Pet pet);
    }
}