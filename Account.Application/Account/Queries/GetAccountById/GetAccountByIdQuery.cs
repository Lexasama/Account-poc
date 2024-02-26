using Account.Api.Contracts.Account;
using Account.Application.Core.Abstractions.Messaging;
using Account.Domain.Core.Primitives.Maybe;

namespace Account.Application.Account.Queries.GetAccountById;

public record GetAccountByIdQuery(Guid AccountReference) : IQuery<Maybe<GetAccountByIdResponse>>;