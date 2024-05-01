using MediatR;

namespace ContactContractor.Application.Contractors.Queries.GetContractorDetails
{
    public class GetContractorDetailsQuery : IRequest<ContractorDetailsVm>
    {
        public Guid ContractorId { get; set; }
    }
}
