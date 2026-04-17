using System;

namespace Domain;

public sealed class EntityLifeTime
{
    public DateTime CreatedAt { get; }
    public DateTime? LastUpdatedAt { get; private set; }
    public DateTime? ArchivedAt { get; private set; }
    public bool IsArchived => ArchivedAt.HasValue;

    private EntityLifeTime(DateTime createdAt)
    {
        CreatedAt = createdAt;
    }

    public static EntityLifeTime New() => new(DateTime.UtcNow);

    public void Archive()
    {
        if (IsArchived)
            return;
        ArchivedAt = DateTime.UtcNow;
    }

    public void Activate()
    {
        ArchivedAt = null;
    }

    public void UpdateLastUpdatedDate()
    {
        LastUpdatedAt = DateTime.UtcNow;
    }
}