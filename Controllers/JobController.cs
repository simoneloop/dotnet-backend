using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Entities;
using Backend.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JobController : ControllerBase
    {
        private readonly BackendDbContext _context;
        private readonly IJobRepository jobRepository;

        public JobController(BackendDbContext context, IJobRepository jobRepository ){
            _context=context;
            this.jobRepository=jobRepository;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Job j){
            Job jTmp=jobRepository.Add(j);
            return Ok(jTmp);
            

        }
    }
}