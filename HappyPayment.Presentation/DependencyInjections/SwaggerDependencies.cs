using OpenTelemetry.Metrics;

namespace HappyPayment.Presentation.DependencyInjections
{
    public class SwaggerDependencies
    {
        public static IServiceCollection AddDependencies(IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
