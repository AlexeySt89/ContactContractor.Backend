using ContactContractor.Application.Interfaces;
using ContactContractor.Domain;
using ContactContractor.Persistence.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ContactContractor.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Contractor> Contractors { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactConfiguration());
            modelBuilder.ApplyConfiguration(new ContractorConfiguration());
            modelBuilder.Entity<Contact>()
                .HasOne(c => c.Contractor)
                .WithMany(con => con.Contacts)
                .HasForeignKey(c => c.ContractorId);
        }

    }
}
