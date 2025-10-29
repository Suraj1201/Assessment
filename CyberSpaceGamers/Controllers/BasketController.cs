using Microsoft.AspNetCore.Mvc;

namespace CyberSpaceGamers.Controllers
{
    public class BasketController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
