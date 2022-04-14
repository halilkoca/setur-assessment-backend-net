using AutoMapper;
using Contact.API.ApiModels;
using Contact.API.Infrastructure.ContactInformations;
using Contact.API.Model;
using MassTransit;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Contact.API.Controllers
{

    [ApiController]
    [Route("api/v1/[controller]")]
    public class ContactInformationController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContactInformationRepository _contactInformationRepository;


        public ContactInformationController(IMapper mapper,
                                            IContactInformationRepository contactInformationRepository)
        {
            _contactInformationRepository = contactInformationRepository ?? throw new ArgumentNullException(nameof(contactInformationRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpPost("Create")]
        [ProducesResponseType(typeof(ContactInformationCreateCommand), (int)HttpStatusCode.OK)]
        public async Task<ActionResult> Create([FromQuery] string id, [FromBody] ContactInformationCreateCommand request)
        {
            if (string.IsNullOrWhiteSpace(id) || request == null)
                return NotFound();

            var model = _mapper.Map<ContactInformationModel>(request);

            await _contactInformationRepository.Create(id, model);

            return Ok(request);
        }

        [HttpPut("Update")]
        [ProducesResponseType(typeof(ContactInformationUpdateCommand), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromQuery] string id, [FromBody] ContactInformationUpdateCommand request)
        {
            if (string.IsNullOrWhiteSpace(id) || request == null)
                return NotFound();

            var model = _mapper.Map<ContactInformationModel>(request);

            await _contactInformationRepository.Update(id, model);

            return Ok(request);
        }

        [HttpDelete("Delete/{id:length(24)},{informationId:length(24)}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete([FromQuery] string id, [FromQuery] string informationId)
        {
            if (string.IsNullOrWhiteSpace(id) || string.IsNullOrWhiteSpace(informationId))
                return NotFound();

            var result = await _contactInformationRepository.Delete(id, informationId);

            return Ok(result);
        }

        [HttpDelete("DeleteBulk")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBulk([FromQuery] string id, [FromBody] List<string> informationIds)
        {
            if (string.IsNullOrWhiteSpace(id) || informationIds == null || informationIds.Count == 0)
                return NotFound();

            var result = await _contactInformationRepository.Delete(id, informationIds);

            return Ok(result);
        }
    }
}
