using DialCMS.Domain.Core;

namespace DialCMS.Domain.ValueObjects;

public class DateFieldValue: ValueObject
{
    public DateTime Value { get; private set; }

    public DateFieldValue(DateTime value)
    {
        Value = value;
    }

    public override string ToString() => Value.ToString("yyyy-MM-dd HH:mm:ss");
}