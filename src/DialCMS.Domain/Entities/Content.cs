using DialCMS.Domain.Core;

namespace DialCMS.Domain.Entities;

public class Content : Entity, AggregateRoot
{
    public Guid ContentTypeId { get; private set; }
    private readonly List<Field> _fields = new();
    private readonly Dictionary<string, ValueObject?> _values = new();

    public IReadOnlyCollection<Field> Fields => _fields.AsReadOnly();
    public IReadOnlyDictionary<string, ValueObject?> Values => _values;
    public ContentStatus Status { get; private set; } = ContentStatus.Draft;

    public Content(ContentType contentType)
    {
        if (contentType == null)
            throw new ArgumentNullException(nameof(contentType));

        ContentTypeId = contentType.Id;

        foreach (var field in contentType.Fields)
        {
            _fields.Add(new Field(field.Name, field.DataType));
            _values[field.Name] = null;
        }
    }

    public void SetValue(string fieldName, ValueObject value)
    {
        var field = _fields.FirstOrDefault(f => f.Name == fieldName);
        if (field == null)
            throw new ArgumentException($"Field '{fieldName}' does not exist.");

        field.DataType.Validate(value);

        _values[fieldName] = value;
        UpdateModifiedAt();
    }

    public object GetValue(string fieldName)
    {
        if (!_values.ContainsKey(fieldName))
            throw new ArgumentException($"Field '{fieldName}' does not exist.");
        return _values[fieldName];
    }

    public void AddField(Field field)
    {
        if (_fields.Any(f => f.Name == field.Name))
            throw new InvalidOperationException($"Field '{field.Name}' already exists.");

        _fields.Add(field);
        _values[field.Name] = null;
        UpdateModifiedAt();
    }

    public void RemoveField(string fieldName)
    {
        var field = _fields.FirstOrDefault(f => f.Name == fieldName);
        if (field == null)
            throw new ArgumentException($"Field '{fieldName}' does not exist.");

        _fields.Remove(field);
        _values.Remove(fieldName);
        UpdateModifiedAt();
    }

    public void Publish()
    {
        if (Status == ContentStatus.Deleted)
            throw new InvalidOperationException("Cannot publish a deleted content.");

        Status = ContentStatus.Published;
        UpdateModifiedAt();
    }

    public void Delete()
    {
        if (Status == ContentStatus.Deleted)
            throw new InvalidOperationException("Content is already deleted.");

        Status = ContentStatus.Deleted;
        MarkAsDeleted();
        UpdateModifiedAt();
    }

    public void RestoreDraft()
    {
        if (Status != ContentStatus.Deleted)
            throw new InvalidOperationException("Only deleted content can be restored to draft.");

        Status = ContentStatus.Draft;
        UnmarkAsDeleted();
        UpdateModifiedAt();
    }
}

public enum ContentStatus
{
    Draft,
    Published,
    Deleted
}