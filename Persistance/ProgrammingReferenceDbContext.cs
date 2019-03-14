using Microsoft.EntityFrameworkCore;
using Programming_Reference_Website.Models;
using Programming_Reference_Website.Models.Configurations;

namespace Programming_Reference_Website.Persistance
{
    public class ProgrammingReferenceDbContext : DbContext
    {
        public ProgrammingReferenceDbContext(DbContextOptions<ProgrammingReferenceDbContext> options) : base(options) {}
        public DbSet<User> Users { get; set; }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<WebResource> WebResources { get; set; }

        public DbSet<TopicLanguage> TopicLanguages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TopicConfiguration());
        }
    }
}