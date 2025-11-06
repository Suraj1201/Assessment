using CyberSpaceGamers.Data;
using CyberSpaceGamers.Models;
using CyberSpaceGamers.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace CyberSpaceGamers.Controllers
{
    public class ProductController : Controller
    {

        private readonly ApplicationDbContext _db;

        public ProductController(ApplicationDbContext db)

        {
            _db = db;

        }
        public IActionResult Index(string? search, string? genre, string? sort, int page = 1)
        {
            IQueryable<Product> query = _db.Products;
                        
            if (!string.IsNullOrWhiteSpace(genre))
            {
                var g = genre.Trim();
                query = query.Where(p => p.Genre != null && p.Genre.ToLower() == g.ToLower());
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                var s = search.Trim().ToLower();
                query = query.Where(p => p.Name.ToLower().Contains(s));
            }

            
            query = sort switch
            {
                "priceAsc" => query.OrderBy(p => p.Price),
                "priceDesc" => query.OrderByDescending(p => p.Price),
                "name" => query.OrderBy(p => p.Name),
                _ => query.OrderBy(p => p.Id)

            };

            

            const int pageSize = 9;
            var totalItems = query.Count();
            var totalPages = Math.Max(1, (int)Math.Ceiling(totalItems / (double)pageSize));
            page = Math.Clamp(page, 1, totalPages);
            var items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            

            var vm = new ProductListViewModel
            {
                Search = search,
                Genre = genre,
                Sort = sort,
                Genres = _db.Products
                        .Where(p => p.Genre != null)
                        .Select(p => p.Genre!)
                        .Distinct()
                        .OrderBy(g => g),
                Products = items,
                Page = page,
                TotalPages = totalPages
            };

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var product = _db.Products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }    

            return View(product);
        }

        [Authorize]
        public IActionResult ProductControl()
        {
            List<Product> objProductList = _db.Products.ToList();
            return View(objProductList);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(Product obj)
        {
            if (obj.Name == obj.ShortDescription)
            {
                ModelState.AddModelError("name", "The Short Description cannot exactly match the name");
            }
            if(ModelState.IsValid)
            {
                _db.Products.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("ProductControl");

            }
           return View(obj);
                       
        }
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            Product? ProductFromDb = _db.Products.Find(id);

            if (ProductFromDb == null)
            {
                return NotFound();

            }

            return View(ProductFromDb);

        }
        [HttpPost]
        [Authorize]
        public IActionResult Edit(Product obj)
        {
            if(ModelState.IsValid)
            {
                _db.Products.Update(obj);
                _db.SaveChanges(true);

                return RedirectToAction("ProductControl");
            }

            return View();
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? ProductFromDb = _db.Products.Find(id);

            if (ProductFromDb == null)
            {
                return NotFound();

            }
            return View(ProductFromDb);
        }
        [HttpPost, ActionName("Delete")]
        [Authorize]
        public IActionResult DeletePOST(int? id)
        {
            Product? obj = _db.Products.Find(id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Products.Remove(obj);
            _db.SaveChanges();

            return RedirectToAction("ProductControl");
        }
    }

}