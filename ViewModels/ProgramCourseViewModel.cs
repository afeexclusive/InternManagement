using EmployeeManagment.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static EmployeeManagment.models.Selector;

namespace EmployeeManagment.ViewModels
{
    public class ProgramCourseViewModel
    {
       
        public int AcadaProgId { get; set; }
        public List<string> AcadaCourseId { get; set; }
        public double Cost { get; set; }

        [Display(Name ="Program Name")]
        public ProgrammeNames ProgramName { get; set; }
        public ProgramDuration Duration { get; set; }

        [Display(Name = "Course Name")]
        public CourseName Course_Name { get; set; }
        public CourseLevel Level { get; set; }

        [Display(Name = "Cost")]
        public double CourseCost { get; set; }
        public List<AcademyProgram> acadaprog { get; set; }

        public List<Courses> acadacourses { get; set; }

        public List<ProgrammeCourse> CourseInProg { get; set; }
    }
}
