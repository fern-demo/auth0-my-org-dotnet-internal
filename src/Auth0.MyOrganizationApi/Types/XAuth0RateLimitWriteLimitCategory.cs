using Auth0.MyOrganizationApi.Core;
using global::System.Text.Json;
using global::System.Text.Json.Serialization;

namespace Auth0.MyOrganizationApi;

[JsonConverter(
    typeof(XAuth0RateLimitWriteLimitCategory.XAuth0RateLimitWriteLimitCategorySerializer)
)]
[Serializable]
public readonly record struct XAuth0RateLimitWriteLimitCategory : IStringEnum
{
    public static readonly XAuth0RateLimitWriteLimitCategory Write = new(Values.Write);

    public XAuth0RateLimitWriteLimitCategory(string value)
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
    public static XAuth0RateLimitWriteLimitCategory FromCustom(string value)
    {
        return new XAuth0RateLimitWriteLimitCategory(value);
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

    public static bool operator ==(XAuth0RateLimitWriteLimitCategory value1, string value2) =>
        value1.Value.Equals(value2);

    public static bool operator !=(XAuth0RateLimitWriteLimitCategory value1, string value2) =>
        !value1.Value.Equals(value2);

    public static explicit operator string(XAuth0RateLimitWriteLimitCategory value) => value.Value;

    public static explicit operator XAuth0RateLimitWriteLimitCategory(string value) => new(value);

    internal class XAuth0RateLimitWriteLimitCategorySerializer
        : JsonConverter<XAuth0RateLimitWriteLimitCategory>
    {
        public override XAuth0RateLimitWriteLimitCategory Read(
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
            return new XAuth0RateLimitWriteLimitCategory(stringValue);
        }

        public override void Write(
            Utf8JsonWriter writer,
            XAuth0RateLimitWriteLimitCategory value,
            JsonSerializerOptions options
        )
        {
            writer.WriteStringValue(value.Value);
        }

        public override XAuth0RateLimitWriteLimitCategory ReadAsPropertyName(
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
            return new XAuth0RateLimitWriteLimitCategory(stringValue);
        }

        public override void WriteAsPropertyName(
            Utf8JsonWriter writer,
            XAuth0RateLimitWriteLimitCategory value,
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
        public const string Write = "write";
    }
}
