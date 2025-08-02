using FurnitureBackEnd.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FurnitureBackEnd.Controllers
{
    [Route("api/Company")]
    [ApiController]
    public class Company : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public Company(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCompany()
        {
            return Ok(_context.Companys.ToList());
        }

        [HttpPost]
        public IActionResult CreateCompany([FromBody] Models.Company company)
        {
            if (company == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            _context.Companys.Add(company);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCompany([FromBody] Models.Company company)
        {
            if (company == null) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();
            _context.Companys.Update(company);
            _context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteCompany(int id)
        {
            var companyInDb = _context.Companys.Find(id);
            if (companyInDb == null) return NotFound();
            _context.Companys.Remove(companyInDb);
            _context.SaveChanges();
            return Ok();
        }
    }
}
