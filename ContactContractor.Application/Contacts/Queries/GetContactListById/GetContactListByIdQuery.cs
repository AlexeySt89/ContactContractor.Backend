using ContactContractor.Application.Contacts.Queries.Vm;
using MediatR;

namespace ContactContractor.Application.Contacts.Queries.GetContactListById
{
    public class GetContactListByIdQuery : IRequest<ContactListVm>
    {
        public Guid ContractorId { get; set; }
    }
}