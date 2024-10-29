using System.Collections.Generic;
using Web_App___Showcase.Models;

namespace Web_App___Showcase.Services
{
    public interface IDishService
    {
        int Create(int restaurantId, CreateDishDto dto);
        List<DishDto> GetAll(int restaurantId);
        DishDto GetById(int restaurantId, int dishId);
        void Remove(int restaurantId, int dishId);
        void RemoveAll(int restaurantId);
    }
}
