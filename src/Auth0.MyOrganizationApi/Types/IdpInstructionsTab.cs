using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// A single tab within a `tabs_component`.
/// </summary>
[Serializable]
public record IdpInstructionsTab : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The user-readable label for the tab, localized to the requested locale.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    /// <summary>
    /// The content items to render inside the tab, in order.
    /// </summary>
    [JsonPropertyName("contents")]
    public IEnumerable<IdpInstructionsTabContent> Contents { get; set; } =
        new List<IdpInstructionsTabContent>();

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
