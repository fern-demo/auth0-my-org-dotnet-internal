using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using Auth0.MyOrganizationApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.Configuration;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "allowed_strategies": [
                "adfs",
                "adfs"
              ],
              "connection_deletion_behavior": "allow",
              "third_party_client_access": {
                "default_value": "allow",
                "allowed_values": [
                  "allow",
                  "allow"
                ]
              }
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/config").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organization.Configuration.GetAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "allowed_strategies": [
                "adfs",
                "pingfederate"
              ],
              "connection_deletion_behavior": "allow",
              "third_party_client_access": {
                "default_value": "allow",
                "allowed_values": [
                  "allow"
                ]
              }
            }
            """;

        Server
            .Given(WireMock.RequestBuilders.Request.Create().WithPath("/config").UsingGet())
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organization.Configuration.GetAsync();
        JsonAssert.AreEqual(response, mockResponse);
    }
}
