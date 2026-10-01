using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// A single page of provisioning instructions. Unlike the setup instructions, a provisioning page has no entry condition: every page is shown.
/// </summary>
[Serializable]
public record IdpProvisioningInstructionsPage : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Key for this page, unique within the response.
    /// </summary>
    [JsonPropertyName("key")]
    public required string Key { get; set; }

    /// <summary>
    /// Page title, localized to the requested locale.
    /// </summary>
    [JsonPropertyName("title")]
    public required string Title { get; set; }

    [Optional]
    [JsonPropertyName("exit_condition")]
    public IdpProvisioningInstructionsPageExitConditionEnum? ExitCondition { get; set; }

    /// <summary>
    /// The content items to render, in order.
    /// </summary>
    [JsonPropertyName("contents")]
    public IEnumerable<IdpProvisioningInstructionsPageContent> Contents { get; set; } =
        new List<IdpProvisioningInstructionsPageContent>();

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
