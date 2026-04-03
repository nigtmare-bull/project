using Domain.LocationsContext;
using Domain.Position.ValueObjects;

namespace Domain.Department;


public record Department(
    Id Id,
    Id ParentId,
    Name Name,
    Identifier Identifier,
    DepartmentPath Path,
    Depth Depth,
    EntityLifeTime LifeTime)
{
    
    public static Department Create(
        Id id,
        Id parentId,
        Name name,
        Identifier identifier,
        DepartmentPath path,
        Depth depth,
        EntityLifeTime lifeTime)
    {
           return new Department(id, parentId, name, identifier, path, depth, lifeTime);
    }
    public static Department Create(
        Id id,
        Id parentId,
        Name name,
        Identifier identifier,
        DepartmentPath path,
        Depth depth)
    {
        
    return new Department(id, parentId, name, identifier, path, depth,  EntityLifeTime.Create());

    }
    
}


