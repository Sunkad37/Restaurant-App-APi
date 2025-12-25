using RestaurantApp.Application.Restaurants.Dto;
using RestaurantApp.Domain.Entities;

namespace RestaurantApp.Application.Restaurants;

public interface IRestaurantsService
{
    Task<IEnumerable<RestaurantDto>> GetAllRestaurants();
    Task<RestaurantDto> GetRestaurantById(int id);
}