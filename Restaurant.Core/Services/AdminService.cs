using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Contracts;
using Restaurant.Core.Models.Admin;
using Restaurant.Core.Models.Menu;
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

        public async Task AddItemAsync(ItemServiceModel model)
        {
            Item item = new Item();
            item.Name = model.Name;
            item.Description = model.Description;
            item.CategoryId = model.CategoryId;
            item.ImageUrl = model.ImageUrl;
            item.Price = model.Price;

            await context.Items.AddAsync(item);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CategoryServiceModel>> AllCategoriesAsync()
        {
            return await context.Categories
                .AsNoTracking()
                .Select(c => new CategoryServiceModel()
                {
                    Name = c.Name,
                    Id = c.Id,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<ShopServiceModel>> AllItemsAsync()
        {
            return await context.Items
                .AsNoTracking()
                .Select(i => new ShopServiceModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    ImageUrl = i.ImageUrl,
                    Price = i.Price,
                    CategoryId = i.CategoryId,
                })
                .ToListAsync();
        }

        //public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        //{
        //    return await context.Categories
        //        .AsNoTracking()
        //        .Select(c => c.Name)
        //        .Distinct()
        //        .ToListAsync();
        //}

        public async Task<bool> CategoryExistsByNameAsync(string name)
        {
            return await context.Categories.AnyAsync(n => n.Name == name);
        }

        public async Task<bool> ItemExistsByNameAsync(string name)
        {
            return await context.Items.AnyAsync(n => n.Name == name);
        }
    }
}
