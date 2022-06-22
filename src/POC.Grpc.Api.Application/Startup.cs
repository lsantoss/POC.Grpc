using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using POC.Grpc.Api.Application.Grpc;
using POC.Grpc.Api.Infra.Crosscuting;
using System;

namespace POC.Grpc.Api.Application
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDependencies(Configuration);

            services.AddGrpc();

            services.AddSwaggerGen(sw =>
            {
                sw.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "POC.GRPC.API",
                    Version = "v1"
                });
            });

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2UnecryptedSupport", true);
            AppContext.SetSwitch("System.Net.Http.SocketsHttpHandler.Http2Support", true);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            if (env.IsDevelopment() || env.IsStaging())
            {
                app.UseSwagger();
                app.UseSwaggerUI(sw =>
                {
                    sw.SwaggerEndpoint("/swagger/v1/swagger.json", "POC.GRPC.API v1");
                    sw.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<CustomerGrpcService>().RequireHost($"*:{Environment.GetEnvironmentVariable("HTTP2_PORT")}");
                endpoints.MapControllers();
            });
        }
    }
}