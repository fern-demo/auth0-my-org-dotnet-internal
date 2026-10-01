using Auth0.MyOrganizationApi.Organization;
using Auth0.MyOrganizationApi.Test.Unit.MockServer;
using Auth0.MyOrganizationApi.Test.Utils;
using NUnit.Framework;

namespace Auth0.MyOrganizationApi.Test.Unit.MockServer.Organization.Members;

[TestFixture]
[Parallelizable(ParallelScope.Self)]
public class GetTest : BaseMockServerTest
{
    [NUnit.Framework.Test]
    public async Task MockServerTest_1()
    {
        const string mockResponse = """
            {
              "email": "email",
              "name": "name",
              "nickname": "nickname",
              "given_name": "given_name",
              "family_name": "family_name"
            }
            """;

        Server
            .Given(
                WireMock.RequestBuilders.Request.Create().WithPath("/members/user_id").UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organization.Members.GetAsync(
            "user_id",
            new GetOrganizationMemberRequestParameters()
        );
        JsonAssert.AreEqual(response, mockResponse);
    }

    [NUnit.Framework.Test]
    public async Task MockServerTest_2()
    {
        const string mockResponse = """
            {
              "email": "roadrunner@acme.com",
              "name": "roadrunner",
              "nickname": "beepbeep",
              "given_name": "Road",
              "family_name": "Runner"
            }
            """;

        Server
            .Given(
                WireMock
                    .RequestBuilders.Request.Create()
                    .WithPath("/members/user_id")
                    .WithParam("fields", "fields")
                    .UsingGet()
            )
            .RespondWith(
                WireMock
                    .ResponseBuilders.Response.Create()
                    .WithStatusCode(200)
                    .WithBody(mockResponse)
            );

        var response = await Client.Organization.Members.GetAsync(
            "user_id",
            new GetOrganizationMemberRequestParameters { Fields = "fields", IncludeFields = true }
        );
        JsonAssert.AreEqual(response, mockResponse);
    }
}
