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
    public class StudentBatchController: Controller
    {
        private readonly IProgrammes _programmes;
        private readonly IEmployeeReprository _students;

        public StudentBatchController(IProgrammes programmes, IEmployeeReprository students)
        {
            this._programmes = programmes;
            this._students = students;
        }
        
        [HttpGet]
        public ViewResult ListBatch()
        {
            List<Batches> batches = _programmes.GetABatch().ToList();
            List<Employee> studentList = _students.GetEmployees().ToList();
            List<StudentInBatch> studentbatchList = _programmes.GetAllStudentInBatch().ToList();



            StudentBatchViewModel sbvm = new StudentBatchViewModel
            {
                Batches = batches,
                Students = studentList,
                AssignedStudents = studentbatchList
            };
            return View(sbvm);
        }

        [Route("{id}")]
        [HttpGet]
        public ViewResult CreateBatch(int id)
        {

            BatchViewModel bvm = new BatchViewModel
            {
                 AcadaProgramId = id,
            };
            return View(bvm);
        }

        [Route("{id?}")]
        [HttpPost]
        public IActionResult CreateBatch(BatchViewModel model)
        {
            Batches batches = new Batches()
            {
                AcademyProgramId = model.AcadaProgramId,
                Name = model.Name,
                Supervisor = model.Supervisor,
                Year = model.Year,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
            };
            _programmes.AddBatch(batches);
            return RedirectToAction("listbatch", "studentbatch");
        }


        public IActionResult AssignToBatch(StudentBatchViewModel model)
        {
            var Selected = model.StudentId;
            int modelBatchId = model.BatchId;
            foreach (var item in Selected)
            {
                StudentInBatch sb = new StudentInBatch()
                {
                     BatchesId = modelBatchId,
                     EmployeeId = int.Parse(item)
                    
                };
                _programmes.AssignStudentToBatch(sb);
            }
            return RedirectToAction("listbatch");
        }
    }
}
