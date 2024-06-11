using Restaurant.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Models.Cart
{
    public class CartViewModel
    {
        public int Id { get; set; }
        public string ItemName { get; set; } = null!;

        public int ItemId { get; set; }

        public string ImageUrl { get; set; } = null!;

        public string UserId { get; set; } = null!;

        public int Amount { get; set; }
        public double Price { get; set; }

        public double Total { get; set; }
        public double SubTotal { get; set; } = 0;

        public Item Item { get; set; } = null!;
    }
}
