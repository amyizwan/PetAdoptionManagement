using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetAdoptionManagement.Models
{
    public class Pet
    {
        [Key]
        public int PetID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Breed { get; set; }
        public int Age { get; set; }
        public string? Description { get; set; }

        public string Status { get; set; } = "Available"; // Default status

        // ✅ Foreign Key
        public int? AdopterID { get; set; }

        [ForeignKey("AdopterID")]
        public Adopter? Adopter { get; set; }
    }

}
