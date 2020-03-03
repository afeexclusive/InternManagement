using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.ViewModels
{
    public class AllView:GuarantorCreateViewModel
    {
        public EmployeeCreateViewModel createStudent = new EmployeeCreateViewModel();

        public EmployeeEditViewModel editStudent = new EmployeeEditViewModel();

        public HomeDetailsViewModel detailStudent = new HomeDetailsViewModel();

    }
}
