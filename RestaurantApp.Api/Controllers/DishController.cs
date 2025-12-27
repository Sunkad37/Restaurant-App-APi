using MediatR;
using Microsoft.AspNetCore.Mvc;
using RestaurantApp.Application.Commands.CreateDish;
using RestaurantApp.Application.Queries.GetAllDishes;
using RestaurantApp.Application.Queries.GetDishById;
using RestaurantApp.Domain.Entities;

namespace RestaurantApp.Api.Controllers;

[ApiController]
[Route("api/restaurants/{restaurantId}/dishes")]
public class DishController(IMediator mediator) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateDish(int restaurantId, [FromBody] CreateDishCommand command)
    {
        command.RestaurantId = restaurantId;
        var id = await mediator.Send(command);
        return Created($"/api/restaurants/{restaurantId}/dishes/{id}", null);
    }

    // GET: api/restaurants/{restaurantId}/dishes
    [HttpGet("/api/restaurants/{restaurantId}/dishes")]
    public async Task<ActionResult> GetAllDishes(int restaurantId)
    {
        var dishes = await mediator.Send(new GetAllDishesQuery(restaurantId));
        return Ok(dishes);
    }

    // GET: api/restaurants/{restaurantId}/dishes/{dishId}
    [HttpGet("/api/restaurants/{restaurantId}/dishes/{id}")]
    public async Task<ActionResult> GetDishById(int restaurantId, int id)
    {
        var dish = await mediator.Send(new GetDishByIdQuery(restaurantId, id));
        return Ok(dish);
    }
    
    // Implement other end points as well
}