using FluentValidation;

namespace ContactContractor.Application.Contractors.Queries.GetContractorDetails
{
    public class GetContractorDetailsQueryValidator : AbstractValidator<GetContractorDetailsQuery>
    {
        public GetContractorDetailsQueryValidator()
        {
            RuleFor(createContractorCommand => createContractorCommand.ContractorId).NotEqual(Guid.Empty);
        }
    }
}
