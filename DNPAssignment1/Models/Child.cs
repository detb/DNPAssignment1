using System.Collections.Generic;
using DNPAssignment1.Models;
using Models;

namespace Models {
public class Child : Person {
    
    public List<ChildInterest> ChildInterests { get; set; } = new List<ChildInterest>(); 
    public List<ChildInterestTable> ChildInterestTables { get; set; } = new List<ChildInterestTable>();
   // public List<Pet> Pets { get; set; }

    public void Update(Child toUpdate) {
        base.Update(toUpdate);
        ChildInterests = toUpdate.ChildInterests;
       // Pets = toUpdate.Pets;
    }
    
    }
}