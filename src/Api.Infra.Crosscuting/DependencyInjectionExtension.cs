using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POC.Grpc.Api.Domain.Customers.Interfaces.Repositories;
using POC.Grpc.Api.Infra.Data.Repositories;

namespace POC.Grpc.Api.Infra.Crosscuting
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddRepositories();
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}