using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;
using DialCMS.Domain.ValueObjects;

namespace DialCMS.Application.Utils;

public class ContentFieldJsonConverter : JsonConverter<ContentField>
{
    public override ContentField Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        // Criar um JsonDocument a partir do reader
        using (JsonDocument document = JsonDocument.ParseValue(ref reader))
        {
            JsonElement root = document.RootElement;
            TemplateField? templateField = null;
            object? value = null;
            // Ler o TemplateField
            if (root.TryGetProperty("TemplateField", out JsonElement templateFieldElement))
            {
                templateField =
                    JsonSerializer.Deserialize<TemplateField>(templateFieldElement.GetRawText(), options);
            }

            // Verificar se TemplateField e seu Type estão disponíveis
            if (templateField == null)
            {
                throw new JsonException("TemplateField is missing.");
            }

            // Ler o Value com base no Type
            if (root.TryGetProperty("Value", out JsonElement valueElement))
            { 
                value = DeserializeValueBasedOnType(valueElement, templateField.Type);
            }
            
            var contentField = new ContentField(templateField, value);
            return contentField;
        }
    }

    public override void Write(Utf8JsonWriter writer, ContentField value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        // Serializar TemplateField
        writer.WritePropertyName("TemplateField");
        JsonSerializer.Serialize(writer, value.TemplateField, options);

        // Serializar Value
        writer.WritePropertyName("Value");
        SerializeValueBasedOnType(writer, value.Value, value.TemplateField.Type, options);

        writer.WriteEndObject();
    }

    private object? DeserializeValueBasedOnType(JsonElement valueElement, FieldType fieldType)
    {
        switch (fieldType)
        {
            case FieldType.Text:
                return valueElement.GetString();

            case FieldType.Number:
                if (valueElement.TryGetInt32(out int intValue))
                    return intValue;
                else if (valueElement.TryGetDouble(out double doubleValue))
                    return doubleValue;
                else
                    throw new JsonException("Invalid number format.");

            case FieldType.Date:
                if (valueElement.TryGetDateTime(out DateTime dateValue))
                {
                    return dateValue;
                }
                else
                {
                    throw new JsonException("Invalid date format. Expected ISO 8601 format.");
                }

            case FieldType.Boolean:
                return valueElement.GetBoolean();

            default:
                throw new NotSupportedException($"FieldType '{fieldType}' is not supported.");
        }
    }

    private void SerializeValueBasedOnType(Utf8JsonWriter writer, object? value, FieldType fieldType,
        JsonSerializerOptions options)
    {
        switch (fieldType)
        {
            case FieldType.Text:
                writer.WriteStringValue(value as string);
                break;

            case FieldType.Number:
                if (value is int intValue)
                    writer.WriteNumberValue(intValue);
                else if (value is double doubleValue)
                    writer.WriteNumberValue(doubleValue);
                else if (value is decimal decimalValue)
                    writer.WriteNumberValue(decimalValue);
                else
                    throw new InvalidOperationException("Invalid number type.");
                break;

            case FieldType.Date:
                if (value is string dateString)
                {
                    // Tentar parsear a string para DateTime para validar o formato
                    if (DateTime.TryParse(dateString, null, DateTimeStyles.RoundtripKind, out DateTime dateTimeValue))
                    {
                        // Serializar a data no formato ISO 8601
                        writer.WriteStringValue(dateTimeValue.ToString("O"));
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid date string format. Expected ISO 8601 format.");
                    }
                }
                else if (value is DateTime dateTimeValue)
                {
                    // Já é um DateTime, serializar diretamente no formato ISO 8601
                    writer.WriteStringValue(dateTimeValue.ToString("O"));
                }
                else
                {
                    throw new InvalidOperationException("Invalid date type. Expected string or DateTime.");
                }

                break;

            case FieldType.Boolean:
                if (value is bool boolValue)
                    writer.WriteBooleanValue(boolValue);
                else
                    throw new InvalidOperationException("Invalid boolean type.");
                break;

            default:
                throw new NotSupportedException($"FieldType '{fieldType}' is not supported.");
        }
    }
}