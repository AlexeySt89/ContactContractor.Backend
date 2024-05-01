using MediatR;

namespace ContactContractor.Application.Contractors.Commands.DeleteContractor
{
    public class DeleteContractorCommand : IRequest
    {
        public Guid ContractorId { get; set; }
    }
}
