using MediatR;

namespace Account.Application.Core.Abstractions.Messaging;

public interface IQuery<out TResponse> : IRequest<TResponse>;