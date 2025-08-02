using FurnitureBackEnd.DTO;
using FurnitureBackEnd.Identity;
using FurnitureBackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FurnitureBackEnd.Controllers
{
    [Route("api/Shoppingcart")]
    [ApiController]
    public class ShoppincartController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ShoppincartController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ShoppingcartDTO>>> GetShoppingcarts()
        {
            var carts = await _context.ShoppingCarts
                .Include(s => s.Product)
                .ToListAsync();

            var response = carts.Select(s => new ShoppingcartDTO
            {
                Id = s.Id,
                ApplicationUserId = s.ApplicationUserId,
                ProductId = s.ProductId,
                Count = s.Count,
                Price = s.Product.Price * s.Count
            });

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShoppingcartDTO>> GetShoppingcart(int id)
        {
            var cart = await _context.ShoppingCarts
                .Include(s => s.Product)
                .FirstOrDefaultAsync(s => s.Id == id);

            if (cart == null)
                return NotFound();

            var response = new ShoppingcartDTO
            {
                Id = cart.Id,
                ApplicationUserId = cart.ApplicationUserId,
                ProductId = cart.ProductId,
                Count = cart.Count,
                Price = cart.Product.Price * cart.Count
            };

            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ShoppingcartDTO>> PostShoppingcart(ShoppingcartDTO shoppingcartDto)
        {
            var shoppingcart = new Shoppingcart
            {
                ApplicationUserId = shoppingcartDto.ApplicationUserId,
                ProductId = shoppingcartDto.ProductId,
                Count = shoppingcartDto.Count
            };

            _context.Attach(new ApplicationUser { Id = shoppingcart.ApplicationUserId }).State = EntityState.Unchanged;
            _context.Attach(new Product { Id = shoppingcart.ProductId }).State = EntityState.Unchanged;

            _context.ShoppingCarts.Add(shoppingcart);
            await _context.SaveChangesAsync();

            // Load product to calculate price
            var product = await _context.Products.FindAsync(shoppingcart.ProductId);

            var response = new ShoppingcartDTO
            {
                Id = shoppingcart.Id,
                ApplicationUserId = shoppingcart.ApplicationUserId,
                ProductId = shoppingcart.ProductId,
                Count = shoppingcart.Count,
                Price = product.Price * shoppingcart.Count
            };

            return CreatedAtAction(nameof(GetShoppingcart), new { id = shoppingcart.Id }, response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutShoppingcart(int id, [FromBody] ShoppingcartDTO shoppingcartDto)

        {
            var existingCart = await _context.ShoppingCarts.FindAsync(id);
            if (existingCart == null)
                return NotFound();

            existingCart.ProductId = shoppingcartDto.ProductId;
            existingCart.ApplicationUserId = shoppingcartDto.ApplicationUserId;
            existingCart.Count = shoppingcartDto.Count;

            _context.Attach(new ApplicationUser { Id = shoppingcartDto.ApplicationUserId }).State = EntityState.Unchanged;
            _context.Attach(new Product { Id = shoppingcartDto.ProductId }).State = EntityState.Unchanged;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingcart(int id)
        {
            var shoppingcart = await _context.ShoppingCarts.FindAsync(id);


            if (shoppingcart == null)
                return NotFound();


            _context.ShoppingCarts.Remove(shoppingcart);
            await _context.SaveChangesAsync();


            return NoContent();
        }
    }
}
