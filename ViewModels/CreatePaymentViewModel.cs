using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static EmployeeManagment.models.Selector;

namespace EmployeeManagment.ViewModels
{
    public class CreatePaymentViewModel
    {
        
        public int EmployeeId { get; set; }

        [Display(Name ="Name:")]
        public string StudentName { get; set; }

        [Required]
        [Display(Name ="Amount Paid")]
        public double AmouontPaid { get; set; }

        [Required]
        [Display(Name = "Payment Method")]
        public PayMethod PaymentMethod { get; set; }

        [Required]
        [Display(Name = "Date")]
        public DateTime PaymentDate { get; set; }
    }
}
