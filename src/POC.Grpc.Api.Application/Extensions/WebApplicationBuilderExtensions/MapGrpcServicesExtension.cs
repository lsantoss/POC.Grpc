using POC.Grpc.Api.Application.Grpc.Services;

namespace POC.Grpc.Api.Application.Extensions.WebApplicationBuilderExtensions;

public static class MapGrpcServicesExtension
{
    public static WebApplication MapGrpcServices(this WebApplication app)
    {
        app.MapGrpcService<CustomerGrpcService>();
        return app;
    }
}