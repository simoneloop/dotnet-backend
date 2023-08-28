using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Data;
using Backend.Entities;
using Backend.Interfaces;

namespace Backend.Repositories
{
    public class JobRepository : IJobRepository
    {
        private readonly BackendDbContext _context;
        public JobRepository(BackendDbContext context){
            _context = context;
        }
        public Job Add(Job job)
        {
             _context.Jobs.Add(job);
             _context.SaveChanges();
             return job;    
            
        }

        public Job? GetById(int id)
        {
            return _context.Jobs.Where(job=>job.Id == id).FirstOrDefault();
        }
    }
}