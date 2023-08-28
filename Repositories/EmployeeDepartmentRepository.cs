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
            Employee eTmp=_context.Employees.Where(x => x.Id == employeeId).FirstOrDefault();
            Department dTmp=_context.Departments.Where(x => x.Id==departmentId).FirstOrDefault();
            if(eTmp!=null && dTmp!=null){
                EmployeeDepartment edTmp=new();
                edTmp.EmployeeId = employeeId;
                edTmp.DepartmentId = departmentId;
                edTmp.Employee=eTmp;
                edTmp.Department=dTmp;
                _context.EmployeeDepartments.Add(edTmp);
                _context.SaveChanges(); 
                return edTmp;
            }
            return null;
            
            
        }
        public ICollection<EmployeeDepartment> GetAll(){
            return _context.EmployeeDepartments.OrderBy(x => x.Department.Name).ToList();
        }
    }
}