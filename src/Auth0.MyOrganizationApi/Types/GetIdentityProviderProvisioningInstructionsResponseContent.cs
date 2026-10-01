using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[Serializable]
public record GetIdentityProviderProvisioningInstructionsResponseContent : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// Base URL that relative asset paths in the instructions, such as Markdown image sources, must be resolved against.
    /// </summary>
    [JsonPropertyName("base_url")]
    public required string BaseUrl { get; set; }

    [JsonPropertyName("version_info")]
    public required IdpInstructionsVersionInfo VersionInfo { get; set; }

    /// <summary>
    /// The pages of instructions to render, in order.
    /// </summary>
    [JsonPropertyName("pages")]
    public IEnumerable<IdpProvisioningInstructionsPage> Pages { get; set; } =
        new List<IdpProvisioningInstructionsPage>();

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
