using Microsoft.AspNetCore.Mvc;
using CyberSpaceGamers.Models.ViewModels;
using System.Collections.Generic;

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

        // GET: /Account/Dashboard
        public IActionResult Dashboard()
        {
            var vm = new AccountDashboardViewModel
            {
                Tiles = new List<DashboardTile>
                {
                    new DashboardTile
                    {
                        Title = "Profile",
                        Description = "View and edit your profile",
                        Icon = "bi-person",
                        Controller = "Account",
                        Action = "Profile"
                    },
                    new DashboardTile
                    {
                        Title = "Orders",
                        Description = "See your order history",
                        Icon = "bi-receipt",
                        Controller = "Account",
                        Action = "Orders"
                    },
                    new DashboardTile
                    {
                        Title = "Wishlist",
                        Description = "Saved games to buy later",
                        Icon = "bi-heart",
                        Controller = "Product",
                        Action = "Index"   // placeholder; change to Wishlist later
                    }
                }
            };

            return View(vm);
        }

        // GET: /Account/Orders
        public IActionResult Orders()
        {
            return View(); // view-only placeholder
        }

        // GET: /Account/Settings
        public IActionResult Wishlist()
        {
            return View(); // view-only placeholder
        }

        // GET: /Account/Profile
        public IActionResult Profile()
        {
            return View(); // view-only placeholder
        }
    }
}
