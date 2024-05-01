using AutoMapper;
using ContactContractor.Application.Common.Exception;
using ContactContractor.Application.Contacts.Queries.Vm;
using ContactContractor.Application.Interfaces;
using ContactContractor.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactContractor.Application.Contacts.Queries.GetContactDetails
{
    public class GetContactDetailsQueryHandler : IRequestHandler<GetContactDetailsQuery, ContactDetailsVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetContactDetailsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ContactDetailsVm> Handle(GetContactDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Contacts.FirstOrDefaultAsync(contact => contact.ContactId == request.ContactId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Contact), request);
            }

            return _mapper.Map<ContactDetailsVm>(entity);
        }
    }
}
