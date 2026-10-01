using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(
    typeof(IdpProvisioningInstructionsPageContentTypeEnum.IdpProvisioningInstructionsPageContentTypeEnumSerializer)
)]
[Serializable]
public readonly record struct IdpProvisioningInstructionsPageContentTypeEnum : IStringEnum
{
    public static readonly IdpProvisioningInstructionsPageContentTypeEnum MarkdownComponent = new(
        Values.MarkdownComponent
    );

    public static readonly IdpProvisioningInstructionsPageContentTypeEnum ScimEndpointUrlComponent =
        new(Values.ScimEndpointUrlComponent);

    public static readonly IdpProvisioningInstructionsPageContentTypeEnum BearerTokenComponent =
        new(Values.BearerTokenComponent);

    public static readonly IdpProvisioningInstructionsPageContentTypeEnum OktaSchemaUrnComponent =
        new(Values.OktaSchemaUrnComponent);

    public static readonly IdpProvisioningInstructionsPageContentTypeEnum AttributeMappingListComponent =
        new(Values.AttributeMappingListComponent);

    public static readonly IdpProvisioningInstructionsPageContentTypeEnum GoogleWorkspaceSetupComponent =
        new(Values.GoogleWorkspaceSetupComponent);

    public IdpProvisioningInstructionsPageContentTypeEnum(string value)
    {
        Value = value;
    }

    /// <summary>
    /// The string value of the enum.
    /// </summary>
    public string Value { get; }

    /// <summary>
    /// Create a string enum with the given value.
    /// </summary>
    public static IdpProvisioningInstructionsPageContentTypeEnum FromCustom(string value)
    {
        return new IdpProvisioningInstructionsPageContentTypeEnum(value);
    }

    public bool Equals(string? other)
    {
        return Value.Equals(other);
    }

    /// <summary>
    /// Returns the string value of the enum.
    /// </summary>
    public override string ToString()
    {
        return Value;
    }

    public static bool operator ==(
        IdpProvisioningInstructionsPageContentTypeEnum value1,
        string value2
    ) => value1.Value.Equals(value2);

    public static bool operator !=(
        IdpProvisioningInstructionsPageContentTypeEnum value1,
        string value2
    ) => !value1.Value.Equals(value2);

    public static explicit operator string(IdpProvisioningInstructionsPageContentTypeEnum value) =>
        value.Value;

    public static explicit operator IdpProvisioningInstructionsPageContentTypeEnum(string value) =>
        new(value);

    internal class IdpProvisioningInstructionsPageContentTypeEnumSerializer
        : JsonConverter<IdpProvisioningInstructionsPageContentTypeEnum>
    {
        public override IdpProvisioningInstructionsPageContentTypeEnum Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON value could not be read as a string."
                );
            return new IdpProvisioningInstructionsPageContentTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpProvisioningInstructionsPageContentTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IdpProvisioningInstructionsPageContentTypeEnum ReadAsPropertyName(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options
        )
        {
            var stringValue =
                reader.GetString()
                ?? throw new global::System.Exception(
                    "The JSON property name could not be read as a string."
                );
            return new IdpProvisioningInstructionsPageContentTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdpProvisioningInstructionsPageContentTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WritePropertyName(value.Value);
        }
    }

    /// <summary>
    /// Constant strings for enum values
    /// </summary>
    [Serializable]
    public static class Values
    {
        public const string MarkdownComponent = "markdown_component";

        public const string ScimEndpointUrlComponent = "scim_endpoint_url_component";

        public const string BearerTokenComponent = "bearer_token_component";

        public const string OktaSchemaUrnComponent = "okta_schema_urn_component";

        public const string AttributeMappingListComponent = "attribute_mapping_list_component";

        public const string GoogleWorkspaceSetupComponent = "google_workspace_setup_component";
    }
}
