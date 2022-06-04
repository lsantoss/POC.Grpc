using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POC.Grpc.App.Domain.Customers.Interfaces.Services.Grpc;
using POC.Grpc.App.Domain.Customers.Interfaces.Services.Rest;
using POC.Grpc.App.Infra.Service.Services.Grpc;
using POC.Grpc.App.Infra.Service.Services.Rest;
using System;
using static POC.Grpc.Lib.Proto.Customers.Services.CustomerService;

namespace POC.Grpc.App.Infra.Crosscuting
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddServices();
            services.AddHttpClients(configuration);
            services.AddGrpcClients(configuration);
            return services;
        }

        private static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerGrpcService, CustomerGrpcService>();
            return services;
        }

        private static IServiceCollection AddHttpClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient<ICustomerRestService, CustomerRestService>(client =>
            {
                client.BaseAddress = new Uri(configuration["BaseUrlRest"]);
            });

            return services;
        }

        private static IServiceCollection AddGrpcClients(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGrpcClient<CustomerServiceClient>(client =>
            {
                client.Address = new Uri(configuration["UrlGrpc"]);
            });

            return services;
        }
    }
}