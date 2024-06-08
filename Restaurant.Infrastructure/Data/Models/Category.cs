using System.ComponentModel.DataAnnotations;
using static Restaurant.Infrastructure.Constants.DataConstants;

namespace Restaurant.Infrastructure.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(CategoryNameLength)]
        public string Name { get; set; } = string.Empty;
    }
}