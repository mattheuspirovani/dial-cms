using System.Text.Json;

namespace DialCMS.Application.Dtos;

public class FieldDto
{
    public string Name { get; set; }
    public string DataType { get; set; }
    public Dictionary<string, dynamic> Options { get; set; }
    
    public Dictionary<string, object> GetConvertedOptions()
    {
        var convertedOptions = new Dictionary<string, object>();

        foreach (var option in Options)
        {
            if (option.Value is JsonElement jsonElement)
            {
                object convertedValue = jsonElement.ValueKind switch
                {
                    JsonValueKind.Number => jsonElement.GetInt32(), 
                    JsonValueKind.String => jsonElement.GetString(),
                    JsonValueKind.True or JsonValueKind.False => jsonElement.GetBoolean(),
                    _ => throw new InvalidOperationException($"Unsupported value kind: {jsonElement.ValueKind}")
                };

                convertedOptions[option.Key] = convertedValue;
            }
            else
            {
                convertedOptions[option.Key] = option.Value;
            }
        }

        return convertedOptions;
    }
}