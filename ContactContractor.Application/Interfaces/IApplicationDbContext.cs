using ContactContractor.Domain;
using Microsoft.EntityFrameworkCore;

namespace ContactContractor.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Contact> Contacts { get; set; }
        DbSet<Contractor> Contractors { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
