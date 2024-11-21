using DialCMS.Domain.Core;

namespace DialCMS.Domain.ValueObjects;

public class BooleanFieldValue: ValueObject
{
    public bool Value { get; private set; }

    public BooleanFieldValue(bool value)
    {
        Value = value;
    }

    public override string ToString() => Value ? "True" : "False";
}