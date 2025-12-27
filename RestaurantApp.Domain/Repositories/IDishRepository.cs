using RestaurantApp.Domain.Entities;

namespace RestaurantApp.Domain.Repositories;

public interface IDishRepository
{
    Task<IEnumerable<Dish>> GetAllDishesAsync(int restaurantId);
    Task<Dish> GetDishAsync(int restaurantId, int dishId);

    Task<int> CreateDish(Dish dish);
}