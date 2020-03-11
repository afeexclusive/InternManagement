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
    [Route("[controller]/[action]")]
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
            string firstname = std.FirstName;
            string lastname = std.LastName;
            string Fullname = firstname +" "+ lastname;
            CreatePaymentViewModel pvm = new CreatePaymentViewModel()
            {
                EmployeeId = id,
                StudentName = Fullname,
                AmouontPaid = 0.00,
                PaymentDate = DateTime.Now,
                PaymentMethod = Selector.PayMethod.BankTransfer
            };

            return View(pvm);
        }

        [Route("{id}")]
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
                    PaymentDate = model.PaymentDate
                                  
                };
                _payment.AddPayment(newPayment);
                return RedirectToAction("index", "home");

            }
            return View();
        }
    }
}
