using Application.Extentions.LogicException;
using FluentValidation;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;
using System.Text.Json;

namespace BaseSample.Middlewares;

public sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        var problemDetails = new ProblemDetails();

        if (exception is UnauthorizedAccessException)
        {

            await ErrorHandlerSetting(StatusCodes.Status401Unauthorized, exception);
            problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Title = "Unauthorized!"
            };
        }

        else if (exception is ValidationException)
        {
            ValidationException validationException = (ValidationException)exception;

            string ErrorMassage = string.Join(" - ", validationException.Errors
                .Select(exception => exception.ErrorMessage));

            await ErrorHandlerSetting(StatusCodes.Status422UnprocessableEntity, exception);
            problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status422UnprocessableEntity,
                Title = ErrorMassage
            };
        }

        else if (exception is LogicException)
        {

            await ErrorHandlerSetting(StatusCodes.Status400BadRequest, exception);
            problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = exception.Message
            };
        }

        else
        {
            await ErrorHandlerSetting(StatusCodes.Status501NotImplemented, exception);

            problemDetails = new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Title = "Server error"
            };
        }

        httpContext.Response.StatusCode = problemDetails.Status.Value;
        httpContext.Response.ContentType = "application/json";
        await httpContext.Response
            .WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private async Task ErrorHandlerSetting(int statusCode, Exception ex)
    {
        _logger.LogError(
            "Error in GlobalExceptionHandler " +
            "at {datetime}, " +
            "with status code {statusCode} " +
            "and exception {exception}"
            , DateTime.Now, statusCode, ex);
    }

    private static JsonSerializerOptions GetOptions()
    {
        return new()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
    }
}


