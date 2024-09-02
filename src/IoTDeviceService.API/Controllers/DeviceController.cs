using IoTDeviceService.Application.Features.Commands.CreateDevice;
using IoTDeviceService.Application.Features.Commands.DeleteDevice;
using IoTDeviceService.Application.Features.Commands.UpdateDevice;
using IoTDeviceService.Application.Features.Queries.GetDeviceById;
using IoTDeviceService.Application.Features.Queries.GetPagedDevices;
using IoTDeviceService.Application.Models;
using MediatR;
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeviceById(Guid id)
        {
            var device = await _mediator.Send(new GetDeviceByIdQuery(id));
            if (device == null)
            {
                return NotFound();
            }
            return Ok(device);
        }

        [HttpGet]
        public async Task<IActionResult> GetPagedDevices([FromQuery] PagedQueryModel queryModel)
        {
            var query = new GetPagedDevicesQuery(queryModel);
            var devices = await _mediator.Send(query);
            return Ok(devices);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDevice(Guid id, [FromBody] UpdateDeviceCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            var result = await _mediator.Send(command);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDevice(Guid id)
        {
            await _mediator.Send(new DeleteDeviceCommand(id));
            return NoContent();
        }
    }
}
