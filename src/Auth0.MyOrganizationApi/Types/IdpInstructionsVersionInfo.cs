using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

/// <summary>
/// The version of the instruction schema used to build this response.
/// </summary>
[Serializable]
public record IdpInstructionsVersionInfo : IJsonOnDeserialized
{
    [JsonExtensionData]
    private readonly IDictionary<string, JsonElement> _extensionData =
        new Dictionary<string, JsonElement>();

    /// <summary>
    /// The instruction schema version this response conforms to.
    /// </summary>
    [JsonPropertyName("version")]
    public required string Version { get; set; }

    [JsonPropertyName("lifecycle_status")]
    public required IdpInstructionsLifecycleStatusEnum LifecycleStatus { get; set; }

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
