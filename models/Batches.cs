using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EmployeeManagment.models.Selector;

namespace EmployeeManagment.models
{
    public class Batches
    {
        public int Id { get; set; }
        public int AcademyProgramId { get; set; }
        public Batch Name { get; set; }
        public string Supervisor { get; set; }
        public BatchYear Year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public AcademyProgram Programme { get; set; }
        public List<StudentInBatch> StudentsIn { get; set; }
    }
}
