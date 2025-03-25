using System.ComponentModel.DataAnnotations;

namespace PetAdoptionManagement.Models
{
    public class Adopter
    {
        [Key]
        public int AdopterID { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        public string? Phone { get; set; }
        public string? Address { get; set; }

        // ✅ One adopter can adopt multiple pets
        public List<Pet> AdoptedPets { get; set; } = new();
    }
}
