using Account.Api.Contracts;
using EventReminder.Domain.Core.Primitives;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Account.Api;

public class BaseEndpoint(IMediator mediator) : ControllerBase
{
    protected IMediator Mediator { get; } = mediator;


    protected IActionResult BadRequest(Error error) => BadRequest(new ApiErrorResponse(new[] { error }));

    /// <summary>
    /// Creates an <see cref="OkObjectResult"/> that produces a <see cref="StatusCodes.Status200OK"/>.
    /// </summary>
    /// <returns>The created <see cref="OkObjectResult"/> for the response.</returns>
    /// <returns></returns>
    protected new IActionResult Ok(object value) => base.Ok(value);
    protected new IActionResult Created(string? uri, object value) => base.Created(uri, value);

    /// <summary>
    /// Creates an <see cref="NotFoundResult"/> that produces a <see cref="StatusCodes.Status404NotFound"/>.
    /// </summary>
    /// <returns>The created <see cref="NotFoundResult"/> for the response.</returns>
    protected new IActionResult NotFound() => base.NotFound();
}