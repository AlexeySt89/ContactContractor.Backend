using FluentValidation;

namespace ContactContractor.Application.Contacts.Commands.UpdateContact
{
    public class UpdateContactCommandValidator : AbstractValidator<UpdateContactCommand>
    {
        public UpdateContactCommandValidator()
        {
            RuleFor(updateContactCommand => updateContactCommand.ContactId).NotEqual(Guid.Empty);
            RuleFor(updateContactCommand => updateContactCommand.FullName).NotEmpty();
            RuleFor(updateContactCommand => updateContactCommand.Email).NotEmpty();
        }
    }
}