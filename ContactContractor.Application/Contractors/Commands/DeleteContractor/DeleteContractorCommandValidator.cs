using FluentValidation;

namespace ContactContractor.Application.Contractors.Commands.DeleteContractor
{
    public class DeleteContractorCommandValidator : AbstractValidator<DeleteContractorCommand>
    {
        public DeleteContractorCommandValidator()
        {
            RuleFor(deleteContractorCommand => deleteContractorCommand.ContractorId).NotEqual(Guid.Empty);
        }
    }
}