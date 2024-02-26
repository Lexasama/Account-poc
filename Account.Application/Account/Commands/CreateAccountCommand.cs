using Account.Application.Core.Abstractions.Messaging;
using Account.Contract.Account;
using EventReminder.Domain.Core.Primitives.Result;

namespace Account.Application.Account.Commands;

public class CreateAccountCommand(string firstName, string lastName, string email) : ICommand<Result<AccountId>>
{
    public string Email { get; set; } = email;

    public string LastName { get; set; } = lastName;

    public string FirstName { get; set; } = firstName;
}