using Microsoft.EntityFrameworkCore;

namespace ElectLive_API.Data.Model
{
    // This class represents the application's database context, which inherits from DbContext.
    public class ApplicationDbContext : DbContext
    {
        // Constructor that takes DbContextOptions as a parameter to configure the database context.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // DbSet property for the Election entity, which allows interaction with the corresponding database table.
        public virtual DbSet<Election> Elections { get; set; }

        // DbSet property for the Voting entity, which allows interaction with the corresponding database table.
        public virtual DbSet<Voting> Votings { get; set; }
    }
}

