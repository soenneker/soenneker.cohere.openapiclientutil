using Soenneker.Cohere.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Cohere.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class CohereOpenApiClientUtilTests : HostedUnitTest
{
    private readonly ICohereOpenApiClientUtil _openapiclientutil;

    public CohereOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<ICohereOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
