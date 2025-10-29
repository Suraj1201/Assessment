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
                new Product { Id = 1, Name = "BattleField 6", ShortDescription = "Guns go pew pew woohoo", Price = 59.99m, AgeRating = "16+", Genre = "Shooter" },
                new Product { Id = 2, Name = "Resident Evil Village", ShortDescription = "If you know, you know", Price = 25.99m, AgeRating = "18+", Genre = "Survival" },
                new Product { Id = 3, Name = "Little Nightmares III", ShortDescription = "Puny people fight larger nightmares", Price = 49.00m, AgeRating = "16+", Genre = "Horror" },
                new Product { Id = 4, Name = "Super Smash Bros Ultimate", ShortDescription = "King K rool players are evil. ps - Sora is better.", Price = 54.50m, AgeRating = "12+", Genre = "Fighter" },
                new Product { Id = 5, Name = "Guardians of the Galaxy", ShortDescription = "Groot is best Guardian. I am GRROOOT", Price = 19.99m, AgeRating = "16+", Genre = "Action" },
                new Product { Id = 6, Name = "Fallout 4", ShortDescription = "Explore to your earnest galore", Price = 11.99m, AgeRating = "12+", Genre = "Adventure" },
                new Product { Id = 7, Name = "Saraj: Shadow Rebellion", ShortDescription = "This game includes super Suraj", Price = 20.00m, AgeRating = "14+", Genre = "Action" },
                new Product { Id = 8, Name = "Josh: Empires Unite", ShortDescription = "This game includes The organised Joshua of Laws", Price = 20.99m, AgeRating = "14+", Genre = "Multiplayer" },
                new Product { Id = 9, Name = "Dhruvisha’s Journey", ShortDescription = "This game includes the determined Dhruvisha", Price = 20.99m, AgeRating = "14+", Genre = "Adventure" },
                new Product { Id = 10, Name = "Whispering Woods: Kanwal’s Secret", ShortDescription = "This game includes the Scary Kanwal", Price = 20.99m, AgeRating = "14+", Genre = "Horror" },
                new Product { Id = 11, Name = "Crimson Evidence: Cameron Chronicles", ShortDescription = "This game includes the big mouth but bigger heart jokester Cameron (Ps Best game here.)", Price = 20.99m, AgeRating = "14+", Genre = "Mystery" },
                new Product { Id = 12, Name = "Liar's Bar", ShortDescription = "Be strategic and sly or die", Price = 05.99m, AgeRating = "14+", Genre = "Strategic" }
                );
        }
    }
}
