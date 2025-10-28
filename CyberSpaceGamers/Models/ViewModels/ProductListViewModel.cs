using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CyberSpaceGamers.Models.ViewModels
{
    public class ProductListViewModel
    {
        // This represents the data for the entire product listing page.
   
        public string? Search { get; set; }
        // The search text entered by the user.

        public string? Genre { get; set; }
        // Selected genre filter (if any).

        public string? Sort { get; set; }
        // Sort choice: "priceAsc", "priceDesc", or "name".

        public int Page { get; set; } = 1;
        // Current page number for pagination.

        public int TotalPages { get; set; }
        // Total number of pages for pagination.

        public IEnumerable<ProductCardViewModel> Products { get; set; } = new List<ProductCardViewModel>();
        // The list of products to display on this page.

        public IEnumerable<string> Genres { get; set; } = new List<string>();
        // All genres for the left-hand sidebar filter.
       
    }
}
