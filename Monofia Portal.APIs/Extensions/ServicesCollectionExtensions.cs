using Menofia_Portal.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Monofia_Portal.Infrastructure.Persistence;
using Monofia_Portal.Infrastructure.Persistence.Repositories;
using Monofia_Portal.Services.Helpers;

namespace Monofia_Portal.APIs.Extensions
{
    public static class ServicesCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, string connectionString)
        {
            // Register DbContext
            services.AddDbContext<PortalDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>)); // Register Generic Repository

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
