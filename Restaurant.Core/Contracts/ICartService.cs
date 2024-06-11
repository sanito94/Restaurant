using Restaurant.Core.Models.Cart;
using Restaurant.Core.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Contracts
{
    public interface ICartService
    {
        Task<bool> ItemExistsByIdAsync(int id);

        Task<ShopServiceModel> ItemDetailsByIdAsync(int id);

        Task<IEnumerable<CartViewModel>> CartTotalAsync(string userId);

        Task DeleteAsync(int id);
    }
}
