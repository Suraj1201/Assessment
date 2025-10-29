using System.ComponentModel.DataAnnotations;

namespace CyberSpaceGamers.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Username { get; set; }

        public string? PasswordHash { get; set; }

        public DateOnly? DOB { get; set; }
    }
}
