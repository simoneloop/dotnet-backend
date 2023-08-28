using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Entities;
using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly BackendDbContext _context;
        private readonly IJobRepository _jobRepository;

        public EmployeeRepository(BackendDbContext context, IJobRepository jobRepository)
        {
            _context = context;
            _jobRepository = jobRepository; 
        }
        public Employee? Add(Employee employee)
        {
            try{
                
                employee.Jobs = new Collection<Job>();
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return employee;
            }catch(Exception e){
                Console.WriteLine(e.Message);
                return null;
            }
            

        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.Include("Jobs").Include("EmployeeDepartments").ToList();
        }

        public Employee? GetById(int id)
        {
            return _context.Employees.Include("Jobs").Include("EmployeeDepartments").Where(x => x.Id==id).FirstOrDefault();
        }

        public void Remove(int id)
        {
            Employee e=GetById(id);
            if(e!=null){
                _context.Employees.Remove( e); 
            } 
            _context.SaveChanges();  
            
        }

        public void Update(Employee e)
        {
            Employee eTMP=GetById(e.Id);
            if(eTMP!=null){
                eTMP.Name=e.Name;
                eTMP.Phone=e.Phone;
                eTMP.Email=e.Email;
                eTMP.EmployeeDepartments=e.EmployeeDepartments;
                eTMP.Salary=e.Salary;
            }
            _context.SaveChanges();
            
        }

        public void AddJob(int id,int jobId){
            Job j=_jobRepository.GetById(jobId);
            if(j!=null){
                Employee e=_context.Employees.Where(x=>x.Id==id).FirstOrDefault();
                if(e!=null){
                    e.Jobs.Add(j);
                }
                else{
                    Console.WriteLine("no emp found");
                }
            }
            else{
                    Console.WriteLine("no job found");
                }
            
            _context.SaveChanges();
        }

    }
}