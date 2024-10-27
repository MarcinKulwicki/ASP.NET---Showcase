using AutoMapper;
using Web_App___Showcase.Entities;
using Web_App___Showcase.Models;

namespace Web_App___Showcase
{
    public class RestaurantMappingProfile : Profile
    {
        public RestaurantMappingProfile()
        {
            CreateMap<Restaurant, RestaurantDto>()
                .ForMember(dto => dto.City, item => item.MapFrom(r => r.Address.City))
                .ForMember(dto => dto.Street, item => item.MapFrom(r => r.Address.Street))
                .ForMember(dto => dto.PostalCode, item => item.MapFrom(r => r.Address.PostalCode));

            CreateMap<Dish, DishDto>();

            CreateMap<CreateRestaurantDto, Restaurant>()
                .ForMember(r => r.Address, item => item.MapFrom(dto => new Address() { City = dto.City, PostalCode = dto.PostalCode, Street = dto.Street }));
        }
    }
}
