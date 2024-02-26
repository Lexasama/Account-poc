using System.Runtime.InteropServices.JavaScript;
using Account.Api.Abstractions;
using Account.Application.Account.Commands;
using Account.Contract.Account;
using Account.Domain.Core.Primitives.Maybe;
using Account.Domain.Errors;
using EventReminder.Domain.Core.Primitives;
using EventReminder.Domain.Core.Primitives.Result;
using MediatR;
using Swashbuckle.AspNetCore.Annotations;

namespace Account.Api.Features.Account;

public class CreateAccountEndpoint(IMediator mediator) : BaseEndpoint(mediator), IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/account", async (CreateAccountRequest createAccountRequest) =>
        {
           return await Result
                .Create(createAccountRequest, DomainErrors.General.UnProcessableRequest)
                .Map(request => new CreateAccountCommand(request.FirstName, request.LastName, request.Email))
                .Bind(command => Mediator.Send(command))
                .Match(Ok, BadRequest);
        })
        .WithTags("Account")// the name of the route
            .WithMetadata(new SwaggerOperationAttribute("Create an account2", "description2"))
            .WithMetadata(new SwaggerResponseAttribute(500, "Internal server error", typeof(Error)));
    }
}