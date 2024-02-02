using Mars_Project_1.Models;
using Microsoft.EntityFrameworkCore;
namespace Mars_Project_1
{

    // Defines a class that represents the database context for the application.
    public class MarsProjectDbContext : DbContext
    {
        // Constructor that takes DbContextOptions as a parameter and passes it to the base class constructor.
        public MarsProjectDbContext(DbContextOptions<MarsProjectDbContext> options): base(options)
        {

        }

        // DbSet property for the 'Teams' entity, allowing interaction with the 'Teams' table in the database.
        public DbSet<Teams> Teams { get; set; }

        // DbSet property for the 'Complaint' entity, allowing interaction with the 'Complaint' table in the database.
        public DbSet<Complaint> Complaint { get; set; }

        // DbSet property for the 'Users' entity, allowing interaction with the 'Users' table in the database.
        public DbSet<Users> Users { get; set; }

        // DbSet property for the 'Players' entity, allowing interaction with the 'Players' table in the database.
        public DbSet<Players> Players { get; set; }

    }
}
