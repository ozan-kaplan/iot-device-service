using IoTDeviceService.Application.Interfaces.Repositories;
using IoTDeviceService.Infrastructure.Persistence.Context;
using IoTDeviceService.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();




builder.Services.AddControllers();

builder.Services.AddDbContext<DeviceDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IDeviceRepository, DeviceRepository>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();

