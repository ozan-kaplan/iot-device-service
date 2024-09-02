using AutoMapper;
using IoTDeviceService.Application.Models;
using IoTDeviceService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTDeviceService.Application.Mapping
{
    public class DeviceMapping : Profile
    {
        public DeviceMapping()
        {
            CreateMap<Device, DeviceDto>();
            CreateMap<PagedResultModel<Device>, PagedResultModel<DeviceDto>>();
        }
    }
}
