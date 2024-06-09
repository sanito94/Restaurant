using Restaurant.Core.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Contracts
{
    public interface IAdminService
    {
        Task AddCategoryAsync(string name);
        Task<bool> CategoryExistsByNameAsync(string name);
        Task<IEnumerable<CategoryServiceModel>> AllCategoriesAsync();


        Task AddItemAsync(ItemServiceModel model);
        Task<bool> ItemExistsByNameAsync(string name);
    }
}
