using CyberSpaceGamers.Data;
using CyberSpaceGamers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace CyberSpaceGamers.Controllers
{
    public class BasketController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public BasketController(ApplicationDbContext db, UserManager<ApplicationUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToAction("Login", "Account");

            var BasketItems = await _db.BasketItems
                .Where(b => b.UserId == user.Id )
                .Include(b => b.Product)
                .ToListAsync();

            return View(BasketItems);
        }

        [HttpPost]

        public async Task<IActionResult> AddToBasket(int productId)
        {
            var user = await _userManager.GetUserAsync (User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var ExistingItems = await _db.BasketItems
                .FirstOrDefaultAsync(b => b.UserId == user.Id && b.ProductId == productId);

            if (ExistingItems == null)
            {
                var basketItem = new BasketItem
                {
                    ProductId = productId,
                    UserId = user.Id,
                };
                _db.BasketItems.Add(basketItem);
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Remove(int id)
        {
            var item = await _db.BasketItems.FindAsync(id);
                
            if (item != null)
            {
                _db.BasketItems.Remove(item);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");

        }

        public IActionResult Orders ()
        {
            return View();
        }
    }
}