using ContactContractor.Application.Common.Exception;
using ContactContractor.Application.Interfaces;
using ContactContractor.Domain;
using MediatR;

namespace ContactContractor.Application.Contacts.Commands.DeleteContact
{
    public class DeleteContactCommandHandler : IRequestHandler<DeleteContactCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteContactCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Contacts.FindAsync(new object[] { request.ContactId }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Contact), request.ContactId);
            }

            _dbContext.Contacts.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
