using DialCMS.Domain.Core;

namespace DialCMS.Domain.ValueObjects;

public class IntegerFieldValue: ValueObject
{
    public int Value { get; private set; }

    public IntegerFieldValue(int value)
    {
        Value = value;
    }

    public override string ToString() => Value.ToString();
}