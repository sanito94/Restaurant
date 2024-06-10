﻿using Restaurant.Core.Models.Admin;
using System.ComponentModel.DataAnnotations;
using static Restaurant.Core.Constants.MessageConstants;
using static Restaurant.Infrastructure.Constants.DataConstants;

namespace Restaurant.Core.Models.Menu
{
    public class ShopServiceModel
    {
        public ShopServiceModel()
        {
            Category = new List<CategoryServiceModel>();
        }

        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ItemNameMaxLength,
            MinimumLength = ItemNameMinLength,
            ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(ItemDescriptionMaxLength,
            MinimumLength = ItemDescriptionMinLength,
            ErrorMessage = LengthMessage)]
        public string Description { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(double),
            ItemPriceMinLength,
            ItemPriceMaxLength,
            ConvertValueInInvariantCulture = true,
            ErrorMessage = "Price must be a positive number and less than {2}$")]
        public double Price { get; set; }

        [Display(Name = "Image URL")]
        [Required(ErrorMessage = RequiredMessage)]
        public string ImageUrl { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        public int Amount { get; set; } = 1;

        public IEnumerable<CategoryServiceModel> Category { get; set; }
    }
}
