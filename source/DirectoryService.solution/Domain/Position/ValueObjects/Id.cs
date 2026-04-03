namespace Domain.Position.ValueObjects;


public sealed record Id(Guid Value)

{

    public static Id Create(Guid value)

    {
        if (value != Guid.Empty)
        {
            return new Id(value);
        }

        throw new ArgumentException("Идентификатор не может быть пустым.", nameof(value));
    }
}
