using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Infrastructure.Data.Models;

namespace Restaurant.Infrastructure.Data
{
    public class RestaurantDbContext : IdentityDbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Contact> Contacts { get; set; } = null!;
    }
}