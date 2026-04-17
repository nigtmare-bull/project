namespace Domain;

public interface IPositionNameUniquenessCriteria
{
    bool IsUnique(PositionName name, PositionId? excludePositionId = null);
}