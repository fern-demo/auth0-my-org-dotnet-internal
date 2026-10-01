using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(SubjectTypeEnum.SubjectTypeEnumSerializer))]
[Serializable]
public readonly record struct SubjectTypeEnum : IStringEnum
{
    public static readonly SubjectTypeEnum Client = new(Values.Client);

    public static readonly SubjectTypeEnum User = new(Values.User);

    public SubjectTypeEnum(string value)
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
    public static SubjectTypeEnum FromCustom(string value)
    {
        return new SubjectTypeEnum(value);
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

    public static bool operator ==(SubjectTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(SubjectTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(SubjectTypeEnum value) => value.Value;

    public static explicit operator SubjectTypeEnum(string value) => new(value);

    internal class SubjectTypeEnumSerializer : JsonConverter<SubjectTypeEnum>
    {
        public override SubjectTypeEnum Read(
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
            return new SubjectTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            SubjectTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override SubjectTypeEnum ReadAsPropertyName(
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
            return new SubjectTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            SubjectTypeEnum value,
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
        public const string Client = "client";

        public const string User = "user";
    }
}
