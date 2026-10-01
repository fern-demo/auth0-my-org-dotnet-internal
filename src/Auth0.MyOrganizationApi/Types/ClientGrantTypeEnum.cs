using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(ClientGrantTypeEnum.ClientGrantTypeEnumSerializer))]
[Serializable]
public readonly record struct ClientGrantTypeEnum : IStringEnum
{
    public static readonly ClientGrantTypeEnum ClientCredentials = new(Values.ClientCredentials);

    public ClientGrantTypeEnum(string value)
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
    public static ClientGrantTypeEnum FromCustom(string value)
    {
        return new ClientGrantTypeEnum(value);
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

    public static bool operator ==(ClientGrantTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientGrantTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientGrantTypeEnum value) => value.Value;

    public static explicit operator ClientGrantTypeEnum(string value) => new(value);

    internal class ClientGrantTypeEnumSerializer : JsonConverter<ClientGrantTypeEnum>
    {
        public override ClientGrantTypeEnum Read(
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
            return new ClientGrantTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientGrantTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientGrantTypeEnum ReadAsPropertyName(
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
            return new ClientGrantTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientGrantTypeEnum value,
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
        public const string ClientCredentials = "client_credentials";
    }
}
