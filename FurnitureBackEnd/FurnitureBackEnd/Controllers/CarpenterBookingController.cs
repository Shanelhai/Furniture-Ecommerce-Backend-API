using FurnitureBackEnd.DTO;
using FurnitureBackEnd.Identity;
using FurnitureBackEnd.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace FurnitureBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarpenterBookingController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarpenterBookingController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("book")]
        public async Task<IActionResult> BookCarpenter([FromBody] CarpenterBookingRequestDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var booking = new CarpenterBooking
            {
                ApplicationUserId = dto.ApplicationUserId,
                BookingDate = dto.BookingDate,
                VisitDate = dto.VisitDate,
                Address = dto.Address,
                ProblemDescription = dto.ProblemDescription,
                Status = dto.Status ?? "Pending"
            };

            try
            {
                _context.CarpenterBooking.Add(booking);
                await _context.SaveChangesAsync();

                return Ok(new
                {
                    Message = "Booking created successfully",
                    BookingId = booking.Id
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Error = "Error while creating booking",
                    Details = ex.Message
                });
            }
        }
    }
}
