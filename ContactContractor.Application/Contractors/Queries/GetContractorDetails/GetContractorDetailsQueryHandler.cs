using AutoMapper;
using ContactContractor.Application.Common.Exception;
using ContactContractor.Application.Interfaces;
using ContactContractor.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactContractor.Application.Contractors.Queries.GetContractorDetails
{
    public class GetContractorDetailsQueryHandler : IRequestHandler<GetContractorDetailsQuery, ContractorDetailsVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetContractorDetailsQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ContractorDetailsVm> Handle(GetContractorDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Contractors.FirstOrDefaultAsync(contact => contact.ContractorId == request.ContractorId, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Contact), request);
            }

            return _mapper.Map<ContractorDetailsVm>(entity);
        }
    }
}
