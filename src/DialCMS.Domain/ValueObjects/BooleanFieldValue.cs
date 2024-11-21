namespace DialCMS.Domain.ValueObjects;

public class BooleanFieldValue
{
    public bool Value { get; private set; }

    public BooleanFieldValue(bool value)
    {
        Value = value;
    }

    public override string ToString() => Value ? "True" : "False";
}