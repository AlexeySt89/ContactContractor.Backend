using AutoMapper;
using AutoMapper.QueryableExtensions;
using ContactContractor.Application.Contacts.Queries.Vm;
using ContactContractor.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactContractor.Application.Contacts.Queries.GetContactList
{
    public class GetContactListQueryHandler : IRequestHandler<GetContactListQuery, ContactListVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetContactListQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<ContactListVm> Handle(GetContactListQuery request, CancellationToken cancellationToken)
        {
            var contactsQuery = await _dbContext.Contacts
                .ProjectTo<ContactLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ContactListVm { Contacts = contactsQuery };
        }
    }
}
