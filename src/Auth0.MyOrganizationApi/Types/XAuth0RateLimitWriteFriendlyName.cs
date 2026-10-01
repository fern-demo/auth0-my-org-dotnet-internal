using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(typeof(XAuth0RateLimitWriteFriendlyName.XAuth0RateLimitWriteFriendlyNameSerializer))]
[Serializable]
public readonly record struct XAuth0RateLimitWriteFriendlyName : IStringEnum
{
    public static readonly XAuth0RateLimitWriteFriendlyName MyOrgApiRateLimitWrite = new(
        Values.MyOrgApiRateLimitWrite
    );

    public XAuth0RateLimitWriteFriendlyName(string value)
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
    public static XAuth0RateLimitWriteFriendlyName FromCustom(string value)
    {
        return new XAuth0RateLimitWriteFriendlyName(value);
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

    public static bool operator ==(XAuth0RateLimitWriteFriendlyName value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(XAuth0RateLimitWriteFriendlyName value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(XAuth0RateLimitWriteFriendlyName value) => value.Value;

    public static explicit operator XAuth0RateLimitWriteFriendlyName(string value) => new(value);

    internal class XAuth0RateLimitWriteFriendlyNameSerializer
        : JsonConverter<XAuth0RateLimitWriteFriendlyName>
    {
        public override XAuth0RateLimitWriteFriendlyName Read(
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
            return new XAuth0RateLimitWriteFriendlyName(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            XAuth0RateLimitWriteFriendlyName value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override XAuth0RateLimitWriteFriendlyName ReadAsPropertyName(
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
            return new XAuth0RateLimitWriteFriendlyName(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            XAuth0RateLimitWriteFriendlyName value,
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
        public const string MyOrgApiRateLimitWrite = "My Org API  Rate Limit  Write";
    }
}
