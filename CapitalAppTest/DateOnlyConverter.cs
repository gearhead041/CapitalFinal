using System.Text.Json;
using System.Text.Json.Serialization;

public class DateOnlyConverter : JsonConverter<DateOnly>
{
    public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType == JsonTokenType.String && reader.TryGetDateTime(out DateTime dateTime))
        {
            return new DateOnly(dateTime.Year,dateTime.Month,dateTime.Day);
        }

        throw new JsonException($"Unexpected token or format when parsing DateOnly: {reader.TokenType}");
    }

    public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
    {
        string formattedDate = value.ToString("yyyy-MM-dd");
        writer.WriteStringValue(formattedDate);
    }
}
