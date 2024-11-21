namespace DialCMS.Domain.Core;

public abstract class Entity
{
    public Guid Id { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime ModifiedAt { get; private set; }
    public DateTime? DeletedAt { get; private set; }

    protected Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        ModifiedAt = CreatedAt;
    }

    protected void MarkAsDeleted()
    {
        DeletedAt = DateTime.UtcNow;
        UpdateModifiedAt();
    }
    
    protected void UnmarkAsDeleted()
    {
        if (DeletedAt == null)
            throw new InvalidOperationException("Entity is not marked as deleted.");

        DeletedAt = null;
        UpdateModifiedAt();
    }

    protected virtual void UpdateModifiedAt()
    {
        ModifiedAt = DateTime.UtcNow;
    }
}