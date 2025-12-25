namespace RestaurantApp.Domain.Entities;

public class Dish
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
    
    public int? KiloCalories { get; set; }
    
    // FK to Restaurant table
    public int RestaurantId { get; set; }
}