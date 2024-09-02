using AutoMapper;
using IoTDeviceService.Application.Interfaces.Repositories;
using IoTDeviceService.Application.Models;
using IoTDeviceService.Domain.Entities;
using MediatR;

namespace IoTDeviceService.Application.Queries.Handlers
{
    public class GetPagedDevicesQuery : IRequest<PagedResultModel<DeviceDto>>
    {
        public PagedQueryModel QueryModel { get; set; }

        public GetPagedDevicesQuery(PagedQueryModel queryModel)
        {
            QueryModel = queryModel;
        }
    }

    public class GetPagedDevicesQueryHandler : IRequestHandler<GetPagedDevicesQuery, PagedResultModel<DeviceDto>>
    {

        private readonly List<string> _validColumns = new List<string> { "Name", "SerialNumber", "CustomerId" };

        private readonly IDeviceRepository _deviceRepository;
        private readonly IMapper _mapper;

        public GetPagedDevicesQueryHandler(IDeviceRepository deviceRepository, IMapper mapper)
        {
            _deviceRepository = deviceRepository;
            _mapper = mapper;
        }

        public async Task<PagedResultModel<DeviceDto>> Handle(GetPagedDevicesQuery request, CancellationToken cancellationToken)
        {

            if (request.QueryModel.Filters != null)
            {
                foreach (var filter in request.QueryModel.Filters.Keys)
                {
                    if (!_validColumns.Contains(filter))
                    {
                        throw new ArgumentException($"Invalid filter column: {filter}");
                    }
                }
            }

            return _mapper.Map<PagedResultModel<DeviceDto>>(await _deviceRepository.GetPagedAsync(
                   request.QueryModel.PageNumber,
                   request.QueryModel.PageSize,
                   request.QueryModel.Sort,
                   request.QueryModel.Filters));
        }
    }
}
