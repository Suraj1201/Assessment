using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CyberSpaceGamers.Models
{

    // This class represents the Product table in the database.
    // Each instance of this class corresponds to one row in the Products table.
    public class Product
    {
        
        public int Id { get; set; }
        // Primary key. EF automatically treats 'Id' as the primary key.

        [Required(ErrorMessage ="Name is Required")]
        [MaxLength(200)]
        [DisplayName("Product Name")]
        public string Name { get; set; } = string.Empty;
        // Name of the product. Required means it cannot be null in the database.

        [MaxLength(300)]
        public string? ShortDescription { get; set; }
        // Optional short description about the product.

        [Precision(18,2)]
        [Range(0.01, 100.99, ErrorMessage = "Price must be between 0.01-100.99")]
        public decimal Price { get; set; }
        // Price of the product. Range ensures the value stays within 0-9999.

        [RegularExpression(@"^\d{1,2}\+?$", ErrorMessage = "Enter a valid age rating like 3+, 7+, 12+.")]
        public required string AgeRating { get; set; }
        // Age rating for the product, e.g., 3, 7, 12, etc.

        [Required]
        public string Genre { get; set; } = string.Empty;
        // Genre of the product. Required so it must have a value.
    }
}
