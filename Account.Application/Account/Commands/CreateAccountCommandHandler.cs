using Account.Application.Core.Abstractions.Messaging;
using Account.Contract.Account;
using EventReminder.Domain.Core.Primitives;
using EventReminder.Domain.Core.Primitives.Result;

namespace Account.Application.Account.Commands;

internal sealed class CreateAccountCommandHandler : ICommandHandler<CreateAccountCommand, Result<AccountId>>
{
    public async Task<Result<AccountId>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        if (request.FirstName.ToUpper().Equals("STRING"))
        {
            return Result.Failure<AccountId>(new Error("code", "message"));
        }
        return Result.Success(new AccountId(Guid.NewGuid()));
    }
}