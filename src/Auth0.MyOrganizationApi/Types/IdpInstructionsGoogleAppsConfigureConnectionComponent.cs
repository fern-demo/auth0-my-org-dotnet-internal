using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// Payload for the `google_apps_configure_connection_component` content type.
/// </summary>
[Serializable]
public record IdpInstructionsGoogleAppsConfigureConnectionComponent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Link to Google Workspace documentation explaining where to find the Google Workspace domain.
    /// </summary>
    [Optional]
    [JsonPropertyName("find_google_workspace_domain_url")]
    public string? FindGoogleWorkspaceDomainUrl { get; set; }

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
