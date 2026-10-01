using Auth0.MyOrganizationApi;
using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.Members.Roles;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class AssignTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public void MockServerTest_1()
    {
        const string requestJson = """
            {
              "role_ids": [
                "role_ids",
                "role_ids"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/members/user_id/roles")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Organization.Members.Roles.AssignAsync(
                "user_id",
                new OrganizationMemberRolesChangeRequestContent
                {
                    RoleIds = new List<string>() { "role_ids", "role_ids" },
                }
            )
        );
    }

    [NUnit.Framework.Test]
    public void MockServerTest_2()
    {
        const string requestJson = """
            {
              "role_ids": [
                "rol_SO2j0sFo9NFa3F9w"
              ]
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/members/user_id/roles")
                    .UsingPost()
                    .WithBodyAsJson(requestJson)
            )
            .RespondWith(WireMock.ResponseBuilders.Response.Create().WithStatusCode(200));

        Assert.DoesNotThrowAsync(async () =>
            await Client.Organization.Members.Roles.AssignAsync(
                "user_id",
                new OrganizationMemberRolesChangeRequestContent
                {
                    RoleIds = new List<string>() { "rol_SO2j0sFo9NFa3F9w" },
                }
            )
        );
    }
}
