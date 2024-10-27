using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Web_App___Showcase.Models;
using Web_App___Showcase.Services;

namespace Web_App___Showcase.Controllers
{
    [Route("api/restaurant")]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpPut("{id}")]
        public ActionResult<RestaurantDto> Update([FromBody] PutRestaurantDto dto, [FromRoute] int id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var isUpdated = _restaurantService.Update(dto, id);

            return isUpdated ? Ok() : NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete([FromRoute] int id)
        {
            var isDeleted = _restaurantService.Delete(id);

            return isDeleted ? NoContent() : NotFound();
        }

        [HttpPost]
        public ActionResult CreateRestaurat([FromBody] CreateRestaurantDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            int id = _restaurantService.Create(dto);

            return Created($"/api/restaurant/{id}", null);
        }

        [HttpGet]
        public ActionResult<IEnumerable<RestaurantDto>> GetAll()
        {
            var items = _restaurantService.GetAll();
            return Ok(items);
        }

        [HttpGet("{id}")]
        public ActionResult<RestaurantDto> Get([FromRoute] int id)
        {
            var item = _restaurantService.GetById(id);

            if (item == null)
                return NotFound();

            return Ok(item);
        }
    }
}
