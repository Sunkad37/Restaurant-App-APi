using MediatR;

namespace RestaurantApp.Application.Commands.DeleteRestaurant;

public class DeleteRestaurantCommand(int id) : IRequest
{
    public int RestaurantId { get; } = id;
}