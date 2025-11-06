using Serilog;

namespace HappyPayment.Presentation.DependencyInjections
{
    public class LoggerDependencies
    {
        public static IServiceCollection AddDependencies(IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(configuration)
                        .CreateLogger();

            return services;
        }
    }
}
