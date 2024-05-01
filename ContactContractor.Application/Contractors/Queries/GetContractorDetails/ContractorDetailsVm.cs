using AutoMapper;
using ContactContractor.Application.Common.Mappings;
using ContactContractor.Domain;

namespace ContactContractor.Application.Contractors.Queries.GetContractorDetails
{
    public class ContractorDetailsVm : IMapWith<Contractor>
    {
        public Guid ContractorId { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Contractor, ContractorDetailsVm>()
                .ForMember(contractorVm => contractorVm.ContractorId,
                    opt => opt.MapFrom(contractor => contractor.ContractorId))
                .ForMember(contractorVm => contractorVm.Name,
                    opt => opt.MapFrom(contractor => contractor.Name))
                .ForMember(contractorVm => contractorVm.CreationDate,
                    opt => opt.MapFrom(contractor => contractor.CreationDate))
                .ForMember(contractorVm => contractorVm.EditDate,
                    opt => opt.MapFrom(contractor => contractor.EditDate));
        }
    }
}
