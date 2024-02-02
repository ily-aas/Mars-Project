
using Mars_Project_1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace Mars_Project_1.Controllers
{

    // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ComplaintsController : ControllerBase
    {
        private readonly MarsProjectDbContext _context;

        // Constructor that takes an instance of MarsProjectDbContext through dependency injection.
        public ComplaintsController(MarsProjectDbContext context)
        {
            _context = context;
        }

        // GET method for retrieving all complaints
        // GET endpoint: /complaints
        [HttpGet(Name = "GetComplaints")]
        public async Task<IEnumerable<Complaint>> Get()
        {

            // Loading complaints asynchronously from the database to prevent blocking.
            var complaintsWithDetails = await _context.Complaint
             .ToListAsync();

            return complaintsWithDetails;
        }

        // POST method for adding a new complaint
        // POST endpoint: /complaints
        [HttpPost]
        public async Task<ActionResult<Complaint>> PostComplaint(Complaint complaint)
        {
            //set created at date
            complaint.complaintDateCreated = DateTime.UtcNow;

            // Adding the provided complaint to the Complaints DbSet.
            _context.Complaint.Add(complaint);

            // Saving changes to the database.
            await _context.SaveChangesAsync();

            // Return a CreatedAtAction result with the newly created complaint and its ID.
            return CreatedAtAction(nameof(GetComplaint), new { id = complaint.ID }, complaint);
        }


        // This is an example GET method for retrieving a complaint by id
        // GET api/complaint/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Complaint>> GetComplaint(int id)
        {

            // Using Entity Framework to find a complaint by its ID asynchronously.
            var complaint = await _context.Complaint
             .FirstOrDefaultAsync(c => c.ID == id);

            // Exception Handling: If the complaint is not found, return a NotFound result.
            if (complaint == null)
            {
                return NotFound();
            }
            return complaint;
        }
    }

}
