using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static EmployeeManagment.models.Selector;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagment.models
{
    public class AcademyProgram
    {
        public int Id { get; set; }
        public Guid ProgSystemId { get; set; }
        public double Cost { get; set; }
        public ProgrammeNames ProgramName { get; set; }
        public List<Batches> Batch { get; set; }
        public ProgramDuration Duration { get; set; }
        public List<ProgramCourses> ProgrammeCourses { get; set; }


    }
}