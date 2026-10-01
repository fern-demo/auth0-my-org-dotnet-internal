using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record AllowedApi : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Unique identifier for the API. This value will be used as the audience parameter on authorization calls.
    /// </summary>
    [JsonPropertyName("identifier")]
    public required string Identifier { get; set; }

    /// <summary>
    /// A friendly name for the API. The following characters are not allowed &lt; &gt;
    /// </summary>
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    /// <summary>
    /// The scopes available for this API.
    /// </summary>
    [JsonPropertyName("scopes")]
    public IEnumerable<AllowedApiScope> Scopes { get; set; } = new List<AllowedApiScope>();

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
