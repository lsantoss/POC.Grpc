using Microsoft.AspNetCore.Server.Kestrel.Core;
using System.Net;

namespace POC.Grpc.Api.Application.Extensions.WebApplicationBuilderExtensions;

public static class UseKestrelExtension
{
    private const string DEFAULT_HTTP1_PORT = "8090";
    private const string DEFAULT_HTTP2_PORT = "8080";
    private const HttpProtocols HTTP1_PORT_PROTOCOLS = HttpProtocols.Http1AndHttp2;
    private const HttpProtocols HTTP2_PORT_PROTOCOLS = HttpProtocols.Http2;
    private const string INVALID_HTTP1_PORT_MESSAGE = "Invalid HTTP1 port";
    private const string INVALID_HTTP2_PORT_MESSAGE = "Invalid HTTP2 port";

    public static WebApplicationBuilder UseKestrel(this WebApplicationBuilder builder)
    {
        var http1Port = builder.Configuration["HTTP1_PORT"];
        var http2Port = builder.Configuration["HTTP2_PORT"];

        http1Port ??= DEFAULT_HTTP1_PORT;
        http2Port ??= DEFAULT_HTTP2_PORT;

        if (!int.TryParse(http1Port, out var http1PortInt))
            throw new FormatException(INVALID_HTTP1_PORT_MESSAGE);

        if (!int.TryParse(http2Port, out var http2PortInt))
            throw new FormatException(INVALID_HTTP2_PORT_MESSAGE);

        builder.WebHost.UseKestrel(options =>
        {
            options.Listen(IPAddress.Any, http1PortInt, listenOptions => { listenOptions.Protocols = HTTP1_PORT_PROTOCOLS; });
            options.Listen(IPAddress.Any, http2PortInt, listenOptions => { listenOptions.Protocols = HTTP2_PORT_PROTOCOLS; });
        });

        return builder;
    }
}