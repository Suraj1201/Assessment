using CyberSpaceGamers.Data;
using CyberSpaceGamers.Models;
using CyberSpaceGamers.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
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
                   /* p.Name.Contains(s, StringComparison.OrdinalIgnoreCase) ||
                    (p.ShortDescription != null && p.ShortDescription.Contains(s, StringComparison.OrdinalIgnoreCase)));*/
            }

            query = sort switch
            {
                "priceAsc" => query.OrderBy(p => p.Price),
                "priceDesc" => query.OrderByDescending(p => p.Price),
                "name" => query.OrderBy(p => p.Name),
                _ => query
            };

            const int pageSize = 6;
            var totalItems = query.Count();
            var totalPages = Math.Max(1, (int)Math.Ceiling(totalItems / (double)pageSize));
            page = Math.Clamp(page, 1, totalPages);
            var items = query.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            

            var vm = new ProductListViewModel
            {
                Search = search,
                Genre = genre,
                Sort = sort,
                Genres =  _db.Products.Select(p => p.Genre).Distinct(),
                Products = items,
                Page = page,
                TotalPages = totalPages
            };

            return View(vm);
        }
    }
}