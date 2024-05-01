using FluentValidation;

namespace ContactContractor.Application.Contractors.Commands.CreateContractor
{
    public class CreateContractorCommandValidator : AbstractValidator<CreateContractorCommand>
    {
        public CreateContractorCommandValidator()
        {
            RuleFor(createContractorCommand => createContractorCommand.Name).NotEmpty();
        }
    }
}