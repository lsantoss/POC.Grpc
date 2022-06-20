using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using System;
using System.Net;

namespace POC.Grpc.Api.Application
{
    public class Program
    {
        public static void Main(string[] args) => CreateHostBuilder(args).Build().Run();

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureKestrel(options =>
                {
                    var http1Port = int.Parse(Environment.GetEnvironmentVariable("HTTP1_PORT") ?? "80");
                    var http2Port = int.Parse(Environment.GetEnvironmentVariable("HTTP2_PORT") ?? "8080");

                    options.Listen(IPAddress.Any, http1Port, listenOptions =>
                    {
                        listenOptions.Protocols = HttpProtocols.Http1AndHttp2;
                    });

                    options.Listen(IPAddress.Any, http2Port, listenOptions =>
                    {
                        listenOptions.Protocols = HttpProtocols.Http2;
                    });
                });

                var customEnvName = Environment.GetEnvironmentVariable("RUNTIME_ENVIRONMENT_NAME");

                var env = customEnvName switch
                {
                    "local" => "Development",
                    "dev" => "Development",
                    "qa" => "Staging",
                    _ => "Production"
                };

                webBuilder.UseEnvironment(env);
                webBuilder.UseStartup<Startup>();
            });
        }
    }
}