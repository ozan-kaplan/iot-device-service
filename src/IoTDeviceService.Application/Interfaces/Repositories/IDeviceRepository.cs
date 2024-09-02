using IoTDeviceService.Application.Models;
using IoTDeviceService.Domain.Entities;

namespace IoTDeviceService.Application.Interfaces.Repositories
{
    public interface IDeviceRepository
    {
        Task<Device?> GetByIdAsync(Guid id);
        Task<PagedResultModel<Device>> GetPagedAsync(int pageNumber, int pageSize, SortModel? sort, Dictionary<string, string>? filters);
        Task AddAsync(Device device);
        Task UpdateAsync(Device device);
    }
}
