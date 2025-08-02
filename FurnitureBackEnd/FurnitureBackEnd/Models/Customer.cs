using FurnitureBackEnd.Identity;
using System.ComponentModel.DataAnnotations;

namespace FurnitureBackEnd.Models
{
    public class Customer
    {
        public int Id { get; set; }

        public string? ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        [Display(Name = "Full Name")]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Street Address")]
        [MaxLength(250)]
        public string StreetAddress { get; set; }

        [MaxLength(100)]
        public string City { get; set; }

        [MaxLength(100)]
        public string State { get; set; }

        [Display(Name = "Postal Code")]
        [MaxLength(20)]
        public string PostalCode { get; set; }
    }
}
