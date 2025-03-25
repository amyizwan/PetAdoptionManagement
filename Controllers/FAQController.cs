using Microsoft.AspNetCore.Mvc;

namespace PetAdoptionManagement.Controllers
{
    public class FAQController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
