using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTDeviceService.Application.Models
{
    public class DeviceDto
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public required string Name { get; set; }
        public required string SerialNumber { get; set; }
    }
}
