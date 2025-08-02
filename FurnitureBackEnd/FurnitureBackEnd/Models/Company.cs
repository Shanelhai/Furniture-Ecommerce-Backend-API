using System.ComponentModel.DataAnnotations;

namespace FurnitureBackEnd.Models
{
    public class Company
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        [MaxLength(250)]
        public string StreetAddress { get; set; }

        [Required]
        [MaxLength(100)]
        public string City { get; set; }

        [Required]
        [MaxLength(100)]
        public string State { get; set; }

        [Required]
        [Display(Name = "Postal Code")]
        [MaxLength(20)]
        public string PostalCode { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Is Authorized Company")]
        public bool IsAuthorizedCompany { get; set; }
    }
}
