namespace DialCMS.Domain.ValueObjects;

public class TextFieldValue
{
    public string Value { get; private set; }
    public int MaxLength { get; private set; }

    public TextFieldValue(string value, int maxLength = 255)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Text cannot be null or empty.", nameof(value));

        if (value.Length > maxLength)
            throw new ArgumentException($"Text cannot exceed {maxLength} characters.", nameof(value));

        Value = value;
        MaxLength = maxLength;
    }

    public override string ToString() => Value;
}