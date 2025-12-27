using MediatR;
using RestaurantApp.Application.Restaurants.Dto;

namespace RestaurantApp.Application.Queries.GetAllRestaurants;

public class GetAllRestaurantsQuery : IRequest<IEnumerable<RestaurantDto>>
{
    
}