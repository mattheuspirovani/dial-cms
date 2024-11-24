using DialCMS.Domain.Core;
using DialCMS.Domain.ValueObjects;

namespace DialCMS.Domain.Entities;

public class Content(List<ContentField> fields, Template template) : Entity
{
    public Guid TemplateId { get; private set; }
    public Template Template { get; private set; } = template;
    public List<ContentField> Fields { get; private set; } = fields;
    public ContentStatus Status { get; set; }
    public Content(Template template) : this([], template)
    {
    }
}

public enum ContentStatus
{
    Draft,
    Published,
    Unpublished,
    Deleted
}