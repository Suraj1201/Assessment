using CyberSpaceGamers.Models;
using Microsoft.EntityFrameworkCore;

namespace CyberSpaceGamers.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : 
            base(options)
        {
        
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Name = "Game 1", ShortDescription = "Game One Description", Price = 10.99m, AgeRating = "18+", Genre = "Action" },
                new Product { Id = 2, Name = "Game 2", ShortDescription = "Game Two Description", Price = 11.99m, AgeRating = "12+", Genre = "Adventure" },
                new Product { Id = 3, Name = "Game 3", ShortDescription = "Game Three Description", Price = 10.99m, AgeRating = "18+", Genre = "RPG" },
                new Product { Id = 4, Name = "Game 4", ShortDescription = "Game Four Description", Price = 11.99m, AgeRating = "12+", Genre = "Indie" },
                new Product { Id = 5, Name = "Game 5", ShortDescription = "Game Four Description", Price = 11.99m, AgeRating = "12+", Genre = "Indie" }
                );
        }
    }
}
