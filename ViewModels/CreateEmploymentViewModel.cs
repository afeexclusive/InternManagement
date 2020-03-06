using EmployeeManagment.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.ViewModels
{
    public class CreateEmploymentViewModel
    {
        public int Company_Id { get; set; }
        public int Student_Id { get; set; }
        [Required]
        [Display(Name = "Select Company")]
        public string SelectedCompany { get; set; }
        public List<Company> companies { get; set; }

        [Required]
        [Display(Name = "Select Student")]
        public string SelectedStudent { get; set; }
        public List<Employee> students { get; set; }

        public string Role { get; set; }
        [Display(Name ="Pay Day")]
        public string PayDay { get; set; }

        public double Amount { get; set; }

        [Required]
        [Display(Name = "Start Job On")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "Left Job On")]
        public DateTime EndDate { get; set; }
    }
}
