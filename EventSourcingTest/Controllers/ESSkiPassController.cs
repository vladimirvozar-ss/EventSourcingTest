using EventSourcingTest.Contracts;
using EventSourcingTest.Infrastructure;
using EventSourcingTest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace EventSourcingTest.Controllers
{
    /// <summary>
    /// ESSki Pass controller.
    /// </summary>
    [ApiController]
    //[Authorize]
    [Route("api/v1/[controller]")]
    public class ESSkiPassController : ControllerBase
    {
        private readonly SkiPassService _skiPassService;
        private static readonly Serilog.ILogger Log = Serilog.Log.ForContext<ESSkiPassController>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ESSkiPassController"/> class.
        /// </summary>
        /// <param name="skiPassService">SkiPasses service.</param>
        /// <param name="logger">Logger.</param>
        public ESSkiPassController(SkiPassService skiPassService)
        {
            _skiPassService = skiPassService;
        }

        /// <summary>
        /// Create new Ski Pass.
        /// </summary>
        /// <param name="request">"Create" SkiPass request contract.</param>
        /// <returns>200 OK.</returns>
        [HttpPost]
        [Route("create")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Post(SkiPasses.V1.Create request)
        {
            return await RequestHandler.HandleCommand(request, _skiPassService.Handle, Log);
        }

        /// <summary>
        /// Update a Ski Pass name.
        /// </summary>
        /// <param name="request">"UpdateName" SkiPass request contract.</param>
        /// <returns>200 OK.</returns>
        [HttpPut]
        [Route("updatename")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(SkiPasses.V1.UpdateName request)
        {
            return await RequestHandler.HandleCommand(request, _skiPassService.Handle, Log);
        }

        /// <summary>
        /// Update "IsDefault" property of the Ski Pass.
        /// </summary>
        /// <param name="request">"UpdateDefault" SkiPass request contract.</param>
        /// <returns>200 OK.</returns>
        [HttpPut]
        [Route("updatedefault")]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> Put(SkiPasses.V1.UpdateDefault request)
        {
            return await RequestHandler.HandleCommand(request, _skiPassService.Handle, Log);
        }
    }
}
