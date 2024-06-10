using Restaurant.Core.Models.Menu;

namespace Restaurant.Core.Contracts
{
    public interface IMenuService
    {
        Task<ShopDetailsServiceModel> ItemDetailsByIdAsync(int id);
    }
}
