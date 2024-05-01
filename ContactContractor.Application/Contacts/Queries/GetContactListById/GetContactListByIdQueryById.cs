using FluentValidation;

namespace ContactContractor.Application.Contacts.Queries.GetContactListById
{
    public class GetContactListByIdQueryById : AbstractValidator<GetContactListByIdQuery>
    {
        public GetContactListByIdQueryById()
        {
            RuleFor(createContactCommand => createContactCommand.ContractorId).NotEqual(Guid.Empty);
        }
    }
}