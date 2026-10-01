using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using Auth0.MyOrganizationApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.OrganizationDetails;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "name": "x",
              "display_name": "x",
              "branding": {
                "logo_url": "logo_url",
                "colors": {
                  "primary": "primary",
                  "page_background": "page_background"
                }
              },
              "third_party_client_access": "allow"
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/details").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.OrganizationDetails.GetAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "name": "testorg",
              "display_name": "Test Organization",
              "branding": {
                "logo_url": "https://example.com/logo.png",
                "colors": {
                  "primary": "#000000",
                  "page_background": "#FFFFFF"
                }
              },
              "third_party_client_access": "allow"
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/details").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.OrganizationDetails.GetAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
