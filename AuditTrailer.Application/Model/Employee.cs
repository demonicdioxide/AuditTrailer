using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuditTrailer.Application.Model
{
    public class Employee
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<int> HoursWorked { get; set; } 
    }
}
