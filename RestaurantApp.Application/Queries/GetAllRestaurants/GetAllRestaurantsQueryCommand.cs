using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RestaurantApp.Application.Restaurants.Dto;
using RestaurantApp.Domain.Repositories;

namespace RestaurantApp.Application.Queries.GetAllRestaurants;

public class GetAllRestaurantsQueryCommand(
    ILogger<GetAllRestaurantsQueryCommand> logger,
    IMapper mapper,
    IRestaurantRepository repository) : IRequestHandler<GetAllRestaurantsQuery, IEnumerable<RestaurantDto>>
{
    public async Task<IEnumerable<RestaurantDto>> Handle(GetAllRestaurantsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Fetching all restaurants...");

        var restaurants = await repository.GetAllRestaurants();
        var restaurantDto = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);

        return restaurantDto;
    }
}