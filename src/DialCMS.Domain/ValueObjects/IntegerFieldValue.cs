namespace DialCMS.Domain.ValueObjects;

public class IntegerFieldValue
{
    public int Value { get; private set; }

    public IntegerFieldValue(int value)
    {
        Value = value;
    }

    public override string ToString() => Value.ToString();
}