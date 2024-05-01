using MediatR;

namespace ContactContractor.Application.Contractors.Commands.UpdateContractor
{
    public class UpdateContractorCommand : IRequest<Guid>
    {
        public Guid ContractorId { get; set; }
        public string Name { get; set; }
    }
}
