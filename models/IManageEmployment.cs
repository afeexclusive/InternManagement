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
        Employement AddEmployment(Employement employment);
        Employement UpdateEmployment(Employement employment);
        IEnumerable<Employement> AllEmployments();
        IEnumerable<Employement> StudentEmployment(int Id);

        //---------------SALARY---------------
        Salary AddSalary(Salary salary);
        IEnumerable<Salary> GetSalaries();

    }
}
