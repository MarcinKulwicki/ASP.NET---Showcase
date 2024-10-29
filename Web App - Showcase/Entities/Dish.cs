namespace Web_App___Showcase.Entities
{
    /// <summary>
    ///     Represent Dish for Restaurant id DB
    /// </summary>
    public class Dish
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public int RestaurantId { get; set; } // Entity framework is using that to hadnle connection between Restaurant and Dishes
        public virtual Restaurant Restaurant { get; set; }
    }
}
