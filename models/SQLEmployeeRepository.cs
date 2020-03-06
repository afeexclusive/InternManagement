using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.models
{
    public class SQLEmployeeRepository : IEmployeeReprository, IGuarantorRepo, IManageEmployment, IPayment
    {
        private readonly AppDbContext context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }

        //------------------------------Students------------------------------------------------
        public Employee Add(Employee employee)
        {
            context.Add(employee);
            context.SaveChanges();
            return employee;

        }

        public Employee Delete(int id)
        {
            Employee employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public Employee GetEmployee(int Id)
        {
            return context.Employees.Find(Id);
            
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees;
        }

        
        public Employee Update(Employee employeeChanges)
        {
            var employee = context.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;
        }

       
        //---------------------------------------Guarantor----------------------------------------------------

        public Guarantor AddGuarantor(Guarantor guarantor)
        {
            context.Add(guarantor);
            context.SaveChanges();
            return guarantor;
        }

        public IEnumerable<Guarantor> GetSpecifiedGuarantor(int Id)
        {
            return context.Guarantors.Where(g => g.EmployeeId == Id);
        }

        public IEnumerable<Guarantor> GetGuarantors()
        {
            return context.Guarantors;
        }

        public Guarantor UpdateGuarantor(Guarantor guarantorChanges)
        {
            var guarantor = context.Guarantors.Attach(guarantorChanges);
            guarantor.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return guarantorChanges;
        }

        public Guarantor DeleteGuarantor(int id)
        {
            Guarantor guarantor = context.Guarantors.Find(id);
            if (guarantor != null)
            {
                context.Guarantors.Remove(guarantor);
                context.SaveChanges();
            }
            return guarantor;
        }

        //--------------------------------------------- Employement-----------------------------------------
        public Company AddCompany(Company company)
        {
            context.Add(company);
            context.SaveChanges();
            return company;
        }

        public Company GetCompany(int Id)
        {
            return context.Companys.Find(Id);
        }
        public IEnumerable<Company> GetCompanies()
        {
            return context.Companys;
        }

        public Company UpdateCompany(Company company)
        {
            var companyChanges = context.Companys.Attach(company);
            companyChanges.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return company;
        }

        public EmployeeCompany AddEmployment(EmployeeCompany employment)
        {
            context.EmployeeCompany.Add(employment);
            context.SaveChanges();
            return employment;
        }

        public EmployeeCompany UpdateEmployment(EmployeeCompany employment)
        {
            var employmentChanges = context.EmployeeCompany.Attach(employment);
            employmentChanges.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employment;
        }

        public IEnumerable<EmployeeCompany> AllEmployments()
        {
            return context.EmployeeCompany;
        }

        public IEnumerable<EmployeeCompany> StudentEmployment(int Id)
        {
            return context.EmployeeCompany.Where(s => s.EmployeeId == Id);
        }

        public Salary AddSalary(Salary salary)
        {
            context.Salaries.Add(salary);
            context.SaveChanges();
            return salary;
        }

        public IEnumerable<Salary> GetSalaries()
        {
            return context.Salaries;
        }

        //--------------------------------------------- Payment-----------------------------------------
        public IEnumerable<Payment> GetSpecifiedPayment(int Id)
        {
            return context.Payments.Where(p => p.EmployeeId == Id);
        }

        public IEnumerable<Payment> GetPayments()
        {
            return context.Payments;
        }

        public Payment AddPayment(Payment payment)
        {
            context.Payments.Add(payment);
            context.SaveChanges();
            return payment;
        }

        public Payment UpdatePayment(Payment paymentChanges)
        {
            var comingPayment = context.Payments.Attach(paymentChanges);
            comingPayment.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return paymentChanges;
        }

        public Payment DeletePayment(int id)
        {
            Payment payment = context.Payments.Find(id);
            if (payment != null)
            {
                context.Payments.Remove(payment);
                context.SaveChanges();
            }
            return payment;
        }
    }
}













