using System.Net;
using Magic.DTO.Interfaces.Providers;
using Magic.DTO.Model;
using Magic.Service.Validation;

namespace Magic.App.Middleware;

public class ExceptionMiddleware
{
    private readonly ILogger<ExceptionMiddleware> _logger;
    private readonly RequestDelegate _next;
    private readonly Dictionary<Type, ValidationOptions> _validationOptions;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger,
        IValidationOptionsProvider validationOptionsProvider)
    {
        _next = next;
        _logger = logger;
        _validationOptions = validationOptionsProvider.GetOptions();
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";
        var exceptionType = exception.GetType();

        var containsKnownException = _validationOptions.TryGetValue(exceptionType, out var option);
        context.Response.StatusCode =
            containsKnownException ? option.StatusCode : (int)HttpStatusCode.InternalServerError;
        await context.Response.WriteAsync(new ErrorDetails
        {
            StatusCode = context.Response.StatusCode,
            Message = exception.Message
        }.ToString());
    }
}