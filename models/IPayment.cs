using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.models
{
    public interface IPayment
    {
        IEnumerable<Payment> GetSpecifiedPayment(int Id);
        IEnumerable<Payment> GetPayments();
        Payment AddPayment(Payment payment);
        Payment UpdatePayment(Payment paymentChanges);
        Payment DeletePayment(int id);
    }
}
