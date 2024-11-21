using DialCMS.Domain.Core;

namespace DialCMS.Domain.ValueObjects;

public class StringFieldValue : ValueObject
{
    public string Value { get; private set; }
    public int MaxLength { get; private set; }

    public StringFieldValue(string value, int maxLength = 255)
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