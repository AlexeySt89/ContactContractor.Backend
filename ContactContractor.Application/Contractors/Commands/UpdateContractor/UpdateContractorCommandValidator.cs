using FluentValidation;

namespace ContactContractor.Application.Contractors.Commands.UpdateContractor
{
    public class UpdateContractorCommandValidator : AbstractValidator<UpdateContractorCommand>
    {
        public UpdateContractorCommandValidator()
        {
            RuleFor(updateContractorCommand => updateContractorCommand.ContractorId).NotEqual(Guid.Empty);
            RuleFor(updateContractorCommand => updateContractorCommand.Name).NotEmpty();
        }
    }
}