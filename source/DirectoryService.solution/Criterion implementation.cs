namespace Domain;

public class PositionNameUniquenessCriteria : IPositionNameUniquenessCriteria
{
    private readonly IPositionRepository _repository;

    public PositionNameUniquenessCriteria(IPositionRepository repository)
    {
        _repository = repository;
    }

    public bool IsUnique(PositionName name, PositionId? excludePositionId = null)
    {
        var existing = _repository.FindByName(name);
        return existing is null ||
            (excludePositionId.HasValue && existing.Id == excludePositionId.Value);
    }
}

public interface IPositionRepository
{
    Position? FindByName(PositionName name);
    Position? GetById(PositionId id);
    void Add(Position position);
    void Update(Position position);
}