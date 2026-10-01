using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(
    typeof(IdpInstructionsTabContentTypeEnum.IdpInstructionsTabContentTypeEnumSerializer)
)]
[Serializable]
public readonly record struct IdpInstructionsTabContentTypeEnum : IStringEnum
{
    public static readonly IdpInstructionsTabContentTypeEnum MarkdownComponent = new(
        Values.MarkdownComponent
    );

    public IdpInstructionsTabContentTypeEnum(string value)
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
    public static IdpInstructionsTabContentTypeEnum FromCustom(string value)
    {
        return new IdpInstructionsTabContentTypeEnum(value);
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

    public static bool operator ==(IdpInstructionsTabContentTypeEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IdpInstructionsTabContentTypeEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IdpInstructionsTabContentTypeEnum value) => value.Value;

    public static explicit operator IdpInstructionsTabContentTypeEnum(string value) => new(value);

    internal class IdpInstructionsTabContentTypeEnumSerializer
        : JsonConverter<IdpInstructionsTabContentTypeEnum>
    {
        public override IdpInstructionsTabContentTypeEnum Read(
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
            return new IdpInstructionsTabContentTypeEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpInstructionsTabContentTypeEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IdpInstructionsTabContentTypeEnum ReadAsPropertyName(
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
            return new IdpInstructionsTabContentTypeEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdpInstructionsTabContentTypeEnum value,
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
    }
}
