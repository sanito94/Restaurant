using Restaurant.Core.Models.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Models.Menu
{
    public class ShopQueryModel
    {
        public ShopQueryModel()
        {
            Items = new List<ShopServiceModel>();
            Category = new List<CategoryServiceModel>();
        }

        public IEnumerable<CategoryServiceModel> Category { get; set; }
        public IEnumerable<ShopServiceModel> Items { get; set; }
    }
}
