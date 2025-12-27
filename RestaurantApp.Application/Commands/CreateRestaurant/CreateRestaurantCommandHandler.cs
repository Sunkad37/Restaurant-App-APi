using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RestaurantApp.Domain.Entities;
using RestaurantApp.Domain.Repositories;

namespace RestaurantApp.Application.Commands.CreateRestaurant;

public class CreateRestaurantCommandHandler(
    ILogger<CreateRestaurantCommandHandler> logger,
    IMapper mapper,
    IRestaurantRepository repository) : IRequestHandler<CreateRestaurantCommand, int>
{
    public async Task<int> Handle(CreateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating Restaurant Resources");
        var restaurant = mapper.Map<Restaurant>(request);
        int id = await repository.CreateRestaurant(restaurant);
        return id;
    }
}