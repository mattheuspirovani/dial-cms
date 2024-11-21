using DialCMS.Domain.Core;
using DialCMS.Domain.Entities;
using DialCMS.Domain.ValueObjects;

namespace DialCMS.Application.Services;

public class ContentValueUpdater
{
    public void UpdateValues(Content content, Dictionary<string, Dictionary<string, object>> values)
    {
        foreach (var (fieldName, fieldData) in values)
        {
            var field = content.Fields.FirstOrDefault(f => f.Name == fieldName);
            if (field == null)
            {
                throw new ArgumentException($"Field '{fieldName}' does not exist.");
            }

            ValueObject value = field.DataType.Name switch
            {
                "String" => CreateStringFieldValue(fieldData),
                "Money" => CreateMoneyFieldValue(fieldData),
                _ => throw new ArgumentException($"Unsupported DataType: {field.DataType.Name}.")
            };

            content.SetValue(fieldName, value);
        }
    }

    private static StringFieldValue CreateStringFieldValue(Dictionary<string, object> fieldData)
    {
        return new StringFieldValue(
            value: fieldData["value"].ToString()!,
            maxLength: Convert.ToInt32(fieldData.GetValueOrDefault("maxLength", 255))
        );
    }

    private static MoneyFieldValue CreateMoneyFieldValue(Dictionary<string, object> fieldData)
    {
        return new MoneyFieldValue(
            amount: Convert.ToDecimal(fieldData["amount"]),
            currency: fieldData["currency"].ToString()!
        );
    }
}