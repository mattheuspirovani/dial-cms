using DialCMS.Domain.ValueObjects.Rules;

namespace DialCMS.Domain.ValueObjects;

public class DateValidationRule : ValidationRule
{
    public DateTime? MinDate { get; set; }
    public DateTime? MaxDate { get; set; }
}