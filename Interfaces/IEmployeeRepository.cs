using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Dto;
using Backend.Entities;

namespace Backend.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee GetById(int id);
        IEnumerable<Employee> GetAll();

        Employee? Add(EmployeeRequest employee);
        void Update(EmployeeRequest employee);

        void Remove(int id);

        void AddJob(int id, int jobId);
    }
}