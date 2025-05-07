using Commerce.APIs.Extensions;
using Menofia_Portal.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Monofia_Portal.APIs.Extensions;
using Monofia_Portal.APIs.Middleware;
using Monofia_Portal.Infrastructure.Persistence;
using MonofiaPortal.Infrastructure.Services;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerSevices();
builder.Services.AddScoped<IEmailService, EmailService>();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;

builder.Services.AddInfrastructureServices(connectionString);

builder.Logging.AddConsole();

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services
    .AddCors(
        options =>
        {
            options.AddPolicy(
                "AllowAll",
                policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
        });

builder.Logging.ClearProviders();
builder.Logging.AddConsole();



Log.Logger = new LoggerConfiguration()
    .Enrich
    .FromLogContext()
    .WriteTo
    .File("logs/app.log", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Host.UseSerilog();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

using var scope = app.Services.CreateScope();

var services = scope.ServiceProvider;

var loggerFactory = services.GetRequiredService<ILoggerFactory>();

try
{
    var dbContext = services.GetRequiredService<PortalDbContext>();
    await dbContext.Database.MigrateAsync();

    await PortalContextSeed.SeedingAsync(dbContext);
}
catch (Exception ex)
{
    var logger = app.Services.GetRequiredService<ILogger<Program>>();
    logger.LogError(ex, "An Error Occurs When Applying The Migrations");
}


app.UseSwagger();
app.UseSwaggerUI();
app.UseStatusCodePagesWithRedirects("/errors/{0}");
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();
app.Run();
