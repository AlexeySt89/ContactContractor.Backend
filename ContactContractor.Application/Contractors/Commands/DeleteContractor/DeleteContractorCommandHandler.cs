using ContactContractor.Application.Common.Exception;
using ContactContractor.Application.Interfaces;
using ContactContractor.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactContractor.Application.Contractors.Commands.DeleteContractor
{
    public class DeleteContractorCommandHandler : IRequestHandler<DeleteContractorCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteContractorCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteContractorCommand request, CancellationToken cancellationToken)
        {
            var contractor = _dbContext.Contractors.Include(contractor => contractor.Contacts).Single(contractor => contractor.ContractorId == request.ContractorId);

            if (contractor == null)
            {
                throw new NotFoundException(nameof(Contractor), request.ContractorId);
            }

            _dbContext.Contacts.RemoveRange(contractor.Contacts);
            _dbContext.Contractors.Remove(contractor);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
