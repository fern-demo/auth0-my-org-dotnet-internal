using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(
    typeof(IdpInstructionsLifecycleStatusEnum.IdpInstructionsLifecycleStatusEnumSerializer)
)]
[Serializable]
public readonly record struct IdpInstructionsLifecycleStatusEnum : IStringEnum
{
    public static readonly IdpInstructionsLifecycleStatusEnum Latest = new(Values.Latest);

    public static readonly IdpInstructionsLifecycleStatusEnum OutOfDate = new(Values.OutOfDate);

    public static readonly IdpInstructionsLifecycleStatusEnum Deprecated = new(Values.Deprecated);

    public IdpInstructionsLifecycleStatusEnum(string value)
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
    public static IdpInstructionsLifecycleStatusEnum FromCustom(string value)
    {
        return new IdpInstructionsLifecycleStatusEnum(value);
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

    public static bool operator ==(IdpInstructionsLifecycleStatusEnum value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(IdpInstructionsLifecycleStatusEnum value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(IdpInstructionsLifecycleStatusEnum value) => value.Value;

    public static explicit operator IdpInstructionsLifecycleStatusEnum(string value) => new(value);

    internal class IdpInstructionsLifecycleStatusEnumSerializer
        : JsonConverter<IdpInstructionsLifecycleStatusEnum>
    {
        public override IdpInstructionsLifecycleStatusEnum Read(
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
            return new IdpInstructionsLifecycleStatusEnum(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            IdpInstructionsLifecycleStatusEnum value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override IdpInstructionsLifecycleStatusEnum ReadAsPropertyName(
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
            return new IdpInstructionsLifecycleStatusEnum(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            IdpInstructionsLifecycleStatusEnum value,
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
        public const string Latest = "latest";

        public const string OutOfDate = "out_of_date";

        public const string Deprecated = "deprecated";
    }
}
