using System;
using System.ComponentModel;

namespace Backend.Entities
{
    public class Employee{

        public int Id{get; set;}
        public string Name {get; set;}
        public string Email{get; set;}
        public long Phone{get; set;}

        public long Salary{get; set;}



        //OneToMany
        public ICollection<Job>? Jobs{get; set;}
        
        //ManyToMany
        public ICollection<EmployeeDepartment>? EmployeeDepartments{get; set;}


        
    }
}