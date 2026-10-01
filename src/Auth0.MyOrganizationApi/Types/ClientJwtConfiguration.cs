using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record ClientJwtConfiguration : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [Optional]
    [JsonPropertyName("alg")]
    public ClientJwtAlgEnum? Alg { get; set; }

    /// <summary>
    /// Number of seconds the JWT will be valid
    /// </summary>
    [Optional]
    [JsonPropertyName("lifetime_in_seconds")]
    public double? LifetimeInSeconds { get; set; }

    /// <summary>
    /// Whether the client secret is base64 encoded
    /// </summary>
    [Optional]
    [JsonPropertyName("secret_encoded")]
    public bool? SecretEncoded { get; set; }

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
