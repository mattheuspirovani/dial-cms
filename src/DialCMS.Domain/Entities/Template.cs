using DialCMS.Domain.Core;
using DialCMS.Domain.ValueObjects;

namespace DialCMS.Domain.Entities;

public class Template(string name, List<TemplateField> fields, TemplateStatus status = TemplateStatus.Draft) : Entity
{
    public string Name { get; private set; } = name;
    public TemplateStatus Status { get; private set; } = status;
    public List<TemplateField> Fields { get; private set; } = fields;

    public void Update(string name, List<TemplateField> fields, TemplateStatus status)
    {
        UpdateName(name);
        UpdateFields(fields);
        UpdateStatus(status);
        UpdateModifiedAt();
    }
    
    public void UpdateName(string name)
    {
        Name = name;
    }
    public void AddField(TemplateField field)
    {
        Fields.Add(field);
    }
    public void UpdateStatus(TemplateStatus status)
    {
        Status = status;
    }
    public void UpdateFields(List<TemplateField> fields)
    {
        if (fields.Count == 0)
            throw new ArgumentException("No fields have been provided");
        
        Fields = fields;
    }
}

public enum TemplateStatus
{
    Draft,
    Published,
    Archived
}