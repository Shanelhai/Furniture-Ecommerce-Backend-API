using FurnitureBackEnd.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureBackEnd.Controllers
{
    [Route("api/Category")]
    [ApiController]
    public class Category : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public Category(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetCategory()
        {
            return Ok(_context.Categories.ToList());
        }
        [HttpPost]
        public IActionResult CreateCategory([FromBody] Models.Category category)
        {
            if (category == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public IActionResult UpdateCategory([FromBody] Models.Category category)
        {
            if (category == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteCategory(int id)
        {
            var categoryInDb = _context.Categories.Find(id);
            if (categoryInDb == null) return NotFound();
            _context.Categories.Remove(categoryInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
