using Domain;
using System.Collections.Concurrent;
using System.Linq;

namespace DirectoryService.API.Storage;

public static class PositionStorage
{
    private static readonly ConcurrentDictionary<PositionId, Position> _positions = new();

    public static void Add(Position position)
    {
        if (position == null)
            throw new ArgumentNullException(nameof(position));

        if (!_positions.TryAdd(position.Id, position))
            throw new InvalidOperationException($"Position с Id {position.Id} уже существует");
    }

    public static Position? GetById(PositionId id)
    {
        return _positions.TryGetValue(id, out var position) && !position.LifeTime.IsArchived 
            ? position 
            : null;
    }

    public static IEnumerable<Position> GetAll()
    {
        return _positions.Values.Where(p => !p.LifeTime.IsArchived);
    }

    public static void Remove(PositionId id)
    {
        var position = GetById(id);
        if (position != null)
        {
            position.Archive();
        }
    }

    public static void HardRemove(PositionId id)
    {
        _positions.TryRemove(id, out _);
    }

    public static void Update(Position position)
    {
        _positions[position.Id] = position;
    }

    public static void InitializeStorage()
    {
        // Тестовые данные
        var position1 = Position.Create(
            PositionId.New(),
            PositionName.Create("Менеджер"),
            new InMemoryPositionRepository()
        );
        _positions.TryAdd(position1.Id, position1);

        var position2 = Position.Create(
            PositionId.New(),
            PositionName.Create("Разработчик"),
            new InMemoryPositionRepository()
        );
        _positions.TryAdd(position2.Id, position2);
    }
}