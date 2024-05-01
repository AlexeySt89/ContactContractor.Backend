using AutoMapper;
using ContactContractor.Application.Contacts.Commands.CreateContact;
using ContactContractor.Application.Contacts.Commands.DeleteContact;
using ContactContractor.Application.Contacts.Commands.UpdateContact;
using ContactContractor.Application.Contacts.Queries.GetContactDetails;
using ContactContractor.Application.Contacts.Queries.GetContactList;
using ContactContractor.Application.Contacts.Queries.GetContactListById;
using ContactContractor.Application.Contacts.Queries.Vm;
using ContactContractor.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactContractor.WebApi.Controllers
{
    public class ContactController : BaseController
    {
        private readonly IMapper _mapper;

        public ContactController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the list of contacts
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /contact
        /// </remarks>
        /// <returns>Returns ContactListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ContactListVm>> GetAll()
        {
            var query = new GetContactListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the contact by id 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /contact/2AC2E0C3-B73D-47AD-AD46-08000DAEBE41
        /// </remarks>
        /// <returns>Returns ContactDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ContactDetailsVm>> Get(Guid contactId)
        {
            var query = new GetContactDetailsQuery
            {
                ContactId = contactId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the contact by contractor id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /contractor/2AC2E0C3-B73D-47AD-AD46-08000DAEBE41
        /// </remarks>
        /// <returns>Returns ContactListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ContactListVm>> GetByContractorId(Guid contractorId)
        {
            var query = new GetContactListByIdQuery
            {
                ContractorId = contractorId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Create the contact
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /contact 
        /// {
        ///     fullname: "contact fullname",
        ///     email: "contact email"
        /// }
        /// </remarks>
        /// <param name="createContactDto">CreateContactDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateContactDto createContactDto, Guid contractorId)
        {
            var command = _mapper.Map<CreateContactCommand>(createContactDto);
            command.ContractorId = contractorId;
            var contactId = await Mediator.Send(command);
            return Ok(contactId);
        }

        /// <summary>
        /// Updates the contact
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /contact 
        /// {
        ///     "contactId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///     "fullName": "contact fullname",
        ///     "email": "contact email"
        /// }
        /// </remarks>
        /// <param name="updateContactDto">UpdateContactDto object</param>
        /// <returns>Returns id(guid)</returns>
        /// <response code="200">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] UpdateContactDto updateContactDto)
        {
            var command = _mapper.Map<UpdateContactCommand>(updateContactDto);
            var contactId = await Mediator.Send(command);
            return Ok(contactId);
        }

        /// <summary>
        /// Deletes the contact by id 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /contact/2AC2E0C3-B73D-47AD-AD46-08000DAEBE41
        /// </remarks>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid contactId)
        {
            var command = new DeleteContactCommand
            {
                ContactId = contactId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
