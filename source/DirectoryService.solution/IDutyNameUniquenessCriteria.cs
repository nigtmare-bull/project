namespace VolunteerPetSystem.Domain.Interfaces;

/// <summary>
/// Критерий проверки уникальности названия должности в системе.
/// </summary>
public interface IDutyNameUniquenessCriteria
{
    /// <summary>
    /// Проверяет, удовлетворяет ли название критерию уникальности.
    /// </summary>
    /// <param name="name">Проверяемое название.</param>
    /// <returns><c>true</c>, если название уникально; иначе — <c>false</c>.</returns>
    bool IsSatisfiedBy(DutyName name);
}
