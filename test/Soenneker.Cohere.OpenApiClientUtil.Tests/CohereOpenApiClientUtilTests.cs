using Soenneker.Cohere.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Cohere.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class CohereOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly ICohereOpenApiClientUtil _openapiclientutil;

    public CohereOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<ICohereOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
