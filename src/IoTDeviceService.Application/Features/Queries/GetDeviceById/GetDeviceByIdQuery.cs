using IoTDeviceService.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTDeviceService.Application.Features.Queries.GetDeviceById
{
    public class GetDeviceByIdQuery : IRequest<DeviceDto>
    {
        public Guid Id { get; set; }

        public GetDeviceByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
