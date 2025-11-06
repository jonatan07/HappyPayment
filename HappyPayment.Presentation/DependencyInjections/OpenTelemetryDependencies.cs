using OpenTelemetry.Metrics;
using OpenTelemetry.Resources;
using OpenTelemetry.Trace;

namespace HappyPayment.Presentation.DependencyInjections
{
    public class OpenTelemetryDependencies
    {
        public static IServiceCollection AddDependencies(IServiceCollection services, IConfiguration configuration)
        {
            var serviceName = configuration["serviceName"] ?? "Payment API";
            var serviceVersion = configuration["serviceName"];
            var logPath = configuration["logPath"] ?? "logs/HappyPayment.log";
            var zipkinHost = configuration["zipkinHost"];

            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddOpenTelemetry()
                .WithTracing(tracerProviderBuilder =>
                {
                    tracerProviderBuilder
                        .SetResourceBuilder(ResourceBuilder.CreateDefault()
                        .AddService(serviceName: serviceName, serviceVersion: serviceVersion))
                        .AddAspNetCoreInstrumentation()
                        .AddHttpClientInstrumentation()
                        .AddSource(configuration["serviceName"] ?? "HappyPayment")
                        .AddZipkinExporter(zipkinOptions =>
                        {
                            zipkinOptions.Endpoint = new Uri($"{zipkinHost}/api/v2/spans"); // Zipkin local por defecto
                        });
                })
                .WithMetrics(metrics =>
                {
                    metrics
                       .AddAspNetCoreInstrumentation()
                       .AddHttpClientInstrumentation()
                       .AddPrometheusExporter();
                });
            return services;
        }
    }
}
