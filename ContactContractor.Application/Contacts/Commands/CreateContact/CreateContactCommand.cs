using MediatR;

namespace ContactContractor.Application.Contacts.Commands.CreateContact
{
    public class CreateContactCommand : IRequest<Guid>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public Guid ContractorId { get; set; }
    }
}
