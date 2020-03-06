using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EmployeeManagment.models.Selector;

namespace EmployeeManagment.models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public ProjectStatus Project_Status { get; set; }
        public string ProjectUrl { get; set; }
        public Employee Student { get; set; }
    }
}
