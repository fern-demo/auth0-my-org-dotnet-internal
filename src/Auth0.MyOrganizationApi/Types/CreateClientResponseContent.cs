using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record CreateClientResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    [JsonPropertyName("client_id")]
    public required string ClientId { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [Optional]
    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("app_type")]
    public required ClientAppTypeEnum AppType { get; set; }

    [Optional]
    [JsonPropertyName("token_endpoint_auth_method")]
    public ClientTokenEndpointAuthMethodEnum? TokenEndpointAuthMethod { get; set; }

    [Optional]
    [JsonPropertyName("grant_types")]
    public IEnumerable<ClientGrantTypeEnum>? GrantTypes { get; set; }

    [Optional]
    [JsonPropertyName("jwt_configuration")]
    public ClientJwtConfiguration? JwtConfiguration { get; set; }

    /// <summary>
    /// Timestamp when the client was created
    /// </summary>
    [JsonPropertyName("created_at")]
    public required DateTime CreatedAt { get; set; }

    /// <summary>
    /// Timestamp when the client was last updated
    /// </summary>
    [Optional]
    [JsonPropertyName("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    /// <summary>
    /// Client secret (ONLY returned on creation, never again)
    /// </summary>
    [JsonPropertyName("client_secret")]
    public required string ClientSecret { get; set; }

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
