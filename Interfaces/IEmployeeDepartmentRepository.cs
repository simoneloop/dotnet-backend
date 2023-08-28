using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Entities;

namespace Backend.Interfaces
{
    public interface IEmployeeDepartmentRepository
    {
        EmployeeDepartment Add(int employeeId,int departmentId);
        ICollection<EmployeeDepartment> GetAll();
    }
}