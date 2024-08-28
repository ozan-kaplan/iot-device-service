using IoTDeviceService.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace IoTDeviceService.Infrastructure.Persistence.EntityConfigurations
{
    public class DeviceConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.HasKey(d => d.Id);
            builder.Property(d => d.Name)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(d => d.SerialNumber)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(d => d.Status)
                .IsRequired();
        }
    }
}
