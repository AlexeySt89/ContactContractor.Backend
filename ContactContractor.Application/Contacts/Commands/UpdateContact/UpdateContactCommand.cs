using MediatR;

namespace ContactContractor.Application.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommand : IRequest<Guid>
    {
        public Guid ContactId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
