using System;
using System.Linq;
using Domain;

namespace DirectoryService.API.Storage;

public class InMemoryPositionRepository : IPositionRepository
{
    public Position? FindByName(PositionName name)
    {
        return PositionStorage.GetAll()
            .FirstOrDefault(p => p.Name == name);
    }

    public Position? GetById(PositionId id)
    {
        return PositionStorage.GetById(id);
    }

    public void Add(Position position)
    {
        PositionStorage.Add(position);
    }

    public void Update(Position position)
    {
        PositionStorage.Update(position);
    }
}

public interface IPositionRepository
{
    Position? FindByName(PositionName name);
    Position? GetById(PositionId id);
    void Add(Position position);
    void Update(Position position);
}