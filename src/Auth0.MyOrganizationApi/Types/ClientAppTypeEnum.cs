using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(ClientAppTypeEnum.ClientAppTypeEnumSerializer))]
[Serializable]
public readonly record struct ClientAppTypeEnum : IStringEnum
{
    public static readonly ClientAppTypeEnum NonInteractive = new(Values.NonInteractive);

    public ClientAppTypeEnum(string value)
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
    public static ClientAppTypeEnum FromCustom(string value)
    {
        return new ClientAppTypeEnum(value);
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

    public static bool operator ==(ClientAppTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientAppTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientAppTypeEnum value) => value.Value;

    public static explicit operator ClientAppTypeEnum(string value) => new(value);

    internal class ClientAppTypeEnumSerializer : JsonConverter<ClientAppTypeEnum>
    {
        public override ClientAppTypeEnum Read(
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
            return new ClientAppTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientAppTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientAppTypeEnum ReadAsPropertyName(
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
            return new ClientAppTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientAppTypeEnum value,
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
        public const string NonInteractive = "non_interactive";
    }
}
