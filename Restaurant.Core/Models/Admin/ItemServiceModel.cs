using Restaurant.Core.Models.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Models.Admin
{
    public class ItemServiceModel
    {
        public ItemServiceModel()
        {
            Category = new List<CategoryServiceModel>();
            Items = new List<ShopServiceModel>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public double Price { get; set; }
        public string ImageUrl { get; set; } = null!;
        public int CategoryId { get; set; }
        public IEnumerable<CategoryServiceModel> Category { get; set; }
        public IEnumerable<ShopServiceModel> Items { get; set; }
    }
}
