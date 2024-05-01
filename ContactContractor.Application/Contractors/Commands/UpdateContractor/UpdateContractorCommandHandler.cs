using ContactContractor.Application.Common.Exception;
using ContactContractor.Application.Interfaces;
using ContactContractor.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactContractor.Application.Contractors.Commands.UpdateContractor
{
    public class UpdateContractorCommandHandler : IRequestHandler<UpdateContractorCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateContractorCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(UpdateContractorCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Contractors.FirstOrDefaultAsync(contractor => contractor.ContractorId == request.ContractorId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Contact), request.ContractorId);
            }

            entity.Name = request.Name;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return request.ContractorId;
        }
    }
}
