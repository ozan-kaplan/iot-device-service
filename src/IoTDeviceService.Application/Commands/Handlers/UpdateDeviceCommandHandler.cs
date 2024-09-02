using IoTDeviceService.Application.Interfaces.Repositories;
using MediatR;
namespace IoTDeviceService.Application.Commands.Handlers
{
    public class UpdateDeviceCommand : IRequest<bool>
    {
        public Guid Id { get; set; } 
        public required string Name { get; set; }
        public required string SerialNumber { get; set; }
    }

    public class UpdateDeviceCommandHandler : IRequestHandler<UpdateDeviceCommand, bool>
    {
        private readonly IDeviceRepository _deviceRepository;

        public UpdateDeviceCommandHandler(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<bool> Handle(UpdateDeviceCommand request, CancellationToken cancellationToken)
        {
            var device = await _deviceRepository.GetByIdAsync(request.Id);
            if (device == null)
                return false;

            device.Name = request.Name;
            device.SerialNumber = request.SerialNumber;

            await _deviceRepository.UpdateAsync(device);

            return true;
        }
    }
}
