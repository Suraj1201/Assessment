using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CyberSpaceGamers.Models.ViewModels
{
    // This represents the data needed for a single product card in the UI.
    public class ProductCardViewModel
    {
        public int Id { get; set; }
        // Product ID (needed for actions like "Add to Cart").

        public string Name { get; set; } = "";
        // Product name to display.

        public string? ShortDescription { get; set; }
        // Short description shown under the product name.

        public decimal Price { get; set; }
        // Price displayed on the card.

        public string Genre { get; set; } = "";
        // Genre displayed on the card or used for filtering.

    }
}

