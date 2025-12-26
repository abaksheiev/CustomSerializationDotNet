using System;
using System.Text.Json;
using System.Text.Json.Serialization;

public record Money(decimal Amount, string Currency);

public sealed class MoneyJsonConverter : JsonConverter<Money>
{
    public override Money Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options)
    {
        var rawValue = reader.GetString();
        var parts = rawValue.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        return new Money(
            decimal.Parse(parts[0]),
            parts[1]
        );
    }

    public override void Write(
        Utf8JsonWriter writer,
        Money value,
        JsonSerializerOptions options)
    {
        writer.WriteStringValue($"{value.Amount} {value.Currency}");
    }
}
