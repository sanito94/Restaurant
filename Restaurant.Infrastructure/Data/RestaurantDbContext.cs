using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Restaurant.Infrastructure.Data.Models;
using Restaurant.Infrastructure.Data.Models.Seed;

namespace Restaurant.Infrastructure.Data
{
    public class RestaurantDbContext : IdentityDbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new CategoryConfiguration());

            base.OnModelCreating(builder);
        }

        public DbSet<Item> Items { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Contact> Contacts { get; set; } = null!;
    }
}