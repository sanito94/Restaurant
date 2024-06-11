using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Infrastructure.Data.Models
{
    public class Cart
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ItemName { get; set; } = string.Empty;

        [Required]
        public string ImageUrl { get; set; } = string.Empty;


        [Required]
        public int ItemId { get; set; }
        [ForeignKey(nameof(ItemId))]
        public Item Item { get; set; } = null!;


        public string UserId { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;


        [Required]
        public int Amount { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public double Total { get; set; }

        [Required]
        public double SubTotal { get; set; } = 0;
    }
}
