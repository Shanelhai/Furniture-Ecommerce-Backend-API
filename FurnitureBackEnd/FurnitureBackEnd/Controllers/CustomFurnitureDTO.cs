using System.ComponentModel.DataAnnotations;

namespace FurnitureBackEnd.Controllers
{
    public class CustomFurnitureDTO
    {
        [Required]
        public int CarpenterBookingId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [Range(1, 100000)]
        public decimal EstimatedCost { get; set; }

        [StringLength(50)]
        public string Material { get; set; }

        [StringLength(50)]
        public string Color { get; set; }

        public DateTime? ExpectedCompletionDate { get; set; }

        [StringLength(50)]
        public string Status { get; set; } = "Planned";
    }
}
