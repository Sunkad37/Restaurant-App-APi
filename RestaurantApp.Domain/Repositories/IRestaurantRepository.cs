using RestaurantApp.Domain.Entities;

namespace RestaurantApp.Domain.Repositories;

public interface IRestaurantRepository
{
    Task<IEnumerable<Restaurant>> GetAllRestaurants();
    Task<Restaurant?> GetRestaurantByIdAsync(int id);
}