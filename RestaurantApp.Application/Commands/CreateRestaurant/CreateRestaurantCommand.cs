using MediatR;

namespace RestaurantApp.Application.Commands.CreateRestaurant;

public class CreateRestaurantCommand : IRequest<int>
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Category { get; set; } = null!;
    public bool HasDelivery { get; set; }
    public string? ContactEmail { get; set; } = null!;
    public string? ContactNumber { get; set; } = null!;
    public string? City { get; set; } = null!;
    public string? Street { get; set; } = null!;
    public string? PostalCode { get; set; } = null!;
}