using FurnitureBackEnd.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureBackEnd.Models
{
    public class CarpenterBooking
    {
        public int Id { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }

        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        [Required]
        public DateTime VisitDate { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

        [MaxLength(1000)]
        public string ProblemDescription { get; set; }

        [MaxLength(50)]
        public string Status { get; set; } = "Pending";
    }
}
