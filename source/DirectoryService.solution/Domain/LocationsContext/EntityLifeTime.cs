namespace Domain.LocationsContext;
public class EntityLifeTime
{   
    public DateTime CreatedAt {get;}
    public DateTime UpdatedAt { get;}
    public DateTime? DeletedAt { get;}
    public bool IsDeleted { get; }
    
    private EntityLifeTime(DateTime createdAt, DateTime updatedAt, DateTime? deletedAt, bool isDeleted)
    {
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
        DeletedAt = deletedAt;
        IsDeleted = isDeleted;

    }
    
    public static EntityLifeTime Create(DateTime createdAt, DateTime updatedAt, DateTime? deletedAt, bool isDeleted)
    {
        return new EntityLifeTime(createdAt, updatedAt, deletedAt, isDeleted);
    }
    
    public EntityLifeTime Update()
    {
        return new EntityLifeTime( CreatedAt, DateTime.UtcNow, DeletedAt, IsDeleted );
        
    }
    
    public EntityLifeTime Delete()
    {
        return new EntityLifeTime( CreatedAt, UpdatedAt, DateTime.UtcNow, true );
    }

    internal static EntityLifeTime Create()
    {
        throw new NotImplementedException();
    }
}
