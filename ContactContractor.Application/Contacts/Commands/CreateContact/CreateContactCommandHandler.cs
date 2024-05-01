using MediatR;
using ContactContractor.Domain;
using ContactContractor.Application.Interfaces;

namespace ContactContractor.Application.Contacts.Commands.CreateContact
{
    public class CreateContactCommandHandler : IRequestHandler<CreateContactCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateContactCommandHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Guid> Handle(CreateContactCommand request, CancellationToken cancellationToken)
        {
            var contact = new Contact
            {
                ContactId = Guid.NewGuid(),
                FullName = request.FullName,
                Email = request.Email,
                CreationDate = DateTime.UtcNow,
                EditDate = null,
                ContractorId = request.ContractorId,
            };

            await _dbContext.Contacts.AddAsync(contact, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return contact.ContactId;

        }
    }
}