using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Entities;

namespace Backend.Interfaces
{
    public interface IDepartmentRepository
    {
        Department GetById(int id);

        ICollection<Department> GetAll();

        Department Add(Department department);
    }
}