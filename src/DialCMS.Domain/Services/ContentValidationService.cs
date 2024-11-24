using DialCMS.Domain.ValueObjects;

namespace DialCMS.Domain.Services;

public class ContentValidationService
{
    public bool ValidateContentField(ContentField contentField)
    {
        var fieldType = contentField.TemplateField.Type;
        var validationRules = contentField.TemplateField.ValidationRules;
        var value = contentField.Value;

        switch (fieldType)
        {
            case FieldType.Text:
                return ValidateTextField(value as string, (validationRules as TextValidationRule)!);
            case FieldType.Number:
                return ValidateNumberField(value, (validationRules as NumberValidationRule)!);
            case FieldType.Date:
                return ValidateDateField(value as DateTime?, (validationRules as DateValidationRule)!);
            case FieldType.Boolean:
                // Implementar se necessário
                return true;
            default:
                throw new NotSupportedException($"Tipo de campo {fieldType} não suportado.");
        }
    }

    private bool ValidateTextField(string? value, TextValidationRule rules)
    {
        if (rules.IsRequired && string.IsNullOrEmpty(value))
            return false;

        if (rules.MinLength.HasValue && (value?.Length ?? 0) < rules.MinLength.Value)
            return false;

        if (rules.MaxLength.HasValue && (value?.Length ?? 0) > rules.MaxLength.Value)
            return false;

        // Outras validações como regex

        return true;
    }

    private bool ValidateNumberField(object? value, NumberValidationRule rules)
    {
        if (value == null)
            return !rules.IsRequired;

        if (!double.TryParse(value.ToString(), out double number))
            return false;

        if (!rules.AllowNegative && number < 0)
            return false;

        if (rules.MinValue.HasValue && number < rules.MinValue.Value)
            return false;

        if (rules.MaxValue.HasValue && number > rules.MaxValue.Value)
            return false;

        return true;
    }

    private bool ValidateDateField(DateTime? value, DateValidationRule rules)
    {
        if (rules.IsRequired && !value.HasValue)
            return false;

        if (rules.MinDate.HasValue && value < rules.MinDate.Value)
            return false;

        if (rules.MaxDate.HasValue && value > rules.MaxDate.Value)
            return false;

        return true;
    }
}