namespace HappyPayment.Presentation.DependencyInjections
{
    public class MediatRDependencies
    {
        public static IServiceCollection AddDependencies(IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

            return services;
        }
    }
}
