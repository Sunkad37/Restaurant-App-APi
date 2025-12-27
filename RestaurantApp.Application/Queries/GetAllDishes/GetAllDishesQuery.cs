using MediatR;
using RestaurantApp.Application.Dishes.Dto;

namespace RestaurantApp.Application.Queries.GetAllDishes;

public class GetAllDishesQuery(int id) : IRequest<IEnumerable<DishDto>>
{
    public int Id { get; } = id;
}