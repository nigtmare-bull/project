
using System.Collections.Generic;
namespace DepartmentManagement.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public List<Department> Children { get; set; } = new List<Department>();
        public List<Location> Location {get; set;} = new List<Location>();
    }
}
        
      