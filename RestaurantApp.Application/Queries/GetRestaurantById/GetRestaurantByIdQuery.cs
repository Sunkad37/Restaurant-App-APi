using MediatR;
using RestaurantApp.Application.Restaurants.Dto;

namespace RestaurantApp.Application.Queries.GetRestaurantById;

public class GetRestaurantByIdQuery(int id) : IRequest<RestaurantDto>
{
    public int Id { get; } = id;
}