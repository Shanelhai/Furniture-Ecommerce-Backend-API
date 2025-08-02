using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureBackEnd.Models
{
    public class CustomFurniture
    {
        public int Id { get; set; }

        [Required]
        public int CarpenterBookingId { get; set; }

        [ForeignKey("CarpenterBookingId")]
        public CarpenterBooking CarpenterBooking { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100000)]
        public string Description { get; set; }

        [Required]
        [Range(1, 100000)]
        public decimal EstimatedCost { get; set; }

        [StringLength(50)]
        public string Material { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        [Display(Name = "Expected Completion Date")]
        public DateTime? ExpectedCompletionDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Planned";
    }
}
