using IoTDeviceService.Application.Interfaces.Repositories;
using IoTDeviceService.Domain.Entities;
using MediatR;

namespace IoTDeviceService.Application.Queries.Handlers
{
    public class GetDeviceByIdQuery : IRequest<Device>
    {
        public Guid Id { get; set; }

        public GetDeviceByIdQuery(Guid id)
        {
            Id = id;
        }
    }
    public class GetDeviceByIdQueryHandler : IRequestHandler<GetDeviceByIdQuery, Device?>
    {
        private readonly IDeviceRepository _deviceRepository;

        public GetDeviceByIdQueryHandler(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<Device?> Handle(GetDeviceByIdQuery request, CancellationToken cancellationToken)
        {
            return await _deviceRepository.GetByIdAsync(request.Id);
        }
    }
}
