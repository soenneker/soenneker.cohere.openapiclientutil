using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Cohere.HttpClients.Abstract;
using Soenneker.Cohere.OpenApiClientUtil.Abstract;
using Soenneker.Cohere.OpenApiClient;
using Soenneker.Kiota.GenericAuthenticationProvider;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Cohere.OpenApiClientUtil;

///<inheritdoc cref="ICohereOpenApiClientUtil"/>
public sealed class CohereOpenApiClientUtil : ICohereOpenApiClientUtil
{
    private readonly AsyncSingleton<CohereOpenApiClient> _client;

    public CohereOpenApiClientUtil(ICohereOpenApiHttpClient httpClientUtil, IConfiguration configuration)
    {
        _client = new AsyncSingleton<CohereOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token).NoSync();

            var apiKey = configuration.GetValueStrict<string>("Cohere:ApiKey");
            string authHeaderValueTemplate = configuration["Cohere:AuthHeaderValueTemplate"] ?? "{token}";
            string authHeaderValue = authHeaderValueTemplate.Replace("{token}", apiKey, StringComparison.Ordinal);

            var requestAdapter = new HttpClientRequestAdapter(new GenericAuthenticationProvider(headerValue: authHeaderValue), httpClient: httpClient);

            return new CohereOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<CohereOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}
