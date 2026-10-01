using Auth0.MyOrganizationApi.Organization;
using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using Auth0.MyOrganizationApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.Invitations;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "inviter": {
                "name": "x"
              },
              "invitee": {
                "email": "x"
              },
              "created_at": "2024-01-15T09:30:00.000Z",
              "expires_at": "2024-01-15T09:30:00.000Z",
              "invitation_url": "invitation_url",
              "ticket_id": "ticket_id"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/member-invitations/invitation_id")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organization.Invitations.GetAsync(
            "invitation_id",
            new GetMemberInvitationRequestParameters()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "inviter": {
                "name": "Allison the Admin"
              },
              "invitee": {
                "email": "user@example.com"
              },
              "created_at": "2025-04-11T20:11:45.000Z",
              "expires_at": "2025-04-11T20:11:45.000Z",
              "invitation_url": "https://example.auth0.com/login?invitation=uinv_12345678abcdefgh&organization=org_12345678abcdefgh",
              "ticket_id": "1asdfasd23usjdef"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/member-invitations/invitation_id")
                    .WithParam("fields", "fields")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organization.Invitations.GetAsync(
            "invitation_id",
            new GetMemberInvitationRequestParameters { Fields = "fields", IncludeFields = true }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
