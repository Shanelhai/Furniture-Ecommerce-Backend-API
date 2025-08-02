using System.ComponentModel.DataAnnotations;

namespace FurnitureBackEnd.DTO
{
        public class CarpenterBookingRequestDTO
        {
            [Required]
            public string ApplicationUserId { get; set; }
            
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
            public string Status { get; set; }
        }
}
