using FurnitureBackEnd.DTO;
using FurnitureBackEnd.Services.IServices;
using System.Threading.Tasks;

namespace FurnitureBackEnd.Services
{
    public class NotificationService : INotificationService
    {
        private readonly EmailService _emailService;
        private readonly WhatsappService _whatsappService;

        public NotificationService(EmailService emailService, WhatsappService whatsappService)
        {
            _emailService = emailService;
            _whatsappService = whatsappService;
        }

        // Mark method as async and return Task
        public async Task SendAllConfirmations(OrderBookingDTO dto)
        {
            string message = $"Your order on {dto.BookingDate} for service '{dto.ServiceType}' is confirmed.";
            await _emailService.Send(dto.CustomerEmail, "Order Confirmation", message);
            await _whatsappService.Send(dto.CustomerPhoneNumber, message);
        }
    }
}
