using ContactContractor.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactContractor.Persistence.EntityTypeConfigurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.HasKey(contact => contact.ContactId);
            builder.HasIndex(contact => contact.ContactId).IsUnique();
            builder.HasIndex(contact => contact.Email).IsUnique();
        }
    }
}
