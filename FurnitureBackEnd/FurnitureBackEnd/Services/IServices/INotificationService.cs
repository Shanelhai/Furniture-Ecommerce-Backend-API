using FurnitureBackEnd.DTO;

namespace FurnitureBackEnd.Services.IServices
{
    public interface INotificationService
    {
        Task SendAllConfirmations(OrderBookingDTO dto);
    }
}
