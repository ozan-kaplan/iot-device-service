using AutoMapper;
using IoTDeviceService.Application.Interfaces.Repositories;
using IoTDeviceService.Application.Models;
using IoTDeviceService.Domain.Entities;
using MediatR;

namespace IoTDeviceService.Application.Features.Queries.GetDeviceById
{ 
    public class GetDeviceByIdQueryHandler : IRequestHandler<GetDeviceByIdQuery, DeviceDto?>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public GetDeviceByIdQueryHandler(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        public async Task<DeviceDto?> Handle(GetDeviceByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<DeviceDto>(await _deviceRepository.GetByIdAsync(request.Id));
        }
    }
}
