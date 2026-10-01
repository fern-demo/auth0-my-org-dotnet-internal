using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using Auth0.MyOrganizationApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.IdentityProviders.Provisioning;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "created_at": "2024-01-15T09:30:00.000Z",
              "updated_on": "2024-01-15T09:30:00.000Z",
              "strategy": "adfs",
              "method": "none",
              "attributes": [
                {
                  "provisioning_field": "provisioning_field",
                  "user_attribute": "user_attribute",
                  "description": "description",
                  "label": "label",
                  "is_required": true,
                  "is_extra": true,
                  "is_missing": true
                },
                {
                  "provisioning_field": "provisioning_field",
                  "user_attribute": "user_attribute",
                  "description": "description",
                  "label": "label",
                  "is_required": true,
                  "is_extra": true,
                  "is_missing": true
                }
              ],
              "user_id_attribute": "user_id_attribute"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/identity-providers/idp_id/provisioning")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organization.IdentityProviders.Provisioning.GetAsync("idp_id");
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "strategy": "okta",
              "method": "scim",
              "attributes": [
                {
                  "user_attribute": "preferred_username",
                  "description": "Preferred Username",
                  "label": "Preferred username",
                  "is_required": true,
                  "is_extra": false,
                  "is_missing": false,
                  "provisioning_field": "userName"
                },
                {
                  "user_attribute": "blocked",
                  "description": "description",
                  "label": "label",
                  "is_required": true,
                  "is_extra": false,
                  "is_missing": false,
                  "provisioning_field": "active"
                }
              ],
              "user_id_attribute": "externalId",
              "created_at": "2025-05-15T23:32:52.000Z",
              "updated_on": "2025-05-15T23:32:52.000Z"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/identity-providers/idp_id/provisioning")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organization.IdentityProviders.Provisioning.GetAsync("idp_id");
        JsonAssert.AreEqual(response, mockResponse);
    }
}
