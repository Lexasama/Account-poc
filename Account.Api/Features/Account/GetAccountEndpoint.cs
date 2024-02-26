using System.Net;
using Account.Api.Abstractions;
using Account.Api.Contracts.Account;
using Account.Api.Extensions;
using Account.Application.Account.Queries.GetAccountById;
using Account.Domain.Core.Primitives.Maybe;
using EventReminder.Domain.Core.Primitives;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Account.Api.Features.Account;

public class GetAccountEndpoint(IMediator mediator) : BaseEndpoint(mediator), IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        var attributes = new SwaggerResponseAttribute[]
        {
            new SwaggerResponseAttribute ((int)HttpStatusCode.NotFound, "The account was not found.",  typeof(Error)),
            new((int)HttpStatusCode.OK, "The account found.", typeof(GetAccountByIdResponse)),
            new((int)HttpStatusCode.Unauthorized, "You are not authorized", typeof(Error))
        };
        app.MapGet("/account/{accountReference:guid}",

                async (Guid accountReference) =>
                {
                    return await Maybe<GetAccountByIdQuery>
                        .From(new GetAccountByIdQuery(accountReference))
                        .Bind(query => Mediator.Send(query))
                        .Match(Ok, NotFound);
                }).WithSwaggerAttribute(attributes)
            .WithTags("Account");
    }
}