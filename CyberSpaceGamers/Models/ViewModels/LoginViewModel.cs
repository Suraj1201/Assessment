using System.ComponentModel.DataAnnotations;

namespace CyberSpaceGamers.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username can contain only letters, numbers, and underscores")]
        public required string Username { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public required string Password { get; set; } = string.Empty;
    }
}
