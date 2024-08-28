using IoTDeviceService.Domain.Entities;

namespace IoTDeviceService.Application.Interfaces.Repositories
{
    public interface IDeviceRepository
    {
        Task<Device?> GetByIdAsync(Guid id);
        Task<IEnumerable<Device>> GetAllAsync();
        Task AddAsync(Device device);
        Task UpdateAsync(Device device);
    }
}
