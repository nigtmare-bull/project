namespace Domain.Department;

public class Depth
{
    public int Value { get; }
    
    private Depth(int value)
    {
        Value = value;
    }
    
    public static Depth Create(int value)
    {
        return new Depth(value);
    }
    
    public override string ToString()
    {
        return Value.ToString();
    }
    
    public static Depth Create(string value)
    {
        return new Depth(int.Parse(value));
    }
}