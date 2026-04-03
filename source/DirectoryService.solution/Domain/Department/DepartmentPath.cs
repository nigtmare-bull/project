namespace Domain.Department;

public class DepartmentPath
{
    public static DepartmentPath Create(string value)
    {
        return new DepartmentPath(value);
    }

   private DepartmentPath(string value)
    {
        Value = value;
        
    }
    public string Value { get; private set; }
    
    public override string ToString()
    {
        return Value;
    }
    
    public static implicit operator string(DepartmentPath path)
    {
        return path.Value;
    }
    public static implicit operator DepartmentPath(string path)
     {
        return new DepartmentPath (path);
     }  
}




        
           
