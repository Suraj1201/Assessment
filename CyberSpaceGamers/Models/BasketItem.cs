using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CyberSpaceGamers.Models
{
    public class BasketItem
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        [Required]
        public string UserId { get; set; } = string.Empty;

        public int Quantity { get; set; } = 1;

    }
}
