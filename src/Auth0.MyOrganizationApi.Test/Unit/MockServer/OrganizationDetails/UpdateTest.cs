using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using Auth0.MyOrganizationApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.OrganizationDetails;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class UpdateTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string requestJson = """
            {}
            """;

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
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/details")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.OrganizationDetails.UpdateAsync(
            new OrgDetails
            {
                Name = null,
                DisplayName = null,
                Branding = null,
                ThirdPartyClientAccess = null,
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string requestJson = """
            {
              "name": "testorg",
              "display_name": "Test Organization",
              "branding": {
                "logo_url": "https://example.com/logo.png",
                "colors": {
                  "primary": "#000000",
                  "page_background": "#FFFFFF"
                }
              }
            }
            """;

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
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/details")
                    .UsingPatch()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.OrganizationDetails.UpdateAsync(
            new OrgDetails
            {
                Name = "testorg",
                DisplayName = "Test Organization",
                Branding = new OrgBranding
                {
                    LogoUrl = "https://example.com/logo.png",
                    Colors = new OrgBrandingColors
                    {
                        Primary = "#000000",
                        PageBackground = "#FFFFFF",
                    },
                },
            }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
