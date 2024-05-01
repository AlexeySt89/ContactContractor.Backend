using ContactContractor.Application.Contacts.Queries.Vm;
using MediatR;

namespace ContactContractor.Application.Contacts.Queries.GetContactDetails
{
    public class GetContactDetailsQuery : IRequest<ContactDetailsVm>
    {
        public Guid ContactId { get; set; }
    }
}
