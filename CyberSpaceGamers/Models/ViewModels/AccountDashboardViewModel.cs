using System.Collections.Generic;

namespace CyberSpaceGamers.Models.ViewModels
{
    // One tile on the My Account dashboard (e.g., Profile / Orders / Wishlist)
    public class DashboardTile
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Icon { get; set; } = "bi bi-circle"; // Bootstrap Icons CSS class
        public string Controller { get; set; } = "";
        public string Action { get; set; } = "";
    }

    // The page model for /Account/Dashboard
    public class AccountDashboardViewModel
    {
        public List<DashboardTile> Tiles { get; set; } = new();
    }
}