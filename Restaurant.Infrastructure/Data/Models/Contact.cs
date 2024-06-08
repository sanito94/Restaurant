using System.ComponentModel.DataAnnotations;
using static Restaurant.Infrastructure.Constants.DataConstants;

namespace Restaurant.Infrastructure.Data.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required, Display(Name = "Email")]
        [StringLength(SenderEmailMaxLength)]
        public string SenderEmail { get; set; } = null!;

        [Required, Display(Name = "Name")]
        [StringLength(SenderNameMaxLength)]
        public string SenderName { get; set; } = null!;

        [Required]
        [StringLength(SubjectMaxLength)]
        public string Subject { get; set; } = null!;

        [Required]
        [StringLength(MessageMaxLength)]
        public string Message { get; set; } = null!;

        [Required]
        [StringLength(PhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public DateTime Date { get; set; }
    }
}
