using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static EmployeeManagment.models.Selector;

namespace EmployeeManagment.models
{
    public class Payment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public double AmouontPaid { get; set; }
        public PayMethod PaymentMethod { get; set; }
        public DateTime PaymentDate { get; set; }

        public Employee student { get; set; }
    }
}
