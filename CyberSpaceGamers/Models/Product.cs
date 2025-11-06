using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CyberSpaceGamers.Models
{

    // This class represents the Product table in the database.
    public class Product
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        [MaxLength(200)]
        [DisplayName("Product Name")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(300)]
        public string? ShortDescription { get; set; }

        [Precision(18,2)]
        [Range(0.01, 100.99, ErrorMessage = "Price must be between 0.01-100.99")]
        public decimal Price { get; set; }
        // Range ensures the value stays within 0.01-100.99.

        [RegularExpression(@"^\d{1,2}\+?$", ErrorMessage = "Enter a valid age rating like 3+, 7+, 12+.")]
        public required string AgeRating { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-z]+$", ErrorMessage = "Genre can only contain letters")] 
        public string Genre { get; set; } = string.Empty;
    }
}
