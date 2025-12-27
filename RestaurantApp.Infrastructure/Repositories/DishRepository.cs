using Microsoft.EntityFrameworkCore;
using RestaurantApp.Domain.Entities;
using RestaurantApp.Domain.Repositories;
using RestaurantApp.Infrastructure.Persistence;

namespace RestaurantApp.Infrastructure.Repositories;

public class DishRepository(RestaurantDbContext dbContext) : IDishRepository
{
    public async Task<IEnumerable<Dish>> GetAllDishesAsync(int restaurantId)
    {
       return await dbContext.Restaurants
           .Where(r => r.Id == restaurantId)
           .SelectMany(r => r.Dishes).ToListAsync();
    }

    public async Task<Dish?> GetDishAsync(int restaurantId, int dishId)
    {
        return await dbContext.Restaurants
            .Where(r => r.Id == restaurantId)
            .SelectMany(r => r.Dishes)
            .FirstOrDefaultAsync(d => d.Id == dishId);
    }

    public async Task<int> CreateDish(Dish dish)
    {
        await dbContext.Dishes.AddAsync(dish);
        await dbContext.SaveChangesAsync();
        return dish.Id;
    }
}