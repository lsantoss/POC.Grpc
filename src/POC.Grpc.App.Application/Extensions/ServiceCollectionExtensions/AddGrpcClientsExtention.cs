using static POC.Grpc.Client.Lib.Protos.Customers.Services.CustomerService;

namespace POC.Grpc.App.Application.Extensions.ServiceCollectionExtensions;

public static class AddGrpcClientsExtention
{
    public static IServiceCollection AddGrpcClients(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddGrpcClient<CustomerServiceClient>(client =>
        {
            client.Address = new Uri(configuration["UrlGrpc"]);
        });

        return services;
    }
}