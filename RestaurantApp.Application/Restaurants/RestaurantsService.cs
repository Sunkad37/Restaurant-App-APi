using Microsoft.Extensions.Logging;
using RestaurantApp.Application.Restaurants.Dto;
using RestaurantApp.Domain.Repositories;

namespace RestaurantApp.Application.Restaurants;

public class RestaurantsService(IRestaurantRepository repository, ILogger<RestaurantsService> logger)
    : IRestaurantsService
{
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Fetching all restaurants...");
        var restaurants = await repository.GetAllRestaurants();
        var restaurantDto = restaurants.Select(RestaurantDto.FromRestaurant);
        return restaurantDto!;
    }

    public async Task<RestaurantDto> GetRestaurantById(int id)
    {
        logger.LogInformation("Fetching restaurant with id {Id}", id); 
        var restaurant = await repository.GetRestaurantByIdAsync(id); 
        // Map to DTO (may be null if not found)
        return RestaurantDto.FromRestaurant(restaurant);
    }
}