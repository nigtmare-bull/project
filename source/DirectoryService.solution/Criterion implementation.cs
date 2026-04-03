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
public class PositionService
{
    private readonly IPositionRepository _repository;
    private readonly IPositionNameUniquenessCriteria _uniquenessCriteria;
    public PositionService(
        IPositionRepository repository,
        IPositionNameUniquenessCriteria uniquenessCriteria)
    {
        _repository = repository;
        _uniquenessCriteria = uniquenessCriteria;
    }
    public void CreatePosition(string name)
    {
        var position = Position.Create(
            PositionId.New(),
            PositionName.Create(name),
            _uniquenessCriteria);

        _repository.Add(position);
    }
    public void UpdatePositionName(PositionId id, string newName)
    {
        var position = _repository.GetById(id)
            ?? throw new InvalidOperationException("Должности не найдены.");

        position.ChangeName(PositionName.Create(newName), _uniquenessCriteria);
        _repository.Update(position);
    }
}
