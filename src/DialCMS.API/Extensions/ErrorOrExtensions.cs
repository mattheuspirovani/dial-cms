using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace DialCMS.API.Extensions;

public static class ErrorOrExtensions
{
    public static IActionResult Problem(this ControllerBase controller, List<Error> errors)
    {
        var firstError = errors.First();

        var statusCode = firstError.Type switch
        {
            ErrorType.Validation => StatusCodes.Status400BadRequest,
            ErrorType.NotFound => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError,
        };

        return controller.Problem(
            detail: firstError.Description,
            statusCode: statusCode,
            title: firstError.Code
        );
    }
}