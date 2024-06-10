using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Contracts;
using Restaurant.Core.Models.Menu;
using Restaurant.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Services
{

    public class MenuService : IMenuService
    {
        private readonly RestaurantDbContext context;

        public MenuService(RestaurantDbContext _context)
        {
            context = _context;
        }

        public async Task<ShopDetailsServiceModel> ItemDetailsByIdAsync(int id)
        {
            return await context.Items
                .AsNoTracking()
                .Where(x => x.Id == id)
                .Select(i => new ShopDetailsServiceModel()
                {
                    Id = id,
                    Name = i.Name,
                    Description = i.Description,
                    ImageUrl = i.ImageUrl,
                    Price = i.Price,
                })
                .FirstAsync();
        }
    }
}
