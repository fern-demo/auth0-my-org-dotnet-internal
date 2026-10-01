using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(XAuth0RateLimitWriteLimitType.XAuth0RateLimitWriteLimitTypeSerializer))]
[Serializable]
public readonly record struct XAuth0RateLimitWriteLimitType : IStringEnum
{
    public static readonly XAuth0RateLimitWriteLimitType PerTenant = new(Values.PerTenant);

    public XAuth0RateLimitWriteLimitType(string value)
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
    public static XAuth0RateLimitWriteLimitType FromCustom(string value)
    {
        return new XAuth0RateLimitWriteLimitType(value);
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

    public static bool operator ==(XAuth0RateLimitWriteLimitType value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(XAuth0RateLimitWriteLimitType value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(XAuth0RateLimitWriteLimitType value) => value.Value;

    public static explicit operator XAuth0RateLimitWriteLimitType(string value) => new(value);

    internal class XAuth0RateLimitWriteLimitTypeSerializer
        : JsonConverter<XAuth0RateLimitWriteLimitType>
    {
        public override XAuth0RateLimitWriteLimitType Read(
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
            return new XAuth0RateLimitWriteLimitType(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            XAuth0RateLimitWriteLimitType value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override XAuth0RateLimitWriteLimitType ReadAsPropertyName(
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
            return new XAuth0RateLimitWriteLimitType(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            XAuth0RateLimitWriteLimitType value,
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
