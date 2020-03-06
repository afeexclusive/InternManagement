using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EmployeeManagment.models.Selector;

namespace EmployeeManagment.models
{
    public class Courses
    {
        public int CoursesId { get; set; }
        public CourseName Course_Name { get; set; }
        public CourseLevel Level { get; set; }
        public double Cost { get; set; }
        public List<ProgramCourses> Programmes { get; set; }
    }
}
