using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetAdoptionManagement.Data;
using PetAdoptionManagement.Models;

namespace PetAdoptionManagement.Controllers
{
    public class AdopterController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdopterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Adopter
        public async Task<IActionResult> Index()
        {
            var adopters = await _context.Adopters.ToListAsync();
            return View(adopters);
        }

        // GET: Adopter/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Adopter/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Adopter adopter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(adopter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(adopter);
        }

        // GET: Adopter/Edit/{id}
        public async Task<IActionResult> Edit(int id)
        {
            var adopter = await _context.Adopters.FindAsync(id);
            if (adopter == null)
            {
                return NotFound();
            }
            return View(adopter);
        }

        // POST: Adopter/Edit/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Adopter adopter)
        {
            if (id != adopter.AdopterID)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                _context.Update(adopter);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(adopter);
        }

        // GET: Adopter/Delete/{id}
        public async Task<IActionResult> Delete(int id)
        {
            var adopter = await _context.Adopters.FindAsync(id);
            if (adopter == null)
            {
                return NotFound();
            }
            return View(adopter);
        }

        // POST: Adopter/Delete/{id}
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var adopter = await _context.Adopters.FindAsync(id);
            if (adopter != null)
            {
                _context.Adopters.Remove(adopter);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
