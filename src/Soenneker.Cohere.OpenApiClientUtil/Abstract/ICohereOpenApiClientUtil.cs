using Soenneker.Cohere.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Cohere.OpenApiClientUtil.Abstract;

/// <summary>
/// Exposes a cached OpenAPI client instance.
/// </summary>
public interface ICohereOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<CohereOpenApiClient> Get(CancellationToken cancellationToken = default);
}
