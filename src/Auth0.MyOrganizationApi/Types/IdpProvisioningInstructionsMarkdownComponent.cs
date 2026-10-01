using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// Markdown prose to render. Only images, links, bold and italic are used.
/// </summary>
[Serializable]
public record IdpProvisioningInstructionsMarkdownComponent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Markdown text. Image sources are paths relative to `base_url`. The text may contain the `{{companyName}}` placeholder, which the client is responsible for substituting.
    /// </summary>
    [JsonPropertyName("text")]
    public required string Text { get; set; }

    [Optional]
    [JsonPropertyName("variant")]
    public IdpProvisioningInstructionsMarkdownVariantEnum? Variant { get; set; }

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
