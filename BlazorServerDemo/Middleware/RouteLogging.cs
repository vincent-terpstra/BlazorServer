using DataAccess.Services;

namespace BlazorServerDemo.Middleware;

public class RouteLogging : IMiddleware
{
    private readonly ILogger<RouteLogging> _logger;

    public RouteLogging(ILogger<RouteLogging> logger)
    {
        _logger = logger;
    }
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        var path = context.Request.Path;
        _logger.LogInformation("{Path}", path);
        await next(context);
    }
}