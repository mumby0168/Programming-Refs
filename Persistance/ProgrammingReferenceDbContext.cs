using Microsoft.EntityFrameworkCore;
using Programming_Reference_Website.Models;

namespace Programming_Reference_Website.Persistance
{
    public class ProgrammingReferenceDbContext : DbContext
    {
        public ProgrammingReferenceDbContext(DbContextOptions<ProgrammingReferenceDbContext> options) : base(options) {}
        public DbSet<User> Users { get; set; }

        
    }
}