namespace Commerce.APIs.Extensions
{
    public static class SwaggerSevicesExtensions
    {
        public static IServiceCollection AddSwaggerSevices(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            return services;
        }
        public static WebApplication AddSwaggerServiceMiddlewares(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }
    }
}
