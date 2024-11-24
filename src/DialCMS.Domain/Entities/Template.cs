using DialCMS.Domain.Core;
using DialCMS.Domain.ValueObjects;

namespace DialCMS.Domain.Entities;

public class Template(string name, List<TemplateField> fields) : Entity
{
    public string Name { get; private set; } = name;
    public List<TemplateField> Fields { get; private set; } = fields;
}