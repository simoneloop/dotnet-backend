using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Entities;
using Backend.Interfaces;

namespace Backend.Repositories
{
    public class EmployeeDepartmentRepository : IEmployeeDepartmentRepository
    {
        private readonly BackendDbContext _context;
        public EmployeeDepartmentRepository(BackendDbContext context){
            _context = context;
        }
        public EmployeeDepartment Add(int employeeId,int departmentId)
        {   
            var employee = _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();
            var Department=_context.Departments.Where(d=>d.Id==departmentId).FirstOrDefault();
              
            EmployeeDepartment edTmp = new()
            {
                Employee = employee,
                Department = Department
            };
            
            _context.EmployeeDepartments.Add(edTmp);
            _context.SaveChanges();
            return edTmp;
            
            
        }
        public ICollection<EmployeeDepartment> GetAll(){
            return _context.EmployeeDepartments.OrderBy(x => x.Department.Name).ToList();
        }
    }
}