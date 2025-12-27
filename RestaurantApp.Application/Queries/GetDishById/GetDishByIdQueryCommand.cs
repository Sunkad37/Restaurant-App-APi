using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RestaurantApp.Application.Dishes.Dto;
using RestaurantApp.Domain.Entities;
using RestaurantApp.Domain.Exceptions;
using RestaurantApp.Domain.Repositories;

namespace RestaurantApp.Application.Queries.GetDishById;

public class GetDishByIdQueryCommand(
    ILogger<GetDishByIdQueryCommand> logger,
    IMapper mapper,
    IDishRepository repository)
    : IRequestHandler<GetDishByIdQuery, DishDto>
{
    public async Task<DishDto> Handle(GetDishByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Handling GetDishByIdQuery");
        var dish = await repository.GetDishAsync(request.RestaurantId, request.DishId);
        
        if (dish == null)
            throw new NotFoundException(nameof(Dish), request.DishId.ToString());
        
        var dishDto = mapper.Map<DishDto>(dish);
        return dishDto;
    }
}