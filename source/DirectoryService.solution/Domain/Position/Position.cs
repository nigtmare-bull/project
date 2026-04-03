using Domain.LocationsContext;
using Domain.Position.ValueObjects;

namespace Domain.Position;

/// <summary>
/// Represents a position entity with an identifier, name, description, and lifetime.
/// </summary>
public class Position
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Position"/> class.
    /// </summary>
    /// <param name="id">The unique identifier for the position.</param>
    /// <param name="name">The name of the position.</param>
    /// <param name="Description">A description of the position.</param>
    /// <param name="lifeTime">The lifetime of the position entity.</param>
#pragma warning disable CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Рассмотрите возможность добавления модификатора "required" или объявления значения, допускающего значение NULL.
    public Position(Id id, Name name, Description Description, EntityLifeTime lifeTime)
#pragma warning restore CS8618 // Поле, не допускающее значения NULL, должно содержать значение, отличное от NULL, при выходе из конструктора. Рассмотрите возможность добавления модификатора "required" или объявления значения, допускающего значение NULL.
    {
        Id = id;
        Name = name;
        description = Description;
        LifeTime = lifeTime;
    }

    /// <summary>
    /// Gets the unique identifier for the position.
    /// </summary>
    public Id Id { get; }

    /// <summary>
    /// Gets the name of the position.
    /// </summary>
    public Name Name { get; }

    /// <summary>
    /// Gets the description of the position.
    /// </summary>
    public Description description { get; }

    /// <summary>
    /// Gets the lifetime of the position entity.
    /// </summary>
    public EntityLifeTime LifeTime { get; }

#pragma warning disable SA1600 // Elements should be documented
    public class Description
#pragma warning restore SA1600 // Elements should be documented
    {
    
    }
}
