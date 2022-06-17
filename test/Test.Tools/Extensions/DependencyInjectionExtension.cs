using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using POC.Grpc.Api.Application.Controllers;
using POC.Grpc.Api.Application.Grpc;

namespace POC.Grpc.Test.Tools.Extensions
{
    internal static class DependencyInjectionExtension
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services, IConfiguration configuration = null)
        {
            services.AddControllersApi();
            services.AddGrpcsApi();
            return services;
        }

        private static IServiceCollection AddControllersApi(this IServiceCollection services)
        {
            services.AddScoped<CustomerController>();
            return services;
        }

        private static IServiceCollection AddGrpcsApi(this IServiceCollection services)
        {
            services.AddScoped<CustomerGrpcService>();
            return services;
        }
    }
}