using EventReminder.Domain.Core.Primitives;

namespace Account.Domain.Errors;

public static class DomainErrors
{
    public static class General
    {
        public static Error UnProcessableRequest => new(
            "General.UnProcessableRequest",
            "The server could not process the request.");

        public static Error ServerError => new("General.ServerError", "The server encountered an unrecoverable error.");
    }
}