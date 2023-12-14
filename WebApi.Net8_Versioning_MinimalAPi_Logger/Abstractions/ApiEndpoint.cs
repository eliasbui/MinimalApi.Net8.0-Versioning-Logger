using Asp.Versioning;
using WebApi.Net8_Versioning_MinimalAPi.Contract.Shared;

namespace WebApi.Net8_Versioning_MinimalAPi.Abstractions;

public abstract class ApiEndpoint
{
    protected static IResult HandleFailure(Result result)
    {
        return result switch
        {
            { IsSuccess: true } => throw new InvalidOperationException("Can't handle successful result."),
            IValidationResult validationResult =>
                Results.BadRequest(
                    CreateProblemDetails(
                        "Validation Error", StatusCodes.Status400BadRequest, result.Errors, validationResult.Errors)
                ),
            _ =>
                Results.BadRequest(
                    CreateProblemDetails(
                        "Bad Request",
                        StatusCodes.Status400BadRequest,
                        result.Errors))
        };
    }

    private static ProblemDetails CreateProblemDetails(string title, int statusCode, Error error,
        Error[]? errors = null)
    {
        return new ProblemDetails
        {
            Title = title,
            Type = error.Code,
            Detail = error.Message,
            Status = statusCode,
            Extensions = { { nameof(errors), errors } }
        };
    }
}