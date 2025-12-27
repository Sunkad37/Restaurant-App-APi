using AutoMapper;
using RestaurantApp.Application.Commands.CreateRestaurant;
using RestaurantApp.Domain.Entities;

namespace RestaurantApp.Application.Restaurants.Dto;

public class RestaurantProfile : Profile
{
    public RestaurantProfile()
    {
        CreateMap<CreateRestaurantCommand, Restaurant>()
            .ForMember(dest => dest.Address, opt
                => opt.MapFrom(src => new Address()
                {
                    Street = src.Street,
                    City = src.City,
                    PostalCode = src.PostalCode
                })
            );

        CreateMap<Restaurant, RestaurantDto>()
            .ForMember(dest => dest.City, opt
                => opt.MapFrom(src => src.Address == null ? null : src.Address.City))
            .ForMember(dest => dest.PostalCode, opt
                => opt.MapFrom(src => src.Address == null ? null : src.Address.PostalCode))
            .ForMember(dest => dest.Street, opt
                => opt.MapFrom(src => src.Address == null ? null : src.Address.Street))
            .ForMember(dest => dest.Dishes, opt
                => opt.MapFrom(src => src.Dishes));
    }
}