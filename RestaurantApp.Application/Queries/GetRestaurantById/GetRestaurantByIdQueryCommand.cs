using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RestaurantApp.Application.Restaurants.Dto;
using RestaurantApp.Domain.Entities;
using RestaurantApp.Domain.Exceptions;
using RestaurantApp.Domain.Repositories;

namespace RestaurantApp.Application.Queries.GetRestaurantById;

public class GetRestaurantByIdQueryCommand(
    ILogger<GetRestaurantByIdQueryCommand> logger,
    IMapper mapper,
    IRestaurantRepository repository) : IRequestHandler<GetRestaurantByIdQuery, RestaurantDto>
{
    public async Task<RestaurantDto> Handle(GetRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Fetching restaurant with id {Id}", request.Id);

        var restaurant = await repository.GetRestaurantByIdAsync(request.Id);
        
        if (restaurant is null)
            throw new NotFoundException(nameof(Restaurant), request.Id.ToString());
        
        var restaurantDto = mapper.Map<RestaurantDto>(restaurant);

        return restaurantDto;
    }
}