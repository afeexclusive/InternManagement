using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.models
{
    public class Guarantor
    {
        public int Id { get; set; }
        public Guid GuarantId { get; set; }
        public int studentId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string HomePhone { get; set; }
        public string OfficePhone { get; set; }
        public string Address { get; set; }
        public string CompanyName { get; set; }
        public string Position { get; set; }
        public string Photo { get; set; }
        public Employee Student { get; set; }
    }
}
