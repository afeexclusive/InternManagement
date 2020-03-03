using EmployeeManagment.models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.ViewModels
{
    public class HomeIndexViewModel
    {
        public List<Employee> Student { get; set; }
        public int UserNo { get; set; }
        public int StudentNo { get; set; }
        public int VisitorNo { get; set; }
    }
}
