using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Models {
public class Family {

        //public int Id { get; set; }

        [NotNull]
        [Required(AllowEmptyStrings = false)]
        public string StreetName { get; set; }

    [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid house number")]
        public int HouseNumber{ get; set; }
    public List<Adult> Adults { get; set; }
    public List<Child> Children{ get; set; }
    public List<Pet> Pets{ get; set; }

    public Family() {
        Adults = new List<Adult>();     
    }

}


}