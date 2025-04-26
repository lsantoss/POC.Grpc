using Microsoft.OpenApi.Models;

namespace POC.Grpc.Api.Application.Extensions.ServiceCollectionExtensions;

public static class AddSwaggerGenExtension
{
    public static IServiceCollection AddSwaggerGen(this IServiceCollection services)
    {
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "POC.Grpc.Api.Application"
            });
        });

        return services;
    }
}