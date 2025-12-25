using AutoMapper;
using RestaurantApp.Domain.Entities;

namespace RestaurantApp.Application.Dishes.Dto;

public class DishProfile : Profile
{
    public DishProfile()
    {
        CreateMap<Dish, DishDto>();
    }
}