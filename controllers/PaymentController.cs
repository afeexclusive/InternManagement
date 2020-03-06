using EmployeeManagment.models;
using EmployeeManagment.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.controllers
{
    public class PaymentController: Controller
    {
        private readonly IEmployeeReprository _student;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IPayment _payment;

        public PaymentController(IEmployeeReprository student, IWebHostEnvironment hostingEnvironment, IPayment payment )
        {
            this._student = student;
            this._hostingEnvironment = hostingEnvironment;
            this._payment = payment;
        }

        [Route("{id?}")]
        [HttpGet]
        public ViewResult CreatePayment(int id)
        {
            Employee std = _student.GetEmployee(id);
            string Fullname = (std.FirstName) +" "+ (std.LastName);
            CreatePaymentViewModel pvm = new CreatePaymentViewModel()
            {
                EmployeeId = id,
                StudentName = Fullname
            };

            return View(pvm);
        }

        [HttpPost]
        public IActionResult CreatePayment(CreatePaymentViewModel model)
        {

            if (ModelState.IsValid)
            {
                Payment newPayment = new Payment
                {
                    EmployeeId = model.EmployeeId,
                    AmouontPaid = model.AmouontPaid,
                    PaymentMethod = model.PaymentMethod,
                    PaymentDate = model.PaymentDate,
                                  
                };
                _payment.AddPayment(newPayment);
                return RedirectToAction("details", "index", new { id = newPayment.EmployeeId });

            }
            return View();
        }
    }
}
