using AutoMapper;
using RestaurantApp.Application.Commands.CreateDish;
using RestaurantApp.Domain.Entities;

namespace RestaurantApp.Application.Dishes.Dto;

public class DishProfile : Profile
{
    public DishProfile()
    {
        CreateMap<Dish, DishDto>();
        CreateMap<CreateDishCommand, Dish>();
    }
}