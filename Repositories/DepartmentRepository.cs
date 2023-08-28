using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Entities;
using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly BackendDbContext _context;

        public DepartmentRepository(BackendDbContext context){
            _context = context;
        }
        public Department Add(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return department;
        }

        public ICollection<Department> GetAll()
        {
            return _context.Departments.Include("EmployeeDepartments").OrderBy(p=>p.Name).ToList();
        }

        public Department GetById(int id)
        {
            return _context.Departments.Where(department => department.Id==id).FirstOrDefault();
        }
    }
}