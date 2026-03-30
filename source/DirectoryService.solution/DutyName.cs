namespace VolunteerPetSystem.Domain.Entities;

/// <summary>
/// Название должности (значение объекта).
/// </summary>
private DutyName(Guid Value)
{  }
    /// <summary>
    /// Инициализирует новое название должности.
    /// Проверяет, что значение не null и не пусто.
    /// </summary>
    /// <param name="Value">Текст названия.</param>
    /// <exception cref="ArgumentException">Если значение null, пустое или состоит только из пробелов.</exception>
    private DutyName Value
    {
        get
        {
            if (string.IsNullOrWhiteSpace(Value))
                throw new ArgumentException("Название должности не может быть пустым.", nameof(Value));
            return this;
}
    }
    

  
