using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PetAdoptionManagement.Data;
using PetAdoptionManagement.Models;
using System.Linq;
using System.Threading.Tasks;

namespace PetAdoptionManagement.Controllers
{
    public class PetController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PetController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Pet
        public async Task<IActionResult> Index()
        {
            var pets = await _context.Pets
                .Include(p => p.Adopter) // Include Adopter info
                .ToListAsync();
            return View(pets);
        }

        // GET: Pet/Details/{id}
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var pet = await _context.Pets
                .Include(p => p.Adopter)
                .FirstOrDefaultAsync(p => p.PetID == id);

            if (pet == null) return NotFound();

            return View(pet);
        }

        // GET: Pet/Create
        public IActionResult Create()
        {
            ViewBag.Adopters = new SelectList(_context.Adopters, "AdopterID", "FullName"); // Load adopters
            return View();
        }

        // POST: Pet/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Pet pet)
        {
            if (ModelState.IsValid)
            {
                if (pet.Status == "Adopted" && pet.AdopterID == null)
                {
                    ModelState.AddModelError("AdopterID", "An adopter must be selected if the pet is adopted.");
                    ViewBag.Adopters = new SelectList(_context.Adopters, "AdopterID", "FullName");
                    return View(pet);
                }

                _context.Pets.Add(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Adopters = new SelectList(_context.Adopters, "AdopterID", "FullName");
            return View(pet);
        }

        // GET: Pet/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var pet = await _context.Pets.FindAsync(id);
            if (pet == null) return NotFound();

            ViewBag.Adopters = new SelectList(_context.Adopters, "AdopterID", "FullName", pet.AdopterID); // Load adopters
            return View(pet);
        }

        // POST: Pet/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Pet pet)
        {
            if (id != pet.PetID) return NotFound();

            if (ModelState.IsValid)
            {
                if (pet.Status == "Adopted" && pet.AdopterID == null)
                {
                    ModelState.AddModelError("AdopterID", "An adopter must be selected if the pet is adopted.");
                    ViewBag.Adopters = new SelectList(_context.Adopters, "AdopterID", "FullName", pet.AdopterID);
                    return View(pet);
                }

                _context.Update(pet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Adopters = new SelectList(_context.Adopters, "AdopterID", "FullName", pet.AdopterID);
            return View(pet);
        }

        // POST: Pet/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet != null)
            {
                _context.Pets.Remove(pet);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
