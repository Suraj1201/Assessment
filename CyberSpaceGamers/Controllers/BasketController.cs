using CyberSpaceGamers.Data;
using CyberSpaceGamers.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToAction("Login", "Account");

            var BasketItems = await _db.BasketItems
                .Where(b => b.UserId == user.Id)
                .Include(b => b.Product)
                .ToListAsync();

            return View(BasketItems);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddToBasket(int productId)
        {
            var user = await _userManager.GetUserAsync(User);
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

        [Authorize]
        public async Task<IActionResult> Remove(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var basketItem = await _db.BasketItems
                .FindAsync(id);


            if (basketItem != null)
            {
                _db.BasketItems.Remove(basketItem);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");

        }

        [Authorize]
        public async Task<IActionResult> Checkout()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var BasketItems = await _db.BasketItems
                .Where(b => b.UserId == user.Id)
                .Include(b => b.Product)
                .ToListAsync();

            if (!BasketItems.Any())
            {
                TempData["Message"] = "Your basket is empty!";
                return RedirectToAction("Index");
            }

            string orderNumber = "ORD" + DateTime.Now.ToString("yyyyMMddHHmmss")
                         + "-" + new Random().Next(1000, 9999);

            var order = new Order
            {
                UserId = user.Id,
                OrderDate = DateTime.Now,
                Total = BasketItems.Sum(b => b.Product.Price),
                OrderNumber = orderNumber

            };
            _db.Orders.Add(order);
            await _db.SaveChangesAsync();

            foreach (var item in BasketItems)
            {
                var OrderItem = new OrderItem
                {
                    OrderId = order.Id,
                    ProductId = item.ProductId,
                    Price = item.Product.Price
                };
                _db.OrderItems.Add(OrderItem);
            }

            /*Remove from the basket when checked out*/

            _db.BasketItems.RemoveRange(BasketItems);

            await _db.SaveChangesAsync();

            TempData["CheckoutMessage"] = "Checkout Successful";

            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task <IActionResult> Orders ()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var orders = await _db.Orders
                .Where(o => o.UserId == user.Id && o.OrderDate >= DateTime.Now.AddDays(-30))
                .Include(o => o.Items)
                .ThenInclude(oi => oi.Product)
                .OrderByDescending(o => o.OrderDate)
                .ToListAsync();


            return View(orders);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var order = await _db.Orders
                .Include(o => o.Items) // Include OrderItems
                .FirstOrDefaultAsync(o => o.Id == id && o.UserId == user.Id);

            if (order == null)
                return NotFound();

            _db.OrderItems.RemoveRange(order.Items); // Delete related items
            _db.Orders.Remove(order);                // Delete order itself
            await _db.SaveChangesAsync();

            
            return RedirectToAction("Orders");
        }

    }
}