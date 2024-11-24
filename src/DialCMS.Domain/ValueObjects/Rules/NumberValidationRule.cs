namespace DialCMS.Domain.ValueObjects;

public class NumberValidationRule : ValidationRule
{
    public double? MinValue { get; set; }
    public double? MaxValue { get; set; }
    public bool AllowNegative { get; set; }
}