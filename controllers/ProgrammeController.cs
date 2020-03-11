using EmployeeManagment.models;
using EmployeeManagment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.controllers
{
    [Route("[controller]/[action]")]
    public class ProgrammeController: Controller 
    {
        private readonly IProgrammes _programmes;

        public ProgrammeController(IProgrammes programmes)
        {
            this._programmes = programmes;
        }
        
        [HttpPost]
        public IActionResult CreateProgram(ProgramCourseViewModel model)
        {
            AcademyProgram academyProgram = new AcademyProgram()
            {
                ProgramName = model.ProgramName,
                Duration = model.Duration,
                Cost = model.Cost
            };
            _programmes.AddProgramme(academyProgram);
            return RedirectToAction("ListProgram");
        }

        [HttpPost]
        public IActionResult CreateCourse(ProgramCourseViewModel model)
        {
            Courses course = new Courses()
            {
               Course_Name = model.Course_Name,
               Cost= model.CourseCost,
              
            };
            _programmes.AddCourse(course);
            return RedirectToAction("ListProgram");
        }


        [HttpGet]
        public ViewResult ListProgram()
        {
            List<AcademyProgram> academyPrograms = _programmes.GetProgrammes().ToList();
            List<Courses> courses = _programmes.GetCourses().ToList();
            List<ProgrammeCourse> courseInProgram = _programmes.GetProgCourses().ToList();
            ProgramCourseViewModel pcvm = new ProgramCourseViewModel
            {
                acadacourses = courses,
                acadaprog = academyPrograms,
                CourseInProg = courseInProgram
            };
            return View(pcvm);
        }

        [HttpPost]
        public IActionResult AllocateCourses(ProgramCourseViewModel model)
        {
            var Selected = model.AcadaCourseId;
            int modelProgramId = model.AcadaProgId;
            foreach (var item in Selected)
            {
                ProgrammeCourse pc = new ProgrammeCourse()
                {
                    AcademyProgramId = modelProgramId,
                    CoursesId = int.Parse(item)
                };
                _programmes.AddProgCourses(pc);
            }
            return RedirectToAction("ListProgram");
        }
    }
}
