using IoTDeviceService.Application.Interfaces.Repositories;
using IoTDeviceService.Application.Models;
using IoTDeviceService.Domain.Entities;
using MediatR;

namespace IoTDeviceService.Application.Queries.Handlers
{
    public class GetPagedDevicesQuery : IRequest<PagedResultModel<Device>>
    {
        public PagedQueryModel QueryModel { get; set; }

        public GetPagedDevicesQuery(PagedQueryModel queryModel)
        {
            QueryModel = queryModel;
        }
    }

    public class GetPagedDevicesQueryHandler : IRequestHandler<GetPagedDevicesQuery, PagedResultModel<Device>>
    {

        private readonly List<string> validColumns = new List<string> { "Name", "SerialNumber" };

        private readonly IDeviceRepository _deviceRepository;

        public GetPagedDevicesQueryHandler(IDeviceRepository deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public async Task<PagedResultModel<Device>> Handle(GetPagedDevicesQuery request, CancellationToken cancellationToken)
        {

            if (request.QueryModel.Filters != null)
            {
                foreach (var filter in request.QueryModel.Filters.Keys)
                {
                    if (!validColumns.Contains(filter))
                    {
                        throw new ArgumentException($"Invalid filter column: {filter}");
                    }
                }
            }


            return await _deviceRepository.GetPagedAsync(
                request.QueryModel.PageNumber,
                request.QueryModel.PageSize,
                request.QueryModel.Sort,
                request.QueryModel.Filters);
        }
    }
}
