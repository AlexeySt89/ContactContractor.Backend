using AutoMapper;
using ContactContractor.Application.Contractors.Commands.CreateContractor;
using ContactContractor.Application.Contractors.Commands.DeleteContractor;
using ContactContractor.Application.Contractors.Commands.UpdateContractor;
using ContactContractor.Application.Contractors.Queries.GetContractorDetails;
using ContactContractor.Application.Contractors.Queries.GetContractorList;
using ContactContractor.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContactContractor.WebApi.Controllers
{
    public class ContractorController : BaseController
    {
        private readonly IMapper _mapper;

        public ContractorController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the list of contractors
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /contractor
        /// </remarks>
        /// <returns>Returns ContractorListVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ContractorListVm>> GetAll()
        {
            var query = new GetContractorListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the contractor by id 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /contractor/2AC2E0C3-B73D-47AD-AD46-08000DAEBE41
        /// </remarks>
        /// <returns>Returns ContractortDetailsVm</returns>
        /// <response code="200">Success</response>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ContractorDetailsVm>> Get(Guid contractorId)
        {
            var query = new GetContractorDetailsQuery
            {
                ContractorId = contractorId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Create the contractor
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /contractor 
        /// {
        ///     name: "contractor name"
        /// }
        /// </remarks>
        /// <param name="createContractorDto">CreateContractorDto object</param>
        /// <returns>Returns id (guid)</returns>
        /// <response code="200">Success</response>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateContractorDto createContractorDto)
        {
            var command = _mapper.Map<CreateContractorCommand>(createContractorDto);
            var contractorId = await Mediator.Send(command);
            return Ok(contractorId);
        }

        /// <summary>
        /// Updates the contractor
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /contractor 
        /// {
        ///     "contractorId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///     "name": "contractor name"
        /// }
        /// </remarks>
        /// <param name="updateContractorDto">UpdateContractorDto object</param>
        /// <returns>Returns id(guid)</returns>
        /// <response code="200">Success</response>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Update([FromBody] UpdateContractorDto updateContractorDto)
        {
            var command = _mapper.Map<UpdateContractorCommand>(updateContractorDto);
            //command.ContactId = contractorId;
            var contractorId = await Mediator.Send(command);
            return Ok(contractorId);
        }

        /// <summary>
        /// Deletes the contractor by id 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /contractor/2AC2E0C3-B73D-47AD-AD46-08000DAEBE41
        /// </remarks>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(Guid contractorId)
        {
            var command = new DeleteContractorCommand
            {
                ContractorId = contractorId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
