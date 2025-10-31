using System.Diagnostics;
using CyberSpaceGamers.Models;
using Microsoft.AspNetCore.Mvc;

namespace CyberSpaceGamers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
        // This action just returns the Privacy.cshtml view.
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // this action just returns the About.cshtml view
        public IActionResult About()
        {
            return View();
        }

        // this action just returns the Support.cshtml view
        public IActionResult Support()
        {
            return View();
        }

        // this action just returns the Contact.cshtml
        public IActionResult Contact()
        {
            return View();
        }
    }   

}
