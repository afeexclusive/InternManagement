using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.ViewModels
{
    public class CreateCompanyViewModel
    {
        [Required]
        [Display(Name = "Name of Company")]
        public string CompanyName { get; set; }
        public string Address { get; set; }

        [Required]
        [Display(Name = "Name of Contact Person")]
        public string ContactName { get; set; }

        [Required]
        [Display(Name = "Email Address")]
        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required]
        [Display(Name = "Mobile Phone No")]
        [Phone]
        public string ContactPhone { get; set; }
    }
}
