using System.Collections.Generic;
using Web_App___Showcase.Models;

namespace Web_App___Showcase.Services
{
    public interface IRestaurantService
    {
        int Create(CreateRestaurantDto dto);
        IEnumerable<RestaurantDto> GetAll();
        RestaurantDto GetById(int id);
        void Delete(int id);
        void Update(PutRestaurantDto putDto, int id);
    }
}