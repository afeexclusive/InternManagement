using EmployeeManagment.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.ViewModels
{
    public class HomeDetailsViewModel
    {
        public Employee employee { get; set; }

        public List<Guarantor> Guarantor { get; set; }
        public string PageTitle { get; set; }
    }
}
