using Microsoft.EntityFrameworkCore;
using PetAdoptionManagement.Data;
using PetAdoptionManagement.Models;

namespace PetAdoptionManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pet> Pets { get; set; }
        public DbSet<Adopter> Adopters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adopter>()
                .HasMany(a => a.AdoptedPets)
                .WithOne(p => p.Adopter)
                .HasForeignKey(p => p.AdopterID)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
