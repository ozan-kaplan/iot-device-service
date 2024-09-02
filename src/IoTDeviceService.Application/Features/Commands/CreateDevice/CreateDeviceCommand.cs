using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTDeviceService.Application.Features.Commands.CreateDevice
{
    public class CreateDeviceCommand : IRequest<Guid>
    {
        public Guid CustomerId { get; set; }
        public required string Name { get; set; }
        public required string SerialNumber { get; set; }
    }

}
