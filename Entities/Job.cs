using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Entities
{
    public class Job
    {
        public int Id{  get; set; }

        public string Name{ get; set; }

        //ManyToOne
        public int EmployeeId{get; set; }//è richiesta la foreign key
        public Employee Employee{ get; set; }//è richiesto anche il riferimento
    }
}