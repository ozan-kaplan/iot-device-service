using IoTDeviceService.Application.Commands.Handlers;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IoTDeviceService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeviceController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateDevice(CreateDeviceCommand command)
        {
            return Ok(await _mediator.Send(command));
        }
    }
}
