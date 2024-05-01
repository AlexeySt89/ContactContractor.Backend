using AutoMapper;
using ContactContractor.Application.Common.Mappings;
using ContactContractor.Application.Contractors.Commands.CreateContractor;
using System.ComponentModel.DataAnnotations;

namespace ContactContractor.WebApi.Models
{
    public class CreateContractorDto : IMapWith<CreateContractorCommand>
    {
        [Required]
        public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateContractorDto, CreateContractorCommand>()
                .ForMember(contractorCommand => contractorCommand.Name,
                    opt => opt.MapFrom(contractorDto => contractorDto.Name));
        }
    }
}
