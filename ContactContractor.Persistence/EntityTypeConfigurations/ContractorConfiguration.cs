using ContactContractor.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ContactContractor.Persistence.EntityTypeConfigurations
{
    public class ContractorConfiguration : IEntityTypeConfiguration<Contractor>
    {
        public void Configure(EntityTypeBuilder<Contractor> builder)
        {
            builder.HasKey(contractor => contractor.ContractorId);
            builder.HasIndex(contractor => contractor.ContractorId).IsUnique();
            builder.HasIndex(contractor => contractor.Name).IsUnique();
        }
    }
}
