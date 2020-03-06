using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.models
{
    public class MockEmployeeRepository : IEmployeeReprository
    {
        public List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>()
            {
                new Employee{EmployeeId=1, FirstName = "Mary", LastName="Jane", AdmissionBatch = Selector.Batch.Batch_A, Email = "maryjane@me.com"},
                new Employee{EmployeeId=2, FirstName = "Steven", LastName="Malian", AdmissionBatch = Selector.Batch.Batch_B, Email = "stevemal@me.com"},
                new Employee{EmployeeId=3, FirstName = "Ebi", LastName="George", AdmissionBatch = Selector.Batch.Batch_C, Email = "gEbi@me.com"},
                new Employee{EmployeeId=4, FirstName = "Lola ", LastName="Richy", AdmissionBatch = Selector.Batch.Batch_D, Email = "ritlol@me.com"},
                new Employee{EmployeeId=5, FirstName = "Obi", LastName="codeman", AdmissionBatch = Selector.Batch.Batch_E, Email = "obicodeman@me.com"},
            };
        }

        public Employee Add(Employee employee)
        {
            _employeeList.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.EmployeeId == id);
            if (employee != null)
            {
                _employeeList.Remove(employee);
            }
            return employee;
        }

        public Employee GetEmployee(int Id)
        {
            return _employeeList.FirstOrDefault(e => e.EmployeeId == Id);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _employeeList;
        }

        public Employee Update(Employee employeeChanges)
        {
            Employee employee = _employeeList.FirstOrDefault(e => e.EmployeeId == employeeChanges.EmployeeId);
            if (employee != null)
            {
                employee.LastName = employeeChanges.LastName;
                employee.Email = employeeChanges.Email;
                employee.AdmissionBatch = employeeChanges.AdmissionBatch;
            }
            return employeeChanges;
        }
    }
}
