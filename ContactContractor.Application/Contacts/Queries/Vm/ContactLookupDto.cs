using AutoMapper;
using ContactContractor.Application.Common.Mappings;
using ContactContractor.Domain;

namespace ContactContractor.Application.Contacts.Queries.Vm
{
    public class ContactLookupDto : IMapWith<Contact>
    {
        public Guid ContactId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Contact, ContactLookupDto>()
                .ForMember(contactVm => contactVm.ContactId,
                    opt => opt.MapFrom(contact => contact.ContactId))
                .ForMember(contactVm => contactVm.FullName,
                    opt => opt.MapFrom(contact => contact.FullName))
                .ForMember(contactVm => contactVm.Email,
                    opt => opt.MapFrom(contact => contact.Email));
        }
    }
}
