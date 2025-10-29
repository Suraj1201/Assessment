using System.ComponentModel.DataAnnotations;

namespace CyberSpaceGamers.Models
{
    // This class represents the User table in the database.
    // Each instance of this class corresponds to one record in the User table.
    public class User
    {
        [Key]
        // Primary key. EF automatically treats 'Id' as the primary key.
        public int Id { get; set; }

        [Required]
        // Username of the user. First and last name. Required means it cannot be null in the database.
        public string? Username { get; set; }

        // PasswordHash of the user. Users inputted password will be hashed before inserted into User table. Required means it cannot be null in the database.
        public string? PasswordHash { get; set; }

        // Birthdate of the user. Required means it cannot be null in the database.
        public DateOnly? DOB { get; set; }
    }
}
