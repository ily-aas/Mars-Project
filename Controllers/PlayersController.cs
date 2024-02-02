using Mars_Project_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Numerics;

namespace Mars_Project_1.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly MarsProjectDbContext _context;

        // Constructor that takes an instance of MarsProjectDbContext through dependency injection.
        public PlayersController(MarsProjectDbContext context)
        {
            _context = context;
        }

        // GET method for retrieving all players
        // GET endpoint: /players
        [HttpGet(Name = "GetPlayers")]
        public async Task<IEnumerable<Players>> Get()
        {
            // loading async to prevent blocking while DB operations occur
            var test = await _context.Players.ToListAsync();
            return await _context.Players.ToListAsync();
        }


        // POST method for adding a new player
        // POST endpoint: /players
        [HttpPost]
        public async Task<ActionResult<Players>> PostComplaint(Players players)
        {

            // Adding the provided player to the Players DbSet.
            _context.Players.Add(players);

            // Saving changes to the database.
            await _context.SaveChangesAsync();

            // Return a CreatedAtAction result with the newly created player and its ID.
            return CreatedAtAction(nameof(GetPlayers), new { id = players.Id }, players);
        }

        // This is an example GET method for retrieving a complaint by id
        // GET api/complaint/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Players>> GetPlayers(int id)
        {

            // Using Entity Framework to find a player by their ID asynchronously.
            var player = await _context.Players.FindAsync(id);

            // Exception Handling: If the player is not found, return a NotFound result.
            if (player == null)
                if (player == null)
                {
                    return NotFound();
                }

            return player;
        }
    }
}
