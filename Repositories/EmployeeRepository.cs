using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Backend.Data;
using Backend.Dto;
using Backend.Entities;
using Backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Backend.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly BackendDbContext _context;
        private readonly IJobRepository _jobRepository;

        private readonly IEmployeeDepartmentRepository _employeeDepartmentRepository;

        private readonly IDepartmentRepository _departmentRepository;

        private readonly IMapper _mapper;
        public EmployeeRepository(BackendDbContext context, IJobRepository jobRepository, IEmployeeDepartmentRepository employeeDepartmentRepository,IMapper mapper, IDepartmentRepository departmentRepository)
        {
            _context = context;
            _jobRepository = jobRepository; 
            _employeeDepartmentRepository = employeeDepartmentRepository;
            _mapper=mapper;
            _departmentRepository=departmentRepository;
        }
        public Employee? Add(EmployeeRequest employee)
        {
            Employee e=_mapper.Map<Employee>(employee);
            employee.DepartmentIds.ToList().ForEach(id=>{
                var d=_context.Departments.Where(d=>d.Id==id).FirstOrDefault();
                
                var employeeDepartment=new EmployeeDepartment(){
                    Employee=e,
                    Department=d
                };
                _context.Add(employeeDepartment);
            });
            _context.SaveChanges();              
            return e;
            

        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.Include("Jobs").Include(e=>e.EmployeeDepartments).ThenInclude(e=>e.Department).ToList();
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

        public void Update(EmployeeRequest e)
        {
            Employee eTMP=GetById(e.Id);
            if(eTMP!=null){
                eTMP.Name=e.Name;
                eTMP.Phone=e.Phone;
                eTMP.Email=e.Email;
                eTMP.Salary=e.Salary;
            }
            
            _context.Update(eTMP);
             _context.SaveChanges();
            
            _context.EmployeeDepartments.Where(x=>x.EmployeeId==e.Id).ToList().ForEach((dept)=>{
                _context.EmployeeDepartments.Remove(dept);
                
            });
            _context.SaveChanges();
            e.DepartmentIds.ForEach(id=>{
                EmployeeDepartment ed=new(){
                    Employee=eTMP,
                    Department=_departmentRepository.GetById(id),

                };
                _context.Add(ed);
            });
            
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