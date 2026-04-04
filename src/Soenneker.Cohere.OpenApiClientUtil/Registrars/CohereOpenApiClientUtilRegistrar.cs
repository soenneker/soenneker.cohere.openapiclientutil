using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Cohere.HttpClients.Registrars;
using Soenneker.Cohere.OpenApiClientUtil.Abstract;

namespace Soenneker.Cohere.OpenApiClientUtil.Registrars;

/// <summary>
/// Registers the OpenAPI client utility for dependency injection.
/// </summary>
public static class CohereOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="CohereOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddCohereOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddCohereOpenApiHttpClientAsSingleton()
                .TryAddSingleton<ICohereOpenApiClientUtil, CohereOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="CohereOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddCohereOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddCohereOpenApiHttpClientAsSingleton()
                .TryAddScoped<ICohereOpenApiClientUtil, CohereOpenApiClientUtil>();

        return services;
    }
}
