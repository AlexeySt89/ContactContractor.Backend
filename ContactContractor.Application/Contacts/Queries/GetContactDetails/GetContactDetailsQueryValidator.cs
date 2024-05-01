using FluentValidation;

namespace ContactContractor.Application.Contacts.Queries.GetContactDetails
{
    public class GetContactDetailsQueryValidator : AbstractValidator<GetContactDetailsQuery>
    {
        public GetContactDetailsQueryValidator()
        {
            RuleFor(createContactCommand => createContactCommand.ContactId).NotEqual(Guid.Empty);
        }
    }
}