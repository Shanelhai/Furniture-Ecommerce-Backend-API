using FurnitureBackEnd.DTO;
using FurnitureBackEnd.Identity;
using FurnitureBackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FurnitureBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHeaderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderHeaderController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/OrderHeader
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderHeaderDTO>>> GetOrderHeaders()
        {
            var orders = await _context.OrderHeaders
                .Select(o => new OrderHeaderDTO
                {
                    Id = o.Id,
                    ApplicationUserId = o.ApplicationUserId,
                    OrderDate = o.OrderDate,
                    ShippingDate = o.ShippingDate,
                    OrderTotal = o.OrderTotal,
                    TrackingNumber = o.TrackingNumber,
                    Carrier = o.Carrier,
                    OrderStatus = o.OrderStatus,
                    PaymentStatus = o.PaymentStatus,
                    PaymentDate = o.PaymentDate,
                    PaymentDueDate = o.PaymentDueDate,
                    TransactionId = o.TransactionId,
                    Name = o.Name,
                    StreetAddress = o.StreetAddress,
                    City = o.City,
                    State = o.State,
                    PostalCode = o.PostalCode,
                    PhoneNumber = o.PhoneNumber
                }).ToListAsync();

            return Ok(orders);
        }

        // GET: api/OrderHeader/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderHeaderDTO>> GetOrderHeader(int id)
        {
            var o = await _context.OrderHeaders.FindAsync(id);

            if (o == null)
                return NotFound();

            var dto = new OrderHeaderDTO
            {
                Id = o.Id,
                ApplicationUserId = o.ApplicationUserId,
                OrderDate = o.OrderDate,
                ShippingDate = o.ShippingDate,
                OrderTotal = o.OrderTotal,
                TrackingNumber = o.TrackingNumber,
                Carrier = o.Carrier,
                OrderStatus = o.OrderStatus,
                PaymentStatus = o.PaymentStatus,
                PaymentDate = o.PaymentDate,
                PaymentDueDate = o.PaymentDueDate,
                TransactionId = o.TransactionId,
                Name = o.Name,
                StreetAddress = o.StreetAddress,
                City = o.City,
                State = o.State,
                PostalCode = o.PostalCode,
                PhoneNumber = o.PhoneNumber
            };

            return Ok(dto);
        }

        // POST: api/OrderHeader
        [HttpPost]
        public async Task<ActionResult<OrderHeaderDTO>> PostOrderHeader(OrderHeaderDTO dto)
        {
            var entity = new OrderHeader
            {
                ApplicationUserId = dto.ApplicationUserId,
                OrderDate = dto.OrderDate,
                ShippingDate = dto.ShippingDate,
                OrderTotal = dto.OrderTotal,
                TrackingNumber = dto.TrackingNumber,
                Carrier = dto.Carrier,
                OrderStatus = dto.OrderStatus,
                PaymentStatus = dto.PaymentStatus,
                PaymentDate = dto.PaymentDate,
                PaymentDueDate = dto.PaymentDueDate,
                TransactionId = dto.TransactionId,
                Name = dto.Name,
                StreetAddress = dto.StreetAddress,
                City = dto.City,
                State = dto.State,
                PostalCode = dto.PostalCode,
                PhoneNumber = dto.PhoneNumber
            };

            _context.OrderHeaders.Add(entity);
            await _context.SaveChangesAsync();

            dto.Id = entity.Id; // set ID after saving

            return CreatedAtAction(nameof(GetOrderHeader), new { id = dto.Id }, dto);
        }

        // PUT: api/OrderHeader/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrderHeader(int id, OrderHeaderDTO dto)
        {
            if (id != dto.Id)
                return BadRequest();

            var entity = await _context.OrderHeaders.FindAsync(id);
            if (entity == null)
                return NotFound();

            // Update fields
            entity.ApplicationUserId = dto.ApplicationUserId;
            entity.OrderDate = dto.OrderDate;
            entity.ShippingDate = dto.ShippingDate;
            entity.OrderTotal = dto.OrderTotal;
            entity.TrackingNumber = dto.TrackingNumber;
            entity.Carrier = dto.Carrier;
            entity.OrderStatus = dto.OrderStatus;
            entity.PaymentStatus = dto.PaymentStatus;
            entity.PaymentDate = dto.PaymentDate;
            entity.PaymentDueDate = dto.PaymentDueDate;
            entity.TransactionId = dto.TransactionId;
            entity.Name = dto.Name;
            entity.StreetAddress = dto.StreetAddress;
            entity.City = dto.City;
            entity.State = dto.State;
            entity.PostalCode = dto.PostalCode;
            entity.PhoneNumber = dto.PhoneNumber;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/OrderHeader/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderHeader(int id)
        {
            var entity = await _context.OrderHeaders.FindAsync(id);
            if (entity == null)
                return NotFound();

            _context.OrderHeaders.Remove(entity);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
