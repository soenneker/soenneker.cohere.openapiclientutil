[![](https://img.shields.io/nuget/v/soenneker.cohere.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.cohere.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cohere.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.cohere.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.cohere.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.cohere.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cohere.openapiclientutil/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.cohere.openapiclientutil/actions/workflows/codeql.yml)

# Soenneker.Cohere.OpenApiClientUtil

Provides a cached, bearer-authenticated `CohereOpenApiClient` with configurable base URL and authorization formatting.

## Installation

```bash
dotnet add package Soenneker.Cohere.OpenApiClientUtil
```

## Configuration

```json
{
  "Cohere": {
    "ApiKey": "your-api-key",
    "ClientBaseUrl": "https://api.cohere.com",
    "AuthHeaderName": "Authorization",
    "AuthHeaderValueTemplate": "Bearer {token}"
  }
}
```

`ApiKey` is required. The other values show their defaults. Keep the key in a secret provider, and override the base URL or header formatting only when the target Cohere-compatible endpoint requires it.

## Registration

```csharp
using Soenneker.Cohere.OpenApiClientUtil.Registrars;

services.AddCohereOpenApiClientUtilAsScoped();
```

Singleton registration is available with `AddCohereOpenApiClientUtilAsSingleton()`.

The scoped utility borrows a singleton Cohere HTTP provider. Disposing the utility clears its generated-client cache but leaves the shared HTTP client alive until the provider's container lifetime ends.

## Usage

```csharp
using Soenneker.Cohere.OpenApiClientUtil.Abstract;
using Soenneker.Cohere.OpenApiClient;
using Soenneker.Cohere.OpenApiClient.Models;

CohereOpenApiClient client = await clientUtil.Get(cancellationToken);

var request = new Chatv2Request
{
    Model = modelName,
    Messages = messages
};

Chatv2200Response? response =
    await client.V2.Chat.PostAsync(request, cancellationToken: cancellationToken);
```

The generated request and response models are exposed directly. Validate model-specific inputs, handle nullable response bodies and Kiota API exceptions, and avoid logging prompts, documents, embeddings, or generated output when they may contain sensitive data.

Do not dispose the borrowed `HttpClient` or mutate the shared request adapter. Dispose this utility through dependency injection according to its selected lifetime.
