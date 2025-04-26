using POC.Grpc.Api.Application.Extensions.ServiceCollectionExtensions;
using POC.Grpc.Api.Application.Extensions.WebApplicationBuilderExtensions;

var builder = WebApplication.CreateBuilder(args);
builder.UseKestrel();
builder.Services.AddSwaggerGen();
builder.Services.AddGrpc();
builder.Services.AddHealthChecks();
builder.Services.AddControllers();

var app = builder.Build();
AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnecryptedSupport", true);
AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", true);
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.MapHealthChecks("v1/HealthCheck");
app.MapGrpcServices();
app.Run();