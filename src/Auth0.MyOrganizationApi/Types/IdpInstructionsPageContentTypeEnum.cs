using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(
    typeof(IdpInstructionsPageContentTypeEnum.IdpInstructionsPageContentTypeEnumSerializer)
)]
[Serializable]
public readonly record struct IdpInstructionsPageContentTypeEnum : IStringEnum
{
    public static readonly IdpInstructionsPageContentTypeEnum MarkdownComponent = new(
        Values.MarkdownComponent
    );

    public static readonly IdpInstructionsPageContentTypeEnum TabsComponent = new(
        Values.TabsComponent
    );

    public static readonly IdpInstructionsPageContentTypeEnum CallbackUrlComponent = new(
        Values.CallbackUrlComponent
    );

    public static readonly IdpInstructionsPageContentTypeEnum AttributeMappingListComponent = new(
        Values.AttributeMappingListComponent
    );

    public static readonly IdpInstructionsPageContentTypeEnum TestConnectionComponent = new(
        Values.TestConnectionComponent
    );

    public static readonly IdpInstructionsPageContentTypeEnum OktaConfigureConnectionComponent =
        new(Values.OktaConfigureConnectionComponent);

    public static readonly IdpInstructionsPageContentTypeEnum OidcConfigureConnectionComponent =
        new(Values.OidcConfigureConnectionComponent);

    public static readonly IdpInstructionsPageContentTypeEnum SamlpConfigureConnectionComponent =
        new(Values.SamlpConfigureConnectionComponent);

    public static readonly IdpInstructionsPageContentTypeEnum SsoUrlComponent = new(
        Values.SsoUrlComponent
    );

    public static readonly IdpInstructionsPageContentTypeEnum ServiceProviderEntityIdComponent =
        new(Values.ServiceProviderEntityIdComponent);

    public static readonly IdpInstructionsPageContentTypeEnum AdfsRelyingPartyWsFederationPassiveProtocolUrlComponent =
        new(Values.AdfsRelyingPartyWsFederationPassiveProtocolUrlComponent);

    public static readonly IdpInstructionsPageContentTypeEnum AdfsRelyingPartyTrustIdentifierComponent =
        new(Values.AdfsRelyingPartyTrustIdentifierComponent);

    public static readonly IdpInstructionsPageContentTypeEnum AdfsConfigureConnectionComponent =
        new(Values.AdfsConfigureConnectionComponent);

    public static readonly IdpInstructionsPageContentTypeEnum WaadConfigureConnectionComponent =
        new(Values.WaadConfigureConnectionComponent);

    public static readonly IdpInstructionsPageContentTypeEnum GoogleAppsAuthorizedJavascriptOriginsComponent =
        new(Values.GoogleAppsAuthorizedJavascriptOriginsComponent);

    public static readonly IdpInstructionsPageContentTypeEnum GoogleAppsAuthorizedRedirectUriComponent =
        new(Values.GoogleAppsAuthorizedRedirectUriComponent);

    public static readonly IdpInstructionsPageContentTypeEnum GoogleAppsConfigureConnectionComponent =
        new(Values.GoogleAppsConfigureConnectionComponent);

    public static readonly IdpInstructionsPageContentTypeEnum PingfederatePartnersEntityIdComponent =
        new(Values.PingfederatePartnersEntityIdComponent);

    public static readonly IdpInstructionsPageContentTypeEnum PingfederateEndpointUrlComponent =
        new(Values.PingfederateEndpointUrlComponent);

    public static readonly IdpInstructionsPageContentTypeEnum PingfederateConfigureConnectionComponent =
        new(Values.PingfederateConfigureConnectionComponent);

    public IdpInstructionsPageContentTypeEnum(string value)
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
    public static IdpInstructionsPageContentTypeEnum FromCustom(string value)
    {
        return new IdpInstructionsPageContentTypeEnum(value);
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

    public static bool operator ==(IdpInstructionsPageContentTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IdpInstructionsPageContentTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IdpInstructionsPageContentTypeEnum value) => value.Value;

    public static explicit operator IdpInstructionsPageContentTypeEnum(string value) => new(value);

    internal class IdpInstructionsPageContentTypeEnumSerializer
        : JsonConverter<IdpInstructionsPageContentTypeEnum>
    {
        public override IdpInstructionsPageContentTypeEnum Read(
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
            return new IdpInstructionsPageContentTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpInstructionsPageContentTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IdpInstructionsPageContentTypeEnum ReadAsPropertyName(
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
            return new IdpInstructionsPageContentTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdpInstructionsPageContentTypeEnum value,
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

        public const string TabsComponent = "tabs_component";

        public const string CallbackUrlComponent = "callback_url_component";

        public const string AttributeMappingListComponent = "attribute_mapping_list_component";

        public const string TestConnectionComponent = "test_connection_component";

        public const string OktaConfigureConnectionComponent =
            "okta_configure_connection_component";

        public const string OidcConfigureConnectionComponent =
            "oidc_configure_connection_component";

        public const string SamlpConfigureConnectionComponent =
            "samlp_configure_connection_component";

        public const string SsoUrlComponent = "sso_url_component";

        public const string ServiceProviderEntityIdComponent =
            "service_provider_entity_id_component";

        public const string AdfsRelyingPartyWsFederationPassiveProtocolUrlComponent =
            "adfs_relying_party_ws_federation_passive_protocol_url_component";

        public const string AdfsRelyingPartyTrustIdentifierComponent =
            "adfs_relying_party_trust_identifier_component";

        public const string AdfsConfigureConnectionComponent =
            "adfs_configure_connection_component";

        public const string WaadConfigureConnectionComponent =
            "waad_configure_connection_component";

        public const string GoogleAppsAuthorizedJavascriptOriginsComponent =
            "google_apps_authorized_javascript_origins_component";

        public const string GoogleAppsAuthorizedRedirectUriComponent =
            "google_apps_authorized_redirect_uri_component";

        public const string GoogleAppsConfigureConnectionComponent =
            "google_apps_configure_connection_component";

        public const string PingfederatePartnersEntityIdComponent =
            "pingfederate_partners_entity_id_component";

        public const string PingfederateEndpointUrlComponent =
            "pingfederate_endpoint_url_component";

        public const string PingfederateConfigureConnectionComponent =
            "pingfederate_configure_connection_component";
    }
}
