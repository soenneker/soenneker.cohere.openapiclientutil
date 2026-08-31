using Soenneker.Cohere.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Cohere.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached, authenticated Cohere OpenAPI client.
/// </summary>
public interface ICohereOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the client owned by this utility instance.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<CohereOpenApiClient> Get(CancellationToken cancellationToken = default);
}
