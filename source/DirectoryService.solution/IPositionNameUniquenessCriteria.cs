// IPositionNameUniquenessCriteria.cs
public interface IPositionNameUniquenessCriteria
{
    /// <summary>
    /// Проверяет, является ли название уникальным в системе.
    /// </summary>
    /// <param name="name">Название для проверки</param>
    /// <param name="excludePositionId">ID должности, которую нужно исключить из проверки (для обновления)</param>
    bool IsUnique(PositionName name, PositionId? excludePositionId = null);
}
