using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CyberSpaceGamers.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public required string Name { get; set; }
        public string? ShortDescription { get; set; }

        [Precision(18,2)]
        public decimal Price { get; set; }
        public required string AgeRating { get; set; }
        public required string Genre { get; set; }
    }
}
