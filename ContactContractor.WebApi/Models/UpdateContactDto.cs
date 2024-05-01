using AutoMapper;
using ContactContractor.Application.Common.Mappings;
using ContactContractor.Application.Contacts.Commands.UpdateContact;

namespace ContactContractor.WebApi.Models
{
    public class UpdateContactDto : IMapWith<UpdateContactCommand>
    {
        public Guid ContactId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateContactDto, UpdateContactCommand>()
                .ForMember(contactCommand => contactCommand.ContactId,
                    opt => opt.MapFrom(contactDto => contactDto.ContactId))
                .ForMember(contactCommand => contactCommand.FullName,
                    opt => opt.MapFrom(contactDto => contactDto.FullName))
                .ForMember(contactCommand => contactCommand.Email,
                    opt => opt.MapFrom(contactDto => contactDto.Email));
        }
    }
}
