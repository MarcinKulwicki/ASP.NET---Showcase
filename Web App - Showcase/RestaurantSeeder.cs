using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Web_App___Showcase.Entities;

namespace Web_App___Showcase
{
    /// <summary>
    ///     Class to fill database some data
    /// </summary>
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _dbContext;

        public RestaurantSeeder(RestaurantDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Role.Any())
                {
                    var roles = GetRoles();
                    _dbContext.Role.AddRange(roles);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _dbContext.Restaurants.AddRange(restaurants);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            return new List<Role>()
            {
                new() { Name = "User" },
                new() { Name = "Manager" },
                new() { Name = "Influencer" },
                new() { Name = "Admin" }
            };
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new ()
                {
                    Name = "Tak Robimy",
                    Category = "Fast Food",
                    Description = "It's restaurant with hight quiality food.",
                    ContactEmail = "kontakt@takrobimy.pl",
                    ContactNumber  = "500100300",
                    HasDelivery = false,
                    Dishes = new List<Dish>()
                    {
                        new()
                        {
                            Name = "Classic Burger",
                            Price = 34
                        },
                        new()
                        {
                            Name = "Tak robimy Burger",
                            Price = 45
                        }
                    },
                    Address = new()
                    {
                        City = "Opole",
                        Street = "Opolska 15",
                        PostalCode = "46-605"
                    }
                },
                new ()
                {
                    Name = "Pol na pol",
                    Category = "Fast Food",
                    Description = "It's restaurant with pizza.",
                    ContactEmail = "kontakt@polnapoly.pl",
                    ContactNumber  = "900999300",
                    HasDelivery = true,
                    Dishes = new List<Dish>()
                    {
                        new()
                        {
                            Name = "Swojska",
                            Price = 25
                        },
                        new()
                        {
                            Name = "Z burakiem",
                            Price = 34
                        },
                        new()
                        {
                            Name = "4 sery",
                            Price = 35
                        }
                    },
                    Address = new()
                    {
                        City = "Opole",
                        Street = "Luboszycka 155",
                        PostalCode = "45-605"
                    }
                }
            };

            return restaurants;
        }
    }
}
