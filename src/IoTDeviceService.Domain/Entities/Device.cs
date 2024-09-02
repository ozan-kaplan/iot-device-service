namespace IoTDeviceService.Domain.Entities
{
    public class Device
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public required string Name { get; set; }
        public required string SerialNumber { get; set; }
        public bool IsDeleted { get; set; }
        public DeviceStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
