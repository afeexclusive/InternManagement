using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.models
{
    public class SQLEmployeeRepository : IEmployeeReprository, IGuarantorRepo
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
            return context.Guarantors.Where(g => g.studentId == Id);
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


    }
}
