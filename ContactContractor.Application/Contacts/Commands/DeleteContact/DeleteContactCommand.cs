using MediatR;

namespace ContactContractor.Application.Contacts.Commands.DeleteContact
{
    public class DeleteContactCommand : IRequest
    {
        public Guid ContactId { get; set; }
    }
}
