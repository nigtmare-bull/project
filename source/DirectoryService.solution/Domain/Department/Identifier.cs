namespace Domain.Department;

public class Identifier
{
    public Guid Value { get; }
    
    public Identifier(Guid value)
    {
        Value = value;
    }
    
    public static Identifier Create(Guid value)
    {
        return new Identifier(value);
    }
    public static Identifier Create(string value)
    {
        return new Identifier (Guid.Parse(value));
    }
    
    public override string ToString()
    {
        return Value.ToString();

    }
    
}



