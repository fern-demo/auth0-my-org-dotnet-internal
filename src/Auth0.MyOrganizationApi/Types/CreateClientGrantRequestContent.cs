using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record CreateClientGrantRequestContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// ID of the client.
    /// </summary>
    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    /// <summary>
    /// The audience (API identifier) of this client grant.
    /// </summary>
    [JsonPropertyName("audience")]
    public required string Audience { get; set; }

    /// <summary>
    /// Scopes allowed for this client grant.
    /// </summary>
    [JsonPropertyName("scope")]
    public IEnumerable<string> Scope { get; set; } = new List<string>();

    [Optional]
    [JsonPropertyName("subject_type")]
    public SubjectTypeEnum? SubjectType { get; set; }

    [JsonIgnore]
    public ReadOnlyAdditionalProperties AdditionalProperties { get; private set; } = new();

    void IJsonOnDeserialized.OnDeserialized() =>
        AdditionalProperties.CopyFromExtensionData(_extensionData);

    /// <inheritdoc />
    public override string ToString()
    {
        return JsonUtils.Serialize(this);
    }
}
