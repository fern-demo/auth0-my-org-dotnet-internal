using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// A single item to render on a page. `type` determines which payload property, if any, is present.
/// </summary>
[Serializable]
public record IdpInstructionsPageContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Key for this content item, unique within the response.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    [JsonPropertyName("type")]
    public required IdpInstructionsPageContentTypeEnum Type { get; set; }

    [Optional]
    [JsonPropertyName("markdown_component")]
    public IdpInstructionsMarkdownComponent? MarkdownComponent { get; set; }

    [Optional]
    [JsonPropertyName("tabs_component")]
    public IdpInstructionsTabsComponent? TabsComponent { get; set; }

    [Optional]
    [JsonPropertyName("okta_configure_connection_component")]
    public IdpInstructionsOktaConfigureConnectionComponent? OktaConfigureConnectionComponent { get; set; }

    [Optional]
    [JsonPropertyName("adfs_configure_connection_component")]
    public IdpInstructionsAdfsConfigureConnectionComponent? AdfsConfigureConnectionComponent { get; set; }

    [Optional]
    [JsonPropertyName("google_apps_configure_connection_component")]
    public IdpInstructionsGoogleAppsConfigureConnectionComponent? GoogleAppsConfigureConnectionComponent { get; set; }

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
