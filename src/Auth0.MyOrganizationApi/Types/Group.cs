using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record Group : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The unique identifier of the group.
    /// </summary>
    [JsonAccess(JsonAccessType.ReadOnly)]
    [JsonPropertyName("id")]
    public string Id { get; set; }

    /// <summary>
    /// The name of the group.
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The external identifier of the group as provided by the connection.
    /// </summary>
    [Optional]
    [JsonPropertyName("external_id")]
    public string? ExternalId { get; set; }

    /// <summary>
    /// The ID of the connection this group belongs to.
    /// </summary>
    [JsonPropertyName("connection_id")]
    public required string ConnectionId { get; set; }

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
