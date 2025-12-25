using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Application.Restaurants;
using RestaurantApp.Application.Restaurants.Dto;
using RestaurantApp.Domain.Entities;

namespace RestaurantApp.Api.Controllers;

[ApiController]
[Route("api/restaurants")]
public class RestaurantController(IRestaurantsService restaurantsService) : ControllerBase
{
    [HttpGet]
    [Route("GetAllRestaurants")]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await restaurantsService.GetAllRestaurants();
        return Ok(restaurants);
    }

    [HttpGet()]
    [Route("GetById/{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var restaurant = await restaurantsService.GetRestaurantById(id);
        return Ok(restaurant);
    }

    [HttpPost]
    [Route("CreateRestaurant")]
    public async Task<IActionResult> CreateRestaurant([FromBody]CreateRestaurantDto dto)
    {
        int id = await restaurantsService.CreateRestaurant(dto);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
}