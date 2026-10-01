using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(XAuth0RateLimitReadLimitType.XAuth0RateLimitReadLimitTypeSerializer))]
[Serializable]
public readonly record struct XAuth0RateLimitReadLimitType : IStringEnum
{
    public static readonly XAuth0RateLimitReadLimitType PerTenant = new(Values.PerTenant);

    public XAuth0RateLimitReadLimitType(string value)
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
    public static XAuth0RateLimitReadLimitType FromCustom(string value)
    {
        return new XAuth0RateLimitReadLimitType(value);
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

    public static bool operator ==(XAuth0RateLimitReadLimitType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(XAuth0RateLimitReadLimitType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(XAuth0RateLimitReadLimitType value) => value.Value;

    public static explicit operator XAuth0RateLimitReadLimitType(string value) => new(value);

    internal class XAuth0RateLimitReadLimitTypeSerializer
        : JsonConverter<XAuth0RateLimitReadLimitType>
    {
        public override XAuth0RateLimitReadLimitType Read(
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
            return new XAuth0RateLimitReadLimitType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            XAuth0RateLimitReadLimitType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override XAuth0RateLimitReadLimitType ReadAsPropertyName(
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
            return new XAuth0RateLimitReadLimitType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            XAuth0RateLimitReadLimitType value,
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
        public const string PerTenant = "per_tenant";
    }
}
