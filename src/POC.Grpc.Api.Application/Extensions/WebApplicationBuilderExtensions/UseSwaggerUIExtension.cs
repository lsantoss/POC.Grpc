namespace POC.Grpc.Api.Application.Extensions.WebApplicationBuilderExtensions;

public static class UseSwaggerUIExtension
{
    public static WebApplication UseSwaggerUI(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "POC.Grpc.Api.Application");
            c.RoutePrefix = string.Empty;
        });
        return app;
    }
}