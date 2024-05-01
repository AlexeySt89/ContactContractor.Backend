using AutoMapper;
using ContactContractor.Application.Common.Mappings;
using ContactContractor.Domain;

namespace ContactContractor.Application.Contractors.Queries.GetContractorList
{
    public class ContractorLookupDto : IMapWith<Contractor>
    {
        public Guid ContractorId { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Contractor, ContractorLookupDto>()
                .ForMember(contractorVm => contractorVm.ContractorId,
                    opt => opt.MapFrom(contractor => contractor.ContractorId))
                .ForMember(contractorVm => contractorVm.Name,
                    opt => opt.MapFrom(contractor => contractor.Name));
        }
    }
}
