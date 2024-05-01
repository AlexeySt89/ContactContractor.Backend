using ContactContractor.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using ContactContractor.Application.Common.Exception;
using ContactContractor.Domain;

namespace ContactContractor.Application.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommandHandler : IRequestHandler<UpdateContactCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateContactCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Contacts.FirstOrDefaultAsync(contact => contact.ContactId == request.ContactId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Contact), request.ContactId);
            }

            entity.FullName = request.FullName;
            entity.Email = request.Email;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return request.ContactId;
        }
    }
}
