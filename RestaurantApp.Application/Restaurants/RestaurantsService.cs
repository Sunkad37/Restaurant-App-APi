using AutoMapper;
using Microsoft.Extensions.Logging;
using RestaurantApp.Application.Restaurants.Dto;
using RestaurantApp.Domain.Entities;
using RestaurantApp.Domain.Repositories;

namespace RestaurantApp.Application.Restaurants;

public class RestaurantsService(IRestaurantRepository repository, ILogger<RestaurantsService> logger, IMapper mapper)
    : IRestaurantsService
{
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Fetching all restaurants...");

        var restaurants = await repository.GetAllRestaurants();
        var restaurantDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

        return restaurantDto!;
    }

    public async Task<RestaurantDto> GetRestaurantById(int id)
    {
        logger.LogInformation("Fetching restaurant with id {Id}", id);

        var restaurant = await repository.GetRestaurantByIdAsync(id);
        var restaurantDto = mapper.Map<RestaurantDto>(restaurant);

        return restaurantDto;
    }

    public async Task<int> CreateRestaurant(CreateRestaurantDto dto)
    {
        logger.LogInformation("Creating Restaurant Resources");
        var restaurant = mapper.Map<Restaurant>(dto);
        int id = await repository.CreateRestaurant(restaurant);
        return id;
    }
}