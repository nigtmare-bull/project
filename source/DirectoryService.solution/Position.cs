// Position.cs
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

public sealed class Position
{
    private readonly PositionId _id;
    private PositionName _name;
    private readonly EntityLifeTime _lifeTime;

    private Position(PositionId id, PositionName name, EntityLifeTime  lifeTime)
    {
        _id = id;
        _name = name;
        _lifeTime = lifeTime;
    }

    public PositionId Id => _id;
    public PositionName Name => _name;
    public EntityLifeTime LifeTime => _lifeTime;

    // Фабричный метод с проверкой уникальности
    public static Position Create(
        PositionId id,
        PositionName name,
        IPositionNameUniquenessCriteria uniquenessCriteria)
    {
        if (!uniquenessCriteria.IsUnique(name))
            throw new InvalidOperationException(
                $"должность с названием \"{name.Value}\" уже существует в системе.");

        return new Position(id, name, EntityLifeTime.New());
    }

    // Изменение названия с проверками
    public void ChangeName(PositionName newName, IPositionNameUniquenessCriteria uniquenessCriteria)
    {
        // Проверка на архивированность
        if (_lifeTime.IsArchived)
            throw new InvalidOperationException("Нельзя изменять данные архивированной должности.");

        // Проверка уникальности (исключая текущую должность)
        if (!uniquenessCriteria.IsUnique(newName, _id))
            throw new InvalidOperationException(
                $"Должность с названием \"{newName.Value}\" уже существует в системе.");

        // Обновление данных
        _name = newName;
        _lifeTime.UpdateLastUpdatedDate();
    }

    // Архивация
    public void Archive()
    {
        _lifeTime.Archive();
    }

    // Активация
    public void Activate()
    {
        _lifeTime.Activate();
        _lifeTime.UpdateLastUpdatedDate();
    }
}




