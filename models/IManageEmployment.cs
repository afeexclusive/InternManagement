using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.models
{
    public interface IManageEmployment
    {
        //------------- COMPANY-------------
        Company AddCompany(Company company);

        Company GetCompany(int Id);
        IEnumerable<Company> GetCompanies();
        Company UpdateCompany(Company company);

        //-------------- EMPLOYMENT-----------
        EmployeeCompany AddEmployment(EmployeeCompany employment);
        EmployeeCompany UpdateEmployment(EmployeeCompany employment);
        IEnumerable<EmployeeCompany> AllEmployments();
        IEnumerable<EmployeeCompany> StudentEmployment(int Id);

        //---------------SALARY---------------
        Salary AddSalary(Salary salary);
        IEnumerable<Salary> GetSalaries();

    }
}
