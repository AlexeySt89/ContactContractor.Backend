using AutoMapper;
using AutoMapper.QueryableExtensions;
using ContactContractor.Application.Contacts.Queries.Vm;
using ContactContractor.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactContractor.Application.Contacts.Queries.GetContactListById
{
    public class GetContactListByIdQueryHandler : IRequestHandler<GetContactListByIdQuery, ContactListVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetContactListByIdQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ContactListVm> Handle(GetContactListByIdQuery request, CancellationToken cancellationToken)
        {
            var contactsQuery = await _dbContext.Contacts
                .Where(contact => contact.ContractorId == request.ContractorId)
                .ProjectTo<ContactLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ContactListVm { Contacts = contactsQuery };
        }
    }
}
