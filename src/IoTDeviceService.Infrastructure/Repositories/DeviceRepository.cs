using IoTDeviceService.Application.Interfaces.Repositories;
using IoTDeviceService.Domain.Entities;
using IoTDeviceService.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTDeviceService.Infrastructure.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly DeviceDbContext _context;

        public DeviceRepository(DeviceDbContext context)
        {
            _context = context;
        }

        public async Task<Device?> GetByIdAsync(Guid id)
        {
            return await _context.Devices.FindAsync(id);
        }

        public async Task<IEnumerable<Device>> GetAllAsync()
        {
            return await _context.Devices.ToListAsync();
        }

        public async Task AddAsync(Device device)
        {
            await _context.Devices.AddAsync(device);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Device device)
        {
            _context.Devices.Update(device);
            await _context.SaveChangesAsync();
        }
         
    }
}
