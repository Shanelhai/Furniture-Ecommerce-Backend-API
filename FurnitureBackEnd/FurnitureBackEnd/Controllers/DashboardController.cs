using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FurnitureBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        [Authorize(Roles = "User")]
        [HttpGet("user")]
        public IActionResult UserDashboard()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Ok($"Welcome, User! Your ID is: {userId}");
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin")]
        public IActionResult AdminDashboard()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            return Ok($"Welcome, Admin! Your ID is:");
        }
    }
}
