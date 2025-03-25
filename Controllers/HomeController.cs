using Microsoft.AspNetCore.Mvc;
using PetAdoptionManagement.Data;
using PetAdoptionManagement.Models;
using System.Linq;

namespace PetAdoptionAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            ViewData["TotalPets"] = _context.Pets.Count();
            ViewData["TotalAdopters"] = _context.Adopters.Count();

            ViewData["RecentPets"] = _context.Pets
                .OrderByDescending(p => p.PetID)
                .Take(5)
                .ToList();

            ViewData["RecentAdopters"] = _context.Adopters
                .OrderByDescending(a => a.AdopterID)
                .Take(5)
                .ToList();

            return View();
        }
    }
}
