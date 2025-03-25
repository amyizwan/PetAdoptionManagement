using Microsoft.AspNetCore.Mvc;

namespace YourProjectNamespace.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
