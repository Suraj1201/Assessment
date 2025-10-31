using Microsoft.AspNetCore.Mvc;

namespace CyberSpaceGamers.Controllers
{
    public class AccountController : Controller
    {
        // GET: /Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            return View();
        }

        // /Account
        public IActionResult Index()
        {
            return View(); // will render Views/Account/Index.cshtml
        }

        // GET: /Account/Orders
        public IActionResult Orders()
        {
            // simple view-only page for now
            return View();
        }

        // GET: /Account/Profile
        public IActionResult Profile()
        {
            // simple view-only page for now
            return View();
        }
    }
}