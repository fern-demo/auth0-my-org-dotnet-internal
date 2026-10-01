using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(ClientJwtAlgEnum.ClientJwtAlgEnumSerializer))]
[Serializable]
public readonly record struct ClientJwtAlgEnum : IStringEnum
{
    public static readonly ClientJwtAlgEnum Hs256 = new(Values.Hs256);

    public static readonly ClientJwtAlgEnum Rs256 = new(Values.Rs256);

    public static readonly ClientJwtAlgEnum Rs512 = new(Values.Rs512);

    public static readonly ClientJwtAlgEnum Ps256 = new(Values.Ps256);

    public ClientJwtAlgEnum(string value)
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
    public static ClientJwtAlgEnum FromCustom(string value)
    {
        return new ClientJwtAlgEnum(value);
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

    public static bool operator ==(ClientJwtAlgEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(ClientJwtAlgEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(ClientJwtAlgEnum value) => value.Value;

    public static explicit operator ClientJwtAlgEnum(string value) => new(value);

    internal class ClientJwtAlgEnumSerializer : JsonConverter<ClientJwtAlgEnum>
    {
        public override ClientJwtAlgEnum Read(
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
            return new ClientJwtAlgEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            ClientJwtAlgEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override ClientJwtAlgEnum ReadAsPropertyName(
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
            return new ClientJwtAlgEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            ClientJwtAlgEnum value,
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
        public const string Hs256 = "HS256";

        public const string Rs256 = "RS256";

        public const string Rs512 = "RS512";

        public const string Ps256 = "PS256";
    }
}
