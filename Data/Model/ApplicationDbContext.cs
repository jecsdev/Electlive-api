using Microsoft.EntityFrameworkCore;

namespace ElectLive_API.Data.Model
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public virtual DbSet<Election> Elections { get; set; }
    }
}
