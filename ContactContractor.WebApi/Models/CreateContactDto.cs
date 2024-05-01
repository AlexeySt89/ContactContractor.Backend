using AutoMapper;
using ContactContractor.Application.Common.Mappings;
using ContactContractor.Application.Contacts.Commands.CreateContact;
using System.ComponentModel.DataAnnotations;

namespace ContactContractor.WebApi.Models
{
    public class CreateContactDto : IMapWith<CreateContactCommand>
    {
        [Required] 
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateContactDto, CreateContactCommand>()
                .ForMember(contactCommand => contactCommand.FullName,
                    opt => opt.MapFrom(contactDto => contactDto.FullName))
                .ForMember(contactCommand => contactCommand.Email,
                    opt => opt.MapFrom(contactDto => contactDto.Email));

        }
    }
}
