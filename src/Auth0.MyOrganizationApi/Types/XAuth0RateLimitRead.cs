using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// Rate limit information for read operations
/// </summary>
[Serializable]
public record XAuth0RateLimitRead : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("limit_category")]
    public required XAuth0RateLimitReadLimitCategory LimitCategory { get; set; }

    [JsonPropertyName("friendly_name")]
    public required XAuth0RateLimitReadFriendlyName FriendlyName { get; set; }

    [JsonPropertyName("limit_type")]
    public required XAuth0RateLimitReadLimitType LimitType { get; set; }

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
