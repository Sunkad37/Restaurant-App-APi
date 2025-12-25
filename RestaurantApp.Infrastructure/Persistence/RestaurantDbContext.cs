using Microsoft.EntityFrameworkCore;
using RestaurantApp.Domain.Entities;

namespace RestaurantApp.Infrastructure.Persistence
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) 
            : base(options) { }

        // Map Tables
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Dish> Dishes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Restaurant owns one Address (embedded in Restaurant table)
            modelBuilder.Entity<Restaurant>()
                .OwnsOne(r => r.Address);

            // Restaurant can have many Dishes (one-to-many)
            modelBuilder.Entity<Restaurant>()
                .HasMany(r => r.Dishes)
                .WithOne() // navigation property in Dish
                .HasForeignKey(d => d.RestaurantId);
        }
    }
}