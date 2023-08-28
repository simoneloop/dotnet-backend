using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Entities;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        public readonly IDepartmentRepository _departmentRepository;
        public DepartmentController(IDepartmentRepository departmentRepository){
            _departmentRepository = departmentRepository;
        }

        [HttpPost]
        public IActionResult createDepartment([FromBody]Department d){
            return Ok(_departmentRepository.Add(d));
        }
        [HttpGet]
        public IActionResult getAll(){
            return Ok(_departmentRepository.GetAll());
        }
        
    }
}