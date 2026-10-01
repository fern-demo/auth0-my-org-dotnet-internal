using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(IdpInstructionsLocaleEnum.IdpInstructionsLocaleEnumSerializer))]
[Serializable]
public readonly record struct IdpInstructionsLocaleEnum : IStringEnum
{
    public static readonly IdpInstructionsLocaleEnum En = new(Values.En);

    public IdpInstructionsLocaleEnum(string value)
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
    public static IdpInstructionsLocaleEnum FromCustom(string value)
    {
        return new IdpInstructionsLocaleEnum(value);
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

    public static bool operator ==(IdpInstructionsLocaleEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IdpInstructionsLocaleEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IdpInstructionsLocaleEnum value) => value.Value;

    public static explicit operator IdpInstructionsLocaleEnum(string value) => new(value);

    internal class IdpInstructionsLocaleEnumSerializer : JsonConverter<IdpInstructionsLocaleEnum>
    {
        public override IdpInstructionsLocaleEnum Read(
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
            return new IdpInstructionsLocaleEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpInstructionsLocaleEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IdpInstructionsLocaleEnum ReadAsPropertyName(
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
            return new IdpInstructionsLocaleEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdpInstructionsLocaleEnum value,
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
        public const string En = "en";
    }
}
