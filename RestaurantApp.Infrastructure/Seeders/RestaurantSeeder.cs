using RestaurantApp.Domain.Entities;
using RestaurantApp.Infrastructure.Persistence;

namespace RestaurantApp.Infrastructure.Seeders;

public class RestaurantSeeder(RestaurantDbContext dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var restaurants = GetRestaraunts();
                dbContext.Restaurants.AddRange(restaurants);
                await dbContext.SaveChangesAsync();
            }
        }
    }

    private IEnumerable<Restaurant> GetRestaraunts()
    {
        List<Restaurant> restaurants =
        [
            new Restaurant
            {
                Name = "Spice Garden",
                Description = "Authentic Indian cuisine with a modern twist",
                Category = "Indian",
                HasDelivery = true,
                ContactEmail = "info@spicegarden.com",
                ContactNumber = "9876543210",
                Address = new Address
                {
                    City = "Bengaluru",
                    Street = "MG Road 12",
                    PostalCode = "560001"
                },
                Dishes =
                [
                    new Dish
                    {
                        Name = "Butter Chicken", Description = "Creamy tomato gravy", Price = 350,
                        RestaurantId = 1
                    },

                    new Dish
                    {
                        Name = "Paneer Tikka", Description = "Grilled cottage cheese", Price = 280,
                        RestaurantId = 1
                    }
                ]
            },

            new Restaurant
            {
                Name = "Ocean Breeze",
                Description = "Fresh seafood specialties",
                Category = "Seafood",
                HasDelivery = false,
                ContactEmail = "contact@oceanbreeze.com",
                ContactNumber = "9123456789",
                Address = new Address
                {
                    City = "Goa",
                    Street = "Beachside Avenue 45",
                    PostalCode = "403001"
                },
                Dishes = new List<Dish>
                {
                    new Dish
                    {
                        Name = "Grilled Prawns", Description = "Served with garlic butter", Price = 600,
                        RestaurantId = 2
                    },
                    new Dish
                    {
                        Name = "Fish Curry", Description = "Traditional Goan style", Price = 450,
                        RestaurantId = 2
                    }
                }
            },

            new Restaurant
            {
                Name = "Pasta Palace",
                Description = "Classic Italian pasta dishes",
            }
        ];

        return restaurants;
    }
}