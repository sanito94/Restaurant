using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Contracts;
using Restaurant.Infrastructure.Data;
using Restaurant.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Services
{
    public class AdminService : IAdminService
    {
        private readonly RestaurantDbContext context;

        public AdminService(RestaurantDbContext _context)
        {
            context = _context;
        }

        public async Task AddCategoryAsync(string name)
        {
            Category category = new Category();
            category.Name = name;

            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
        }

        public async Task<bool> ExistsByNameAsync(string name)
        {
            return await context.Categories.AnyAsync(n => n.Name == name);
        }
    }
}
