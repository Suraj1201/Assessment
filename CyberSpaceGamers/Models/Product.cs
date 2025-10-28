using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CyberSpaceGamers.Models
{

    // This class represents the Product table in the database.
    // Each instance of this class corresponds to one row in the Products table.
    public class Product
    {
        public int Id { get; set; }
        // Primary key. EF automatically treats 'Id' as the primary key.

        [Required]
        public string Name { get; set; } = string.Empty;
        // Name of the product. Required means it cannot be null in the database.


        public string? ShortDescription { get; set; } 
        // Optional short description about the product.

        [Range(0, 9999)]
        public decimal Price { get; set; }
        // Price of the product. Range ensures the value stays within 0-9999.

        
        public required string AgeRating { get; set; }
        // Age rating for the product, e.g., 3, 7, 12, etc.

        [Required]
        public string Genre { get; set; } = string.Empty;
        // Genre of the product. Required so it must have a value.
    }
}
