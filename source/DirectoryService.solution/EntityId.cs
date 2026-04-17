using System;

namespace Domain;

public abstract class EntityId : IEquatable<EntityId>
{
    public Guid Value { get; }
    protected EntityId(Guid value) => Value = value;

    public static bool operator ==(EntityId? left, EntityId? right) =>
        Equals(left, right);

    public static bool operator !=(EntityId? left, EntityId? right) =>
        !Equals(left, right);

    public bool Equals(EntityId? other) =>
        other is not null && Value == other.Value;

    public override bool Equals(object? obj) =>
        obj is EntityId other && Equals(other);

    public override int GetHashCode() => Value.GetHashCode();

    public override string ToString() => Value.ToString();
}

public sealed class PositionId : EntityId
{
    public PositionId(Guid value) : base(value) { }
    public static PositionId New() => new(Guid.NewGuid());
}

public sealed class PositionName : IEquatable<PositionName>
{
    public string Value { get; }
    private PositionName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Название должности не может быть пустым.", nameof(value));

        if (value.Length > 100)
            throw new ArgumentException("Название должности не может превышать более ста символов.", nameof(value));

        Value = value.Trim();
    }

    public static PositionName Create(string value) => new(value);

    public bool Equals(PositionName? other) =>
        other is not null && Value.Equals(other.Value, StringComparison.OrdinalIgnoreCase);

    public override bool Equals(object? obj) => obj is PositionName other && Equals(other);

    public override int GetHashCode() => Value.ToLowerInvariant().GetHashCode();

    public static bool operator ==(PositionName? left, PositionName? right) =>
        Equals(left, right);

    public static bool operator !=(PositionName? left, PositionName? right) =>
        !Equals(left, right);

    public override string ToString() => Value;
}