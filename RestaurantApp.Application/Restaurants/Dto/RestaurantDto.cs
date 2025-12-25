using RestaurantApp.Application.Dishes.Dto;
using RestaurantApp.Domain.Entities;

namespace RestaurantApp.Application.Restaurants.Dto;

public class RestaurantDto
{
    public int Id { get; set; }
    public string? Name { get; set; } = null!;
    public string? Description { get; set; } = null!;
    public string? Category { get; set; } = null!;
    public bool HasDelivery { get; set; }
    public string? ContactEmail { get; set; } = null!;
    public string? ContactNumber { get; set; } = null!;
    public string? City { get; set; } = null!;
    public string? Street { get; set; } = null!;
    public string? PostalCode { get; set; } = null!;
    
    public List<DishDto> Dishes { get; set; } = [];

    public static RestaurantDto? FromRestaurant(Restaurant? restaurant)
    {
        if (restaurant is null) return null;

        return new RestaurantDto
        {
            Id = restaurant.Id,
            Name = restaurant.Name,
            Description = restaurant.Description,
            Category = restaurant.Category,
            HasDelivery = restaurant.HasDelivery,
            ContactEmail = restaurant.ContactEmail,
            ContactNumber = restaurant.ContactNumber,
            City = restaurant.Address?.City,
            Street = restaurant.Address?.Street,
            PostalCode = restaurant.Address?.PostalCode,
            Dishes = restaurant.Dishes?.Select(DishDto.FromDish).ToList() ?? []
        };
    }
}