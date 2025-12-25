using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Application.Restaurants;
using RestaurantApp.Domain.Entities;

namespace RestaurantApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantController(IRestaurantsService restaurantsService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await restaurantsService.GetAllRestaurants();
        return Ok(restaurants);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var restaurant = await restaurantsService.GetRestaurantById(id);
        return Ok(restaurant);
    }
}