namespace DialCMS.Domain.ValueObjects;

public class TemplateField(string name, FieldType type, ValidationRule? validationRules)
{
    public string Name { get; private set; } = name;
    public FieldType Type { get; private set; } = type;
    public ValidationRule? ValidationRules { get; private set; } = validationRules;
}