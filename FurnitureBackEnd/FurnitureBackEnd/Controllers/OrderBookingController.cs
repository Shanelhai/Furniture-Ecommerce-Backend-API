using FurnitureBackEnd.DTO;
using FurnitureBackEnd.Identity;
using FurnitureBackEnd.Models;
using FurnitureBackEnd.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FurnitureBackEnd.Controllers
{
    [Route("api/OrderBooking")]
    [ApiController]
    public class OrderBookingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly INotificationService _notificationService;

        public OrderBookingController(ApplicationDbContext context, INotificationService notificationService)
        {
            _context = context;
            _notificationService = notificationService;
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookOrder([FromBody] OrderBookingDTO dto)
        {
            var customerId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(customerId))
            {
                return BadRequest("Invalid token. User ID not found.");
            }

            var user = await _context.Users.FindAsync(customerId);
            if (user == null)
            {
                return BadRequest("User not found.");
            }

            var booking = new OrderBooking
            {
                ProductId = dto.ProductId,
                BookingDate = dto.BookingDate,
                ScheduledDate = dto.ScheduledDate,
                ServiceType = dto.ServiceType,
                Notes = dto.Notes,
                Status = "Pending",
                CustomerId = customerId
            };
            _context.OrderBooking.Add(booking);
            await _context.SaveChangesAsync();

            var header = new OrderHeader
            {
                ApplicationUserId = customerId,
                OrderDate = DateTime.Now,
                ShippingDate = dto.ScheduledDate ?? DateTime.Now.AddDays(2),
                OrderTotal = 1000,
                TrackingNumber = "TRK" + DateTime.Now.Ticks,
                Carrier = "Local",
                OrderStatus = "Confirmed",
                PaymentStatus = "Pending",
                PaymentDate = DateTime.Now,
                PaymentDueDate = DateTime.Now.AddDays(7),
                TransactionId = "TXN" + Guid.NewGuid(),
                Name = user.UserName ?? "Customer Name",
                StreetAddress = "Customer Street",
                City = "City",
                State = "State",
                PostalCode = "123456",
                PhoneNumber = dto.CustomerPhoneNumber
            };
            _context.OrderHeaders.Add(header);
            await _context.SaveChangesAsync();

            var detail = new OrderDetails
            {
                OrderHeaderId = header.Id,
                ProductId = dto.ProductId,
                Count = 1,
                Price = 1000
            };
            _context.OrderDetails.Add(detail);
            await _context.SaveChangesAsync();

            await _notificationService.SendAllConfirmations(dto);

            return Ok(new { success = true, orderId = booking.Id });
        }
    }
}
