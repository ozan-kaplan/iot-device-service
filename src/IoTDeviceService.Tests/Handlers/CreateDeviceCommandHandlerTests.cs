using IoTDeviceService.Application.Commands.Handlers;
using IoTDeviceService.Application.Interfaces.Repositories;
using IoTDeviceService.Domain.Entities;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IoTDeviceService.Tests.Handlers
{
    public class CreateDeviceCommandHandlerTests
    {
        private readonly Mock<IDeviceRepository> _deviceRepositoryMock;
        private readonly CreateDeviceCommandHandler _handler;

        public CreateDeviceCommandHandlerTests()
        {
            _deviceRepositoryMock = new Mock<IDeviceRepository>();
            _handler = new CreateDeviceCommandHandler(_deviceRepositoryMock.Object);
        }

        /// <summary>
        /// Bu test, Handle metodunun geçerli bir istek aldığında AddAsync metodunu yalnızca bir kez çağırıp çağırmadığını kontrol eder.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldCallAddAsyncOnce_WhenValidRequest()
        {
            // Arrange
            var command = new CreateDeviceCommand
            {
                Name = "Test Device",
                SerialNumber = "12345"
            };

            // Act
            await _handler.Handle(command, CancellationToken.None);

            // Assert
            _deviceRepositoryMock.Verify(repo => repo.AddAsync(It.IsAny<Device>()), Times.Once);
        }

        /// <summary>
        /// Bu test, cihaz oluşturulduğunda doğru cihaz ID'sinin döndüğünü kontrol eder.
        /// </summary>
        /// <returns></returns>
        [Fact]
        public async Task Handle_ShouldReturnDeviceId_WhenDeviceIsCreated()
        {
            // Arrange
            var deviceId = Guid.NewGuid();
            var command = new CreateDeviceCommand
            {
                Name = "Test Device",
                SerialNumber = "12345"
            };

            _deviceRepositoryMock.Setup(repo => repo.AddAsync(It.IsAny<Device>()))
                                 .Callback<Device>(d => d.Id = deviceId);

            // Act
            var result = await _handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal(deviceId, result);
        }
    }
}
