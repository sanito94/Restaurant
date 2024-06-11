using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Contracts;
using Restaurant.Core.Models.Cart;
using Restaurant.Core.Models.Menu;
using Restaurant.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Services
{
    public class CartService : ICartService
    {
        private readonly RestaurantDbContext context;

        public CartService(RestaurantDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<CartViewModel>> CartTotalAsync(string userId)
        {
            var model = await context.Carts
                .Where(c => c.UserId == userId)
                .Select(c => new CartViewModel()
                {
                    Id = c.Id,
                    ItemId = c.Id,
                    UserId = userId,
                    Amount = c.Amount,
                    ImageUrl = c.ImageUrl,
                    ItemName = c.ItemName,
                    Price = c.Price,
                    Total = c.Total,
                    SubTotal = c.SubTotal
                })
                .ToListAsync();

            return model;
        }

        public async Task DeleteAsync(int id)
        {
            var shoppingCartItem = await context.Carts
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync();

            context.Carts.Remove(shoppingCartItem);
        }

        public async Task<ShopServiceModel> ItemDetailsByIdAsync(int id)
        {
            return await context.Items
                .Where(i => i.Id == id)
                .Select(i => new ShopServiceModel()
                {
                    Id = i.Id,
                    Name = i.Name,
                    Description = i.Description,
                    ImageUrl = i.ImageUrl,
                    Price = i.Price,
                })
                .FirstAsync();
        }

        public async Task<bool> ItemExistsByIdAsync(int id)
        {
            return await context.Items
                .AnyAsync(i => i.Id == id);
        }
    }
}
