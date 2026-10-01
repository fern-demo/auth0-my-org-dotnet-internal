using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// Payload for the `okta_configure_connection_component` content type.
/// </summary>
[Serializable]
public record IdpInstructionsOktaConfigureConnectionComponent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Link to Okta documentation explaining where to find the Okta domain.
    /// </summary>
    [Optional]
    [JsonPropertyName("find_okta_domain_url")]
    public string? FindOktaDomainUrl { get; set; }

    /// <summary>
    /// Link to Okta documentation explaining where to find the client ID.
    /// </summary>
    [Optional]
    [JsonPropertyName("find_client_id_url")]
    public string? FindClientIdUrl { get; set; }

    /// <summary>
    /// Link to Okta documentation explaining where to find the client secret.
    /// </summary>
    [Optional]
    [JsonPropertyName("find_client_secret_url")]
    public string? FindClientSecretUrl { get; set; }

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
