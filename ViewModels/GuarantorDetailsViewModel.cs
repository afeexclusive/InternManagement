using EmployeeManagment.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.ViewModels
{
    public class GuarantorDetailsViewModel
    {
        public IEnumerable<Guarantor>guarantor { get; set; }
        public string PageTitle { get; set; }
    }
}
