using MediatR;

namespace ContactContractor.Application.Contractors.Commands.CreateContractor
{
    public class CreateContractorCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }
}
