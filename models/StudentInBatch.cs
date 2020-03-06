using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EmployeeManagment.models.Selector;

namespace EmployeeManagment.models
{
    public class StudentInBatch
    {
        public int EmployeeId { get; set; }
        public Employee Student { get; set; }
        public int BatchesId { get; set; }
        public Batches Batch { get; set; }
        public Status StdStatus { get; set; }
        public Grade StdGrade { get; set; }
    }
}
