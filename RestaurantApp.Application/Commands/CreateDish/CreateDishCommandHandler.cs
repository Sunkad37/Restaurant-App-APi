using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RestaurantApp.Domain.Entities;
using RestaurantApp.Domain.Exceptions;
using RestaurantApp.Domain.Repositories;

namespace RestaurantApp.Application.Commands.CreateDish;

public class CreateDishCommandHandler(
    ILogger<CreateDishCommandHandler> logger,
    IMapper mapper,
    IDishRepository repository, IRestaurantRepository restaurantRepository) : IRequestHandler<CreateDishCommand, int>
{
    public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Dish created");
        
        var restaurant = await restaurantRepository.GetRestaurantByIdAsync(request.RestaurantId);
        if (restaurant == null)
            throw new NotFoundException(nameof(Restaurant), request.RestaurantId.ToString());
        
        var dish = mapper.Map<Dish>(request);
        
        int id = await repository.CreateDish(dish);
        return id;
    }
}