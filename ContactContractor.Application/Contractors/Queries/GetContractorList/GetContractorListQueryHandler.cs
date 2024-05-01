using AutoMapper;
using AutoMapper.QueryableExtensions;
using ContactContractor.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactContractor.Application.Contractors.Queries.GetContractorList
{
    public class GetContractorListQueryHandler : IRequestHandler<GetContractorListQuery, ContractorListVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetContractorListQueryHandler(IApplicationDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ContractorListVm> Handle(GetContractorListQuery request, CancellationToken cancellationToken)
        {
            var contracotrQuery = await _dbContext.Contractors
                .ProjectTo<ContractorLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ContractorListVm { Contractors = contracotrQuery };
        }
    }
}
