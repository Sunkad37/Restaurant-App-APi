using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Application.Commands.CreateRestaurant;
using RestaurantApp.Application.Commands.DeleteRestaurant;
using RestaurantApp.Application.Queries.GetAllRestaurants;
using RestaurantApp.Application.Queries.GetRestaurantById;

namespace RestaurantApp.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class RestaurantsController(IMediator mediator) : ControllerBase
{
    // GET api/restaurants
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
        return Ok(restaurants);
    }

    // GET api/restaurants/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
        return Ok(restaurant);
    }

    // POST api/restaurants
    [HttpPost]
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }

    // DELETE api/restaurants/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRestaurant(int id)
    {
        await mediator.Send(new DeleteRestaurantCommand(id));
        return NoContent();
    }
}