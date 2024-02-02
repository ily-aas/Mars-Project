using Mars_Project_1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace Mars_Project_1.Controllers
{

    // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class TeamsController : ControllerBase
    {

        private readonly MarsProjectDbContext _context;

        // Constructor that takes an instance of MarsProjectDbContext through dependency injection.
        public TeamsController(MarsProjectDbContext context)
        {
            _context = context;
        }


        // GET method for retrieving all teams
        // GET endpoint: /teams
        [HttpGet(Name = "GetTeams")]
        public async Task<IEnumerable<Teams>> Get()
        {

            // loading async to prevent blocking while DB operations occur
            var teamsWithUserId = await _context.Teams
              .ToListAsync();

            return teamsWithUserId;
        }


        // POST method for adding a new team
        // POST endpoint: /teams
        [HttpPost]
        public async Task<ActionResult<Teams>> PostComplaint(Teams teams)
        {
            //set created at date
            teams.teamdateCreated = DateTime.UtcNow;

            // Adding the provided team to the Teams DbSet.
            _context.Teams.Add(teams);

            // Saving changes to the database.
            await _context.SaveChangesAsync();

            // Return a CreatedAtAction result with the newly created team and its ID.
            return CreatedAtAction(nameof(GetTeams), new { id = teams.teamID }, teams);
        }

        // This is an example GET method for retrieving a complaint by id
        // GET api/complaint/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Teams>> GetTeams(int id)
        {

            //Using Entity Framework to find a team by its ID asynchronously.
            var teams = await _context.Teams.FindAsync(id);
            // Exception Handling: If the team is not found, return a NotFound result.
            if (teams == null)
            {
                return NotFound();
            }
            return teams;
        }
    }

}

