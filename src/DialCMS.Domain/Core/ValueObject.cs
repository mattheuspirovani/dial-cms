namespace DialCMS.Domain.Core;

public interface ValueObject
{
    bool Validate();
    static void ValidateOptions(Dictionary<string, object> options) => throw new NotImplementedException();
    static IEnumerable<OptionMetadata> GetOptionMetadata() => throw new NotImplementedException();
}

public class OptionMetadata(string name, Type dataType, string description)
{
    public string Name { get; set; } = name;
    public Type DataType { get; set; } = dataType;
    public string Description { get; set; } = description;
}