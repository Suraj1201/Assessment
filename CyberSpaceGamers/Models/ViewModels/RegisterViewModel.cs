using System.ComponentModel.DataAnnotations;

namespace CyberSpaceGamers.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Key]
        // Primary key. EF automatically treats 'Id' as the primary key.
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters")]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Username can contain only letters, numbers, and underscores")]
        // Username of the user. First and last name. Required means it cannot be null in the database.
        public string Username { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        // PasswordHash of the user. Users inputted password will be hashed before inserted into User table. Required means it cannot be null in the database.
        public required string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
