using System.ComponentModel.DataAnnotations;
using static Restaurant.Core.Constants.MessageConstants;
using static Restaurant.Infrastructure.Constants.DataConstants;

namespace Restaurant.Core.Models.BookATable
{
    public class BookATableViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(
            SenderNameMaxLength,
            MinimumLength = SenderNameMinLength,
            ErrorMessage = LengthMessage)]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(
            SenderEmailMaxLength,
            MinimumLength = SenderEmailMinLength,
            ErrorMessage = LengthMessage)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(
                    PhoneNumberMaxLength,
                    MinimumLength = PhoneNumberMinLength,
                    ErrorMessage = LengthMessage)]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public DateTime Day { get; set; }

        [Required]
        public DateTime Hour { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [Range(1, 5)]
        public int NumberOfPeople { get; set; }

    }
}
