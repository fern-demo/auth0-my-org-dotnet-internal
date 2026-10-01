using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// Payload for the `tabs_component` content type. Renders a set of tabs, one shown at a time.
/// </summary>
[Serializable]
public record IdpInstructionsTabsComponent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The tabs to render, ordered left to right. Contains at least one tab.
    /// </summary>
    [JsonPropertyName("tabs")]
    public IEnumerable<IdpInstructionsTab> Tabs { get; set; } = new List<IdpInstructionsTab>();

    /// <summary>
    /// Zero-based index into `tabs` of the tab selected on first render. Defaults to `0` when omitted. Must be a valid index into `tabs`.
    /// </summary>
    [Optional]
    [JsonPropertyName("default_tab")]
    public int? DefaultTab { get; set; }

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
