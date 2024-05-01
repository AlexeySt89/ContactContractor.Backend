using AutoMapper;
using ContactContractor.Application.Common.Mappings;
using ContactContractor.Application.Contractors.Commands.UpdateContractor;

namespace ContactContractor.WebApi.Models
{
    public class UpdateContractorDto : IMapWith<UpdateContractorCommand>
    {
        public Guid ContractorId { get; set; }
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateContractorDto, UpdateContractorCommand>()
                .ForMember(contractorCommand => contractorCommand.ContractorId,
                    opt => opt.MapFrom(contractorDto => contractorDto.ContractorId))
                .ForMember(contractorCommand => contractorCommand.Name,
                    opt => opt.MapFrom(contractorDto => contractorDto.Name));
        }
    }
}
