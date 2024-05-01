using ContactContractor.Application.Contacts.Queries.Vm;
using MediatR;

namespace ContactContractor.Application.Contacts.Queries.GetContactList
{
    public class GetContactListQuery : IRequest<ContactListVm>
    {
    }
}
