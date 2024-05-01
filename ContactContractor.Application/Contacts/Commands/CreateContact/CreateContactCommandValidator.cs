using FluentValidation;

namespace ContactContractor.Application.Contacts.Commands.CreateContact
{
    public class CreateContactCommandValidator : AbstractValidator<CreateContactCommand>
    {
        public CreateContactCommandValidator()
        {
            RuleFor(createContactCommand => createContactCommand.FullName).NotEmpty();
            RuleFor(createContactCommand => createContactCommand.Email).NotEmpty();
            RuleFor(createContactCommand => createContactCommand.ContractorId).NotEqual(Guid.Empty);
        }
    }
}