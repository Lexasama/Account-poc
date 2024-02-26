using Swashbuckle.AspNetCore.Annotations;

namespace Account.Api.Extensions;

public static class SwaggerAttributeExtensions
{
    public static IEndpointConventionBuilder WithSwaggerAttribute(
        this IEndpointConventionBuilder endpointBuilder,
     SwaggerResponseAttribute swaggerResponseAttribute)
    {
        endpointBuilder.WithMetadata(swaggerResponseAttribute);
        return endpointBuilder;
    }

    public static IEndpointConventionBuilder WithSwaggerAttribute(
        this IEndpointConventionBuilder endpointBuilder,
        IEnumerable<SwaggerResponseAttribute> swaggerResponseAttributes)
    {
        foreach (var attribute in swaggerResponseAttributes)
        {
            endpointBuilder.WithMetadata(attribute);
        }

        return endpointBuilder;
    }
}