using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Web_App___Showcase.Entities;
using Web_App___Showcase.Exceptions;
using Web_App___Showcase.Models;

namespace Web_App___Showcase.Services
{
    public class DishService : IDishService
    {
        private readonly RestaurantDbContext _context;
        private readonly IMapper _mapper;

        public DishService(RestaurantDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public int Create(int restaurantId, CreateDishDto dto)
        {
            GetRestaurantById(restaurantId);

            var entity = _mapper.Map<Dish>(dto);

            entity.RestaurantId = restaurantId;

            _context.Dishes.Add(entity);
            _context.SaveChanges();

            return entity.Id;
        }

        public DishDto GetById(int restaurantId, int dishId)
        {
            GetRestaurantById(restaurantId);
            Dish dish = GetDishById(restaurantId, dishId);

            var dishDto = _mapper.Map<DishDto>(dish);
            return dishDto;
        }

        public List<DishDto> GetAll(int restaurantId)
        {
            var restaurant = GetRestaurantById(restaurantId);

            var dishDtos = _mapper.Map<List<DishDto>>(restaurant.Dishes);
            return dishDtos;
        }

        public void RemoveAll(int restaurantId)
        {
            var restaurant = GetRestaurantById(restaurantId);

            _context.RemoveRange(restaurant.Dishes);
            _context.SaveChanges();
        }

        public void Remove(int restaurantId, int dishId)
        {
            GetRestaurantById(restaurantId);
            Dish dish = GetDishById(restaurantId, dishId);

            _context.Remove(dish);
            _context.SaveChanges();
        }

        private Restaurant GetRestaurantById(int restaurantId)
        {
            var restaurant = _context.Restaurants
                .Include(r => r.Dishes)
                .FirstOrDefault(item => item.Id == restaurantId);

            if (restaurant is null)
                throw new NotFoundException("Restaurant not found");

            return restaurant;
        }

        private Dish GetDishById(int restaurantId, int dishId)
        {
            var dish = _context.Dishes.FirstOrDefault(item => item.Id == dishId);
            if (dish is null || dish.RestaurantId != restaurantId)
                throw new NotFoundException("Dish not found");
            return dish;
        }
    }
}
