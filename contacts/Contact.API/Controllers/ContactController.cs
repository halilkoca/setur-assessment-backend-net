using AutoMapper;
using Contact.API.ApiModels;
using Contact.API.Infrastructure.Contacts;
using Contact.API.Model;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _contactRepository = contactRepository ?? throw new ArgumentNullException(nameof(contactRepository));
        }

        [HttpGet("get")]
        [ProducesResponseType(typeof(IEnumerable<ContactModel>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get([FromQuery] BaseRequest request)
        {
            var contacts = await _contactRepository.Get(request);
            return Ok(contacts);
        }

        [HttpGet("{id:length(24)}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ContactModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();
            var products = await _contactRepository.Get(id);
            return Ok(products);
        }

        [HttpGet("GetByName/{name}")]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        [ProducesResponseType(typeof(ContactModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return NotFound();
            var products = await _contactRepository.GetByName(name);
            return Ok(products);
        }

        [HttpPost("Create")]
        [ProducesResponseType(typeof(ContactModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create([FromBody] ContactCreateCommand request)
        {
            if (request == null)
                return NotFound();

            var model = _mapper.Map<ContactModel>(request);

            await _contactRepository.Create(model);
            return Ok(model);
        }

        [HttpPost("CreateBulk")]
        [ProducesResponseType(typeof(ContactModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateBulk([FromBody] List<ContactCreateCommand> request)
        {
            if (request == null || request.Count == 0)
                return NotFound();

            var model = _mapper.Map<List<ContactModel>>(request);

            await _contactRepository.Create(model);

            return Ok(request);
        }

        [HttpPut("Update")]
        [ProducesResponseType(typeof(ContactModel), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update([FromBody] ContactUpdateCommand request)
        {
            if (request == null)
                return NotFound();

            var model = _mapper.Map<ContactModel>(request);

            await _contactRepository.Update(model);

            return Ok(model);
        }

        [HttpDelete("Delete/{id:length(24)}")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return NotFound();

            return Ok(await _contactRepository.Delete(id));
        }

        [HttpDelete("DeleteBulk")]
        [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteBulk(List<string> id)
        {
            if (id == null || id.Count == 0)
                return NotFound();

            return Ok(await _contactRepository.Delete(id));
        }
    }
}
