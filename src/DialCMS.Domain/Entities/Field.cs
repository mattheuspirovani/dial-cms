using DialCMS.Domain.Core;
using DialCMS.Domain.ValueObjects;

namespace DialCMS.Domain.Entities;

public class Field : Entity
{
    public string Name { get; private set; }
    public DataType DataType { get; private set; }

    public Field(string name, string dataType)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        DataType = ParseDataType(dataType);
    }

    public Field(string name, DataType dataType)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        DataType = dataType;
    }
    
    private DataType ParseDataType(string dataType)
    {
        return dataType.ToLower() switch
        {
            "string" => DataType.String,
            "money" => DataType.Money,
            "integer" => DataType.Integer,
            "boolean" => DataType.Boolean,
            "datetime" => DataType.DateTime,
            "image" => DataType.Image,
            "imagegallery" => DataType.ImageGallery,
            _ => throw new ArgumentException($"Invalid data type: {dataType}")
        };
    }
}