using IoTDeviceService.Application.Interfaces.Repositories;
using MediatR;

namespace IoTDeviceService.Application.Features.Commands.DeleteDevice
{ 

    public class DeleteDeviceCommandHandler : IRequestHandler<DeleteDeviceCommand, bool>
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeleteDeviceCommandHandler(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<bool> Handle(DeleteDeviceCommand request, CancellationToken cancellationToken)
        {
            var device = await _deviceRepository.GetByIdAsync(request.Id);
            if (device == null || device.IsDeleted)
                return false;

            device.UpdatedAt = DateTime.Now;
            device.IsDeleted = true;

            await _deviceRepository.UpdateAsync(device);

            return true;
        }
    }
}
