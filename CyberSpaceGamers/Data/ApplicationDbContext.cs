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
                new Product { Id = 1, Name = "Game One", ShortDescription = "Game One Description", Price = 10.99m, AgeRating = "18+", Genre = "Action" },
                new Product { Id = 2, Name = "Game Two", ShortDescription = "Game Two Description", Price = 11.99m, AgeRating = "12+", Genre = "Adventure" },
                new Product { Id = 3, Name = "Game Three", ShortDescription = "Game Three Description", Price = 10.99m, AgeRating = "18+", Genre = "RPG" },
                new Product { Id = 4, Name = "Game Four", ShortDescription = "Game Four Description", Price = 11.99m, AgeRating = "12+", Genre = "Indie" }
                );
        }
    }
}
