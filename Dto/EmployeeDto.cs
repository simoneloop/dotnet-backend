using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Dto
{
    public class EmployeeDto
    {
        public int Id{get; set;}
        public string Name {get; set;}
        public string Email{get; set;}
        public long Phone{get; set;}

        public long Salary{get; set;}

        public ICollection<EmployeeDepartmentDto> EmployeeDepartmentsDto{get; set;}

    }
}