using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POC.Grpc.Api.Domain.Customers.Interfaces.Repositories;
using POC.Grpc.Api.Infra.Data.Customers.Repositories;
using POC.Grpc.Api.Infra.Data.DataContexts;
using POC.Grpc.Api.Infra.Data.DataContexts.Interfaces;
using POC.Grpc.Api.Infra.Settings;

namespace POC.Grpc.Api.Application.Extensions
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration = null)
        {
            var appSettings = new AppSettings();
            configuration.Bind(appSettings);

            services.AddAppSettings(appSettings);
            services.AddDataContexts();
            services.AddRepositories();
            return services;
        }

        public static IServiceCollection AddAppSettings(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddSingleton(appSettings);
            return services;
        }

        private static IServiceCollection AddDataContexts(this IServiceCollection services)
        {
            services.AddScoped<IDataContext, DataContext>();
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            return services;
        }
    }
}