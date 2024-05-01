using FluentValidation;

namespace ContactContractor.Application.Contacts.Commands.DeleteContact
{
    public class DeleteContactCommandValidator : AbstractValidator<DeleteContactCommand>
    {
        public DeleteContactCommandValidator()
        {
            RuleFor(deleteContactCommand => deleteContactCommand.ContactId).NotEqual(Guid.Empty);
        }
    }
}