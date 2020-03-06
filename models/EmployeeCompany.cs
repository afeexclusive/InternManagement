using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.models
{
    public class EmployeeCompany
    {
        //public Guid EmploId { get; set; }

        public int? CompanyId { get; set; }
        public Company Company { get; set; }

        public int? EmployeeId { get; set; }
        public Employee Employee { get; set; }

        //public DateTime StartDate { get; set; }
        //public DateTime EndDate { get; set; }
    }
}
