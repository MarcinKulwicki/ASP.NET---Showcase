using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Web_App___Showcase.Entities;
using Web_App___Showcase.Exceptions;
using Web_App___Showcase.Models;

namespace Web_App___Showcase.Services
{
    public class RestaurantService : IRestaurantService
    {
        private readonly RestaurantDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly ILogger<RestaurantService> _logger;

        public RestaurantService(RestaurantDbContext dbContext, IMapper mapper, ILogger<RestaurantService> logger)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _logger = logger;
        }

        public RestaurantDbContext DbContext { get; }

        public RestaurantDto GetById(int id)
        {
            var item = _dbContext.Restaurants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .FirstOrDefault(item => item.Id == id);

            if (item is null)
                throw new NotFoundException("Restaurant not found");

            var result = _mapper.Map<RestaurantDto>(item);
            return result;
        }

        public IEnumerable<RestaurantDto> GetAll()
        {
            var items = _dbContext.Restaurants
                .Include(r => r.Address)
                .Include(r => r.Dishes)
                .ToList();

            var itemsDto = _mapper.Map<List<RestaurantDto>>(items);

            return itemsDto;
        }

        public int Create(CreateRestaurantDto dto)
        {
            var item = _mapper.Map<Restaurant>(dto);
            _dbContext.Restaurants.Add(item);
            _dbContext.SaveChanges();

            return item.Id;
        }

        public void Delete(int id)
        {
            _logger.LogError($"Restaurant with id: {id} DELETED.");

            var item = _dbContext.Restaurants
                .FirstOrDefault(item => item.Id == id);

            if (item is null)
                throw new NotFoundException("Restaurant not found");

            _dbContext.Restaurants.Remove(item);
            _dbContext.SaveChanges();
        }

        public void Update(PutRestaurantDto putDto, int id)
        {
            var item = _dbContext.Restaurants
                .FirstOrDefault(item => item.Id == id);

            if (item is null)
                throw new NotFoundException("Restaurant not found");

            item.Name = putDto.Name;
            item.Description = putDto.Description;
            item.HasDelivery = putDto.HasDelivery;

            _dbContext.SaveChanges();
        }
    }
}
