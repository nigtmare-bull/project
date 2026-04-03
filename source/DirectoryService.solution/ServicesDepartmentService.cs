using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Data.Common;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using DepartmentManagement.Models;

namespace DepartmentManagement.Services
{
    public class DepartmentService
    {
        private readonly List<Department> _departments = new List<Department>();
        private readonly List<Location> _locations = new List<Location>();
        private int _nextDepartmentId = 1;
        private int _nextLocationId = 1;

    public void AddDepartment(string name, int? parentId = null);

    }
}
    