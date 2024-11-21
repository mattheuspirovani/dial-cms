namespace DialCMS.Domain.Entities;

public class ContentType(string name)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = name ?? throw new ArgumentNullException(nameof(name));
    public List<Field> Fields { get; private set; } = [];

    public void AddField(Field field)
    {
        ArgumentNullException.ThrowIfNull(field);
        Fields.Add(field);
    }
}