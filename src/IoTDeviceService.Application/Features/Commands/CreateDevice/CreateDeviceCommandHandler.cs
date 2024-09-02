using IoTDeviceService.Application.Interfaces.Repositories;
using IoTDeviceService.Domain.Entities;
using MediatR;

namespace IoTDeviceService.Application.Features.Commands.CreateDevice
{

    public class CreateDeviceCommandHandler : IRequestHandler<CreateDeviceCommand, Guid>
    {
        private readonly IDeviceRepository _deviceRepository;

        public CreateDeviceCommandHandler(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<Guid> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
        {
            var device = new Device
            {
                Id = Guid.NewGuid(),
                CustomerId = request.CustomerId,
                Name = request.Name,
                SerialNumber = request.SerialNumber,
                Status = DeviceStatus.Active,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            await _deviceRepository.AddAsync(device);
            return device.Id;
        }
    }
}
