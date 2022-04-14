using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Report.API.Services;
using SharedLibrary;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly IReportGeneratorService _reportGeneratorService;

        public LocationController(IReportGeneratorService reportGeneratorService)
        {
            _reportGeneratorService = reportGeneratorService ?? throw new ArgumentNullException(nameof(reportGeneratorService));
        }

        [HttpGet("Get")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Get(BaseRequest request)
        {
            await _reportGeneratorService.GetList(request);
            return Ok();
        }

        [HttpGet("GetDetails")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetDetails(Guid reportId)
        {
            var response = await _reportGeneratorService.Get(reportId);
            return Ok(response);
        }

        [HttpGet("List-Of-Requests")]
        [ProducesResponseType(typeof(Guid), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create()
        {
            var response = await _reportGeneratorService.Create();

            return Ok(response);
        }




    }
}
