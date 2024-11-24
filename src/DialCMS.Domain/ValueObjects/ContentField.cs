namespace DialCMS.Domain.ValueObjects;

public class ContentField(TemplateField templateField, object? value)
{
    public TemplateField TemplateField { get; private set; } = templateField;
    public object? Value { get; private set; } = value;
}