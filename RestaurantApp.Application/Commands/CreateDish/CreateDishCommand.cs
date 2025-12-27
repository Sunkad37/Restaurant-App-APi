using MediatR;
using RestaurantApp.Application.Dishes.Dto;
using RestaurantApp.Domain.Entities;

namespace RestaurantApp.Application.Commands.CreateDish;

public class CreateDishCommand : IRequest<int>
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    public int? KiloCalories { get; set; }
    public int RestaurantId { get; set; }
}
