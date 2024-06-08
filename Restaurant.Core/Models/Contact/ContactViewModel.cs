using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Restaurant.Core.Constants.MessageConstants;
using static Restaurant.Infrastructure.Constants.DataConstants;

namespace Restaurant.Core.Models.Contact
{
    public class ContactViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(
            SenderNameMaxLength,
            MinimumLength = SenderNameMinLength,
            ErrorMessage = LengthMessage)]
        public string SenderName { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(
            SenderEmailMaxLength,
            MinimumLength = SenderEmailMinLength,
            ErrorMessage = LengthMessage)]
        public string SenderEmail { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(
            SubjectMaxLength,
            MinimumLength = SubjectMinLength,
            ErrorMessage = LengthMessage)]
        public string Subject { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(
            MessageMaxLength,
            MinimumLength = MessageMinLength,
            ErrorMessage = LengthMessage)]
        public string Message { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(
            PhoneNumberMaxLength,
            MinimumLength = PhoneNumberMinLength,
            ErrorMessage = LengthMessage)]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
    }
}
