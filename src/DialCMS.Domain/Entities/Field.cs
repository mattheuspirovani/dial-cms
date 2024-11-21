using DialCMS.Domain.ValueObjects;

namespace DialCMS.Domain.Entities;

public class Field(string name, DataType dataType)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = name ?? throw new ArgumentNullException(nameof(name));
    public DataType DataType { get; private set; } = dataType ?? throw new ArgumentNullException(nameof(dataType));
}