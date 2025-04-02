using RefaelServer.Interfaces;
using RefaelServer.Services;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IOrderService, OrderService>();
builder.Host.UseSerilog(((context, services) =>
{
    var config = new ConfigurationBuilder()
       .AddEnvironmentVariables()
       .Build();
    var template = "{Timestamp:yyyy-MM-dd HH:mm:ss}  {Level:u4}  {Message:lj}{NewLine}{Exception}";
    services
        .Enrich.FromLogContext()
        .WriteTo.Console(outputTemplate: template)
        .WriteTo.Debug(outputTemplate: template)
        .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
        .ReadFrom.Configuration(context.Configuration);

    var logFolder = context.Configuration["LOG_FOLDER"] ?? "Log";
    var logFile = Path.Combine(logFolder, "RefaelServer.log");
    services.WriteTo.File(logFile, outputTemplate: template, rollingInterval: RollingInterval.Day, retainedFileCountLimit: null, rollOnFileSizeLimit: true, fileSizeLimitBytes: 10000000);
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseCors("AllowAngularApp");
app.UseAuthorization();

app.MapControllers();

app.Run();
