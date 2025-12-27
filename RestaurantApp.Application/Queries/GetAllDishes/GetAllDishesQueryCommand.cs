using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using RestaurantApp.Application.Dishes.Dto;
using RestaurantApp.Domain.Entities;
using RestaurantApp.Domain.Exceptions;
using RestaurantApp.Domain.Repositories;

namespace RestaurantApp.Application.Queries.GetAllDishes;

public class GetAllDishesQueryCommand(
    ILogger<GetAllDishesQueryCommand> logger,
    IMapper mapper,
    IDishRepository dishRepository)
    : IRequestHandler<GetAllDishesQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetAllDishesQuery request, CancellationToken cancellationToken)
    {
        var dishes = await dishRepository.GetAllDishesAsync(request.Id);
        if(dishes is null)
            throw new NotFoundException(nameof(Dish), request.Id.ToString());
        var dishDto = mapper.Map<IEnumerable<DishDto>>(dishes);
        return dishDto;
        
    }
}