using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POC.Grpc.App.Domain.Customers.Interfaces.Services.Grpc;
using POC.Grpc.App.Domain.Customers.Interfaces.Services.Rest;
using POC.Grpc.App.Infra.Service.Services.Grpc;
using POC.Grpc.App.Infra.Service.Services.Rest;
using POC.Grpc.App.Infra.Settings;
using System;
using static POC.Grpc.Lib.Contract.Proto.Customers.Services.CustomerService;

namespace POC.Grpc.App.Infra.Crosscutting
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration = null)
        {
            var appSettings = new AppSettings();
            configuration.Bind(appSettings);

            services.AddAppSettings(appSettings);
            services.AddServices();
            services.AddHttpClients(appSettings);
            services.AddGrpcClients(appSettings);
            return services;
        }

        public static IServiceCollection AddAppSettings(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddSingleton(appSettings);
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerGrpcService, CustomerGrpcService>();
            return services;
        }

        private static IServiceCollection AddHttpClients(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddHttpClient<ICustomerRestService, CustomerRestService>(client => { client.BaseAddress = new Uri(appSettings.BaseUrlRest); });
            return services;
        }

        private static IServiceCollection AddGrpcClients(this IServiceCollection services, AppSettings appSettings)
        {
            services.AddGrpcClient<CustomerServiceClient>(client => { client.Address = new Uri(appSettings.UrlGrpc); });
            return services;
        }
    }
}