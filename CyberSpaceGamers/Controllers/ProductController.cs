using CyberSpaceGamers.Data;
using CyberSpaceGamers.Models;
using Microsoft.AspNetCore.Mvc;

namespace CyberSpaceGamers.Controllers
{
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext _db;
        
        public ProductController(ApplicationDbContext db)

        {  
            _db = db; 
        
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _db.Products.ToList();
            return View(objProductList);
        }
    }
}
