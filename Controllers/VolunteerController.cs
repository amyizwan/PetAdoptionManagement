using Microsoft.AspNetCore.Mvc;

namespace PetAdoptionManagement.Controllers
{
    public class VolunteerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
