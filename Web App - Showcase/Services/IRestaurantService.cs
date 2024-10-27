using System.Collections.Generic;
using Web_App___Showcase.Models;

namespace Web_App___Showcase.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto);
        IEnumerable<RestaurantDto> GetAll();
        RestaurantDto GetById(int id);
        bool Delete(int id);
        bool Update(PutRestaurantDto putDto, int id);
    }
}