using Microsoft.AspNetCore.Mvc;

namespace PetAdoptionManagement.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
