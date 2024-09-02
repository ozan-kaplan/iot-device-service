using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTDeviceService.Application.Features.Commands.DeleteDevice
{
    public class DeleteDeviceCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
