namespace DialCMS.Domain.Entities;

public class Content
{
    public Guid Id { get; private set; }
    public Guid ContentTypeId { get; private set; }
    private readonly List<Field> _fields = new();
    private readonly Dictionary<string, object?> _values = new();

    public IReadOnlyCollection<Field> Fields => _fields.AsReadOnly();
    public IReadOnlyDictionary<string, object?> Values => _values;

    public Content(ContentType contentType)
    {
        if (contentType == null)
            throw new ArgumentNullException(nameof(contentType));

        ContentTypeId = contentType.Id;

        // Copiar os campos do ContentType para o Content
        foreach (var field in contentType.Fields)
        {
            _fields.Add(new Field(field.Name, field.DataType));
            _values[field.Name] = null; // Inicializar valores com null
        }
    }

    public void SetValue(string fieldName, object value)
    {
        var field = _fields.FirstOrDefault(f => f.Name == fieldName);
        if (field == null)
            throw new ArgumentException($"Field '{fieldName}' does not exist.");

        // Validar o valor com base no DataType
        field.DataType.Validate(value);

        // Atribuir o valor
        _values[fieldName] = value;
    }

    public object GetValue(string fieldName)
    {
        if (!_values.ContainsKey(fieldName))
            throw new ArgumentException($"Field '{fieldName}' does not exist.");
        return _values[fieldName];
    }
}