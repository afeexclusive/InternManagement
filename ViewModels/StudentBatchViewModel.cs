using EmployeeManagment.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EmployeeManagment.models.Selector;

namespace EmployeeManagment.ViewModels
{
    public class StudentBatchViewModel
    {
        public List<Batches> Batches { get; set; }
        public List<Employee> Students { get; set; }

        public List<StudentInBatch> AssignedStudents { get; set; }

        public int BatchId { get; set; }

        public string StudentsName { get; set; }

        public List<string> StudentId { get; set; }
    }
}
