using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        //ManyToMany
        public ICollection<EmployeeDepartment> EmployeeDepartments { get; set;}
    }
}