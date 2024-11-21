namespace DialCMS.Domain.ValueObjects;

public class DataType
{
    public string Name { get; private set; }

    private DataType(string name)
    {
        Name = name;
    }

    public static readonly DataType String = new("String");
    public static readonly DataType Decimal = new("Decimal");
    public static readonly DataType DateTime = new("DateTime");
    public static readonly DataType Int = new("Int");
    public static readonly DataType Boolean = new("Boolean");
    public static readonly DataType Money = new("Money");
    public static readonly DataType Image = new("Image");
    public static readonly DataType ImageGallery = new("ImageGallery");

    public void Validate(object value)
    {
        switch (Name)
        {
            case "String":
                if (value is not TextFieldValue)
                    throw new ArgumentException($"Expected TextFieldValue, got {value?.GetType().Name}");
                break;
            case "Decimal":
                if (value is not MoneyFieldValue)
                    throw new ArgumentException($"Expected MoneyFieldValue, got {value?.GetType().Name}");
                break;
            case "DateTime":
                if (value is not DateFieldValue)
                    throw new ArgumentException($"Expected DateFieldValue, got {value?.GetType().Name}");
                break;
            case "Int":
                if (value is not IntegerFieldValue)
                    throw new ArgumentException($"Expected IntegerFieldValue, got {value?.GetType().Name}");
                break;
            case "Boolean":
                if (value is not BooleanFieldValue)
                    throw new ArgumentException($"Expected BooleanFieldValue, got {value?.GetType().Name}");
                break;
            case "Money":
                if (value is not MoneyFieldValue)
                    throw new ArgumentException($"Expected MoneyFieldValue, got {value?.GetType().Name}");
                break;
            case "Image":
                if (value is not ImageFieldValue)
                    throw new ArgumentException($"Expected ImageFieldValue, got {value?.GetType().Name}");
                break;
            case "ImageGallery":
                if (value is not ImageGalleryFieldValue)
                    throw new ArgumentException($"Expected ImageGalleryFieldValue, got {value?.GetType().Name}");
                break;
            default:
                throw new ArgumentException($"Unsupported DataType: {Name}");
        }
    }

    public override string ToString() => Name;
}