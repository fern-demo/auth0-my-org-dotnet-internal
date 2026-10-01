using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// A single item to render inside a tab. Shares the shape of `IdpInstructionsPageContent` but restricts `type` so tabs cannot contain further tabs.
/// </summary>
[Serializable]
public record IdpInstructionsTabContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Key for this content item, unique within its tab.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    [JsonPropertyName("type")]
    public required IdpInstructionsTabContentTypeEnum Type { get; set; }

    [Optional]
    [JsonPropertyName("markdown_component")]
    public IdpInstructionsMarkdownComponent? MarkdownComponent { get; set; }

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
