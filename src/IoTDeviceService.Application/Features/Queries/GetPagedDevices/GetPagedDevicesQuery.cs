using IoTDeviceService.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTDeviceService.Application.Features.Queries.GetPagedDevices
{
    public class GetPagedDevicesQuery : IRequest<PagedResultModel<DeviceDto>>
    {
        public PagedQueryModel QueryModel { get; set; }

        public GetPagedDevicesQuery(PagedQueryModel queryModel)
        {
            QueryModel = queryModel;
        }
    }
}
