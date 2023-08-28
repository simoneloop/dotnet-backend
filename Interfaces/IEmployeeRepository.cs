using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Entities;

namespace Backend.Interfaces
{
    public interface IEmployeeRepository
    {
        Employee GetById(int id);
        IEnumerable<Employee> GetAll();

        Employee? Add(Employee employee);
        void Update(Employee employee);

        void Remove(int id);

        void AddJob(int id, int jobId);
    }
}