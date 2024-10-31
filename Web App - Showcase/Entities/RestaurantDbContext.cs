using Microsoft.EntityFrameworkCore;

namespace Web_App___Showcase.Entities
{
    /// <summary>
    ///     Restaurant DB configuration
    /// </summary>
    public class RestaurantDbContext : DbContext
    {
        private string _connectionString = "Server=WDR434;Database=RestuarantDb;Trusted_Connection=True;";
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Role { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .Property(item => item.Name)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Dish>()
                .Property(item => item.Name)
                .IsRequired();

            modelBuilder.Entity<Address>()
                .Property(item => item.City)
                .HasMaxLength(50);
            modelBuilder.Entity<Address>()
                .Property(item => item.Street)
                .HasMaxLength(50);

            modelBuilder.Entity<User>()
                .Property(item => item.Email)
                .IsRequired();

            modelBuilder.Entity<Role>()
                .Property(item => item.Name)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
