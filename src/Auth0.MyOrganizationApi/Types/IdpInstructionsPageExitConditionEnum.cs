using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(
    typeof(IdpInstructionsPageExitConditionEnum.IdpInstructionsPageExitConditionEnumSerializer)
)]
[Serializable]
public readonly record struct IdpInstructionsPageExitConditionEnum : IStringEnum
{
    public static readonly IdpInstructionsPageExitConditionEnum ConnectionExists = new(
        Values.ConnectionExists
    );

    public static readonly IdpInstructionsPageExitConditionEnum ConnectionTestingSuggested = new(
        Values.ConnectionTestingSuggested
    );

    public IdpInstructionsPageExitConditionEnum(string value)
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
    public static IdpInstructionsPageExitConditionEnum FromCustom(string value)
    {
        return new IdpInstructionsPageExitConditionEnum(value);
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

    public static bool operator ==(IdpInstructionsPageExitConditionEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IdpInstructionsPageExitConditionEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IdpInstructionsPageExitConditionEnum value) =>
        value.Value;

    public static explicit operator IdpInstructionsPageExitConditionEnum(string value) =>
        new(value);

    internal class IdpInstructionsPageExitConditionEnumSerializer
        : JsonConverter<IdpInstructionsPageExitConditionEnum>
    {
        public override IdpInstructionsPageExitConditionEnum Read(
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
            return new IdpInstructionsPageExitConditionEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpInstructionsPageExitConditionEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IdpInstructionsPageExitConditionEnum ReadAsPropertyName(
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
            return new IdpInstructionsPageExitConditionEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdpInstructionsPageExitConditionEnum value,
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
        public const string ConnectionExists = "connection_exists";

        public const string ConnectionTestingSuggested = "connection_testing_suggested";
    }
}
