using System;

namespace Domain;

public sealed class Position
{
    private readonly PositionId _id;
    private PositionName _name;
    private readonly EntityLifeTime _lifeTime;

    private Position(PositionId id, PositionName name, EntityLifeTime lifeTime)
    {
        _id = id;
        _name = name;
        _lifeTime = lifeTime;
    }

    public PositionId Id => _id;
    public PositionName Name => _name;
    public EntityLifeTime LifeTime => _lifeTime;

    public static Position Create(
        PositionId id,
        PositionName name,
        IPositionNameUniquenessCriteria uniquenessCriteria)
    {
        if (!uniquenessCriteria.IsUnique(name))
            throw new InvalidOperationException(
                $"Должность с названием \"{name.Value}\" уже существует в системе.");

        return new Position(id, name, EntityLifeTime.New());
    }

    public void ChangeName(PositionName newName, IPositionNameUniquenessCriteria uniquenessCriteria)
    {
        if (_lifeTime.IsArchived)
            throw new InvalidOperationException("Нельзя изменять данные архивированной должности.");

        if (!uniquenessCriteria.IsUnique(newName, _id))
            throw new InvalidOperationException(
                $"Должность с названием \"{newName.Value}\" уже существует в системе.");

        _name = newName;
        _lifeTime.UpdateLastUpdatedDate();
    }

    public void Archive()
    {
        _lifeTime.Archive();
    }

    public void Activate()
    {
        _lifeTime.Activate();
        _lifeTime.UpdateLastUpdatedDate();
    }
}