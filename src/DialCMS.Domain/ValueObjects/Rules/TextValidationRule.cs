using DialCMS.Domain.ValueObjects.Rules;

namespace DialCMS.Domain.ValueObjects;

public class TextValidationRule : ValidationRule
{
    public int? MinLength { get; set; }
    public int? MaxLength { get; set; }

    public TextValidationRule()
    {
        
    }
}