using ContactContractor.Application.Interfaces;
using ContactContractor.Domain;
using MediatR;

namespace ContactContractor.Application.Contractors.Commands.CreateContractor
{
    public class CreateContractorCommandHandler : IRequestHandler<CreateContractorCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateContractorCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateContractorCommand request, CancellationToken cancellationToken)
        {
            var contractor = new Contractor
            {
                ContractorId = Guid.NewGuid(),
                Name = request.Name,
                CreationDate = DateTime.UtcNow,
                EditDate = null,
                Contacts = null,
            };

            await _dbContext.Contractors.AddAsync(contractor, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return contractor.ContractorId;
        }
    }
}
