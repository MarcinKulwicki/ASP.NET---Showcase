using System.ComponentModel.DataAnnotations;

namespace Web_App___Showcase.Models
{
    public class PutRestaurantDto
    {
        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
        public string Description { get; set; }
        public bool HasDelivery { get; set; }
    }
}
