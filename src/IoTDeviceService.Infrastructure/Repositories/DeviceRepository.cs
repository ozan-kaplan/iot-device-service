using IoTDeviceService.Application.Interfaces.Repositories;
using IoTDeviceService.Application.Models;
using IoTDeviceService.Domain.Entities;
using IoTDeviceService.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

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
            return await _context.Devices.FirstOrDefaultAsync(d => d.Id == id && !d.IsDeleted);
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

        public async Task<PagedResultModel<Device>> GetPagedAsync(int pageNumber, int pageSize, SortModel? sort, Dictionary<string, string>? filters)
        {
            var query = _context.Devices.Where(d => !d.IsDeleted);

            if (filters != null)
                foreach (var filter in filters)
                    query = query.Where($"{filter.Key}.Contains(@0)", filter.Value);

            var totalRecords = await query.CountAsync();

            if (sort != null && !string.IsNullOrEmpty(sort.SortBy))
                query = sort.SortDirection == SortDirection.Descending ? query.OrderBy($"{sort.SortBy} descending") : query.OrderBy(sort.SortBy);

            var items = await query.Skip((pageNumber - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();

            return new PagedResultModel<Device>(items, totalRecords);
        }
    }
}
