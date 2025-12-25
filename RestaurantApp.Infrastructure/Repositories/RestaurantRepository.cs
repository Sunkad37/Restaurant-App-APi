using Microsoft.EntityFrameworkCore;
using RestaurantApp.Domain.Entities;
using RestaurantApp.Domain.Repositories;
using RestaurantApp.Infrastructure.Persistence;

namespace RestaurantApp.Infrastructure.Repositories;

public class RestaurantRepository(RestaurantDbContext dbContext) : IRestaurantRepository
{
    public async Task<IEnumerable<Restaurant>> GetAllRestaurants()
    {
        var restaurants = await dbContext.Restaurants
            .Include(restaurant => restaurant.Dishes)
            .ToListAsync();
        return restaurants;
    }
    
    public async Task<Restaurant?> GetRestaurantByIdAsync(int id)
    {
        return await dbContext.Restaurants
            .Include(r => r.Dishes)
            .FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<int> CreateRestaurant(Restaurant restaurant)
    {
        await  dbContext.Restaurants.AddAsync(restaurant);
        await dbContext.SaveChangesAsync();
        return restaurant.Id;
    }
}