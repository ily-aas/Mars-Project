using Mars_Project_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mars_Project_1.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly MarsProjectDbContext _context;

        // Constructor that takes an instance of MarsProjectDbContext through dependency injection.
        public UserController(MarsProjectDbContext context)
        {
            _context = context;
        }


        // GET method for retrieving a complaint by id
        // GET endpoint: /complaint/2
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> GetUser(int id)
        {

            // Using Entity Framework to find a user by their ID asynchronously.
            var user = await _context.Users.FindAsync(id);

            // Exception Handling: If the user is not found, return a NotFound result.
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }
    }
}

