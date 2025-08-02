using FurnitureBackEnd.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FurnitureBackEnd.Models
{
    public class OrderBooking
    {
        public int Id { get; set; }

        [Required]
        public string CustomerId { get; set; } = string.Empty;

        [ForeignKey("CustomerId")]
        public ApplicationUser? Customer { get; set; }

        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public Product? Product { get; set; }

        [Required]
        public DateTime BookingDate { get; set; }

        public DateTime? ScheduledDate { get; set; }

        [Required]
        public string ServiceType { get; set; } = string.Empty;

        public string Notes { get; set; } = string.Empty;

        public string Status { get; set; } = "Pending";
    }
}
