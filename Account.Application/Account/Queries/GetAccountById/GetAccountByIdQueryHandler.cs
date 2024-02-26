using Account.Api.Contracts.Account;
using Account.Application.Core.Abstractions.Messaging;
using Account.Domain.Core.Primitives.Maybe;

namespace Account.Application.Account.Queries.GetAccountById;

public class GetAccountByIdQueryHandler : IQueryHandler<GetAccountByIdQuery, Maybe<GetAccountByIdResponse>>
{
    public async Task<Maybe<GetAccountByIdResponse>> Handle(GetAccountByIdQuery request, CancellationToken cancellationToken)
    {
        
        if(request.AccountReference ==  Guid.Empty)
        {
            return Maybe<GetAccountByIdResponse>.None;
        }
        var response = new GetAccountByIdResponse
        {
            Id = Guid.NewGuid(),
            Name = "Lexa"
        };
        return response;
    }
}
