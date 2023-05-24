var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IDeliveryFeeService,DeliveryFeeService>();
builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();

app.Run();