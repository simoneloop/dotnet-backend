using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Entities;
using Backend.Data;
using Microsoft.AspNetCore.Cors;
using Backend.Repositories;
using Backend.Interfaces;
using AutoMapper;
using Backend.Dto;

namespace Backend.Controllers{

    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {
        private readonly BackendDbContext _context;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        public EmployeeController(BackendDbContext context, IEmployeeRepository employeeRepository,IMapper mapper)
        {
            _context = context;
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }
        [HttpGet]
        
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees= _mapper.Map<List<EmployeeDto>>(_employeeRepository.GetAll());
            return Ok(_employeeRepository.GetAll());
        }

        [HttpPost]
        public IActionResult CreateEmployee([FromBody]EmployeeRequest employee)
        {
            
            
            return Ok(_employeeRepository.Add(employee));
        }

        [HttpPut]
        public IActionResult Update([FromBody] EmployeeRequest e){
            _employeeRepository.Update(e);
            return Ok(e);

        }
        /// <summary>
        /// Cancella un dipendente dal sistema.
        /// </summary>
        /// <remarks>
        /// Utilizza questo endpoint per cancellare un dipendente dal sistema utilizzando il suo identificatore univoco.
        /// </remarks>
        /// <param name="id">L'identificatore univoco del dipendente da cancellare.</param>
        /// <returns>Restituisce un messaggio di conferma se la cancellazione è avvenuta con successo.</returns>
        /// <response code="200">Cancellazione riuscita.</response>
        /// <response code="404">Dipendente non trovato.</response>
        /// <response code="500">Errore interno del server.</response>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id){
            _employeeRepository.Remove(id);
            return Ok();
        }
        [HttpGet("totalSalary")]
        public IActionResult TotalSalary()
        {
            var totalSalary = _context.Employees.Include(x => x.EmployeeDepartments)
                .GroupBy(e => 1)
                .Select(g => g.Sum(e => e.Salary))
                .FirstOrDefault();

            return Ok(totalSalary);
        }


        [HttpPost("{empId}/addJob/{jobId}")]
        public IActionResult addJob(int empId,int jobId){
            _employeeRepository.AddJob(empId,jobId);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult getEmployee(int id){
            return Ok(_employeeRepository.GetById(id));
        }

    }
}

