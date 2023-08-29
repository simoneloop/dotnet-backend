using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Interfaces;
using Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeDepartmentController : ControllerBase
    {
        private readonly IEmployeeDepartmentRepository _employeeDepartmentRepository;
        public EmployeeDepartmentController(IEmployeeDepartmentRepository  employeeDepartmentRepository){
            _employeeDepartmentRepository = employeeDepartmentRepository;
        }
        [HttpPost("{employeeId}/{departmentId}")]
        public IActionResult Add(int employeeId, int departmentId){
            return Ok(_employeeDepartmentRepository.Add(employeeId,departmentId));
        }
        [HttpGet]
        public IActionResult getAll(){
            return Ok(_employeeDepartmentRepository.GetAll());
        }
    }
}