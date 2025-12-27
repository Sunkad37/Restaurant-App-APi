using MediatR;
using RestaurantApp.Application.Dishes.Dto;
using RestaurantApp.Domain.Entities;

namespace RestaurantApp.Application.Queries.GetDishById;

public class GetDishByIdQuery(int restaurantId, int dishId) : IRequest<DishDto>
{
    public int RestaurantId { get; } = restaurantId;
    public int DishId { get; } = dishId;
}