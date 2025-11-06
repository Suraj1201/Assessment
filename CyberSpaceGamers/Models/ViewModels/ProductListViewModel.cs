using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CyberSpaceGamers.Models.ViewModels
{
    public class ProductListViewModel
    {
        // This represents the data for the entire product listing page.
   
        public string? Search { get; set; }

        public string? Genre { get; set; }

        public string? Sort { get; set; }

        public int Page { get; set; } = 1;

        public int TotalPages { get; set; }

        public IEnumerable<Product> Products { get; set; } = new List<Product>();

        public IEnumerable<string> Genres { get; set; } = new List<string>();
       
    }
}
