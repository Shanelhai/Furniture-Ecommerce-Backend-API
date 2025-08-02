namespace FurnitureBackEnd.DTO
{
    public class OrderBookingDTO
    {
        public string CustomerId { get; set; }
        public int ProductId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime? ScheduledDate { get; set; }
        public string ServiceType { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;
        public string CustomerEmail { get; set; } = string.Empty;
        public string CustomerPhoneNumber { get; set; } = string.Empty;
    }
}
