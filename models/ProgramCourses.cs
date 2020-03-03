using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.models
{
    public class ProgramCourses
    {
        public int AcademyProgramId { get; set; }
        public AcademyProgram Programme { get; set; }
        public int CourseId { get; set; }
        public Courses Course { get; set; }
    }
}
