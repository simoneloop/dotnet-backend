using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class EmployeeDepartment
    {
        
        public int EmployeeId{get; set;}
        public int DepartmentId{get; set;}

        [JsonIgnore]
        public Employee Employee{get; set;}

        public Department Department{get; set;}


        
    }
}