using EmployeeManagment.models;
using EmployeeManagment.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.controllers
{
    
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly IEmployeeReprository _employeeReprository;
        private readonly IWebHostEnvironment hostingEnvironment;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IGuarantorRepo _guarantor;
        private readonly IPayment _payment;

        public HomeController(IEmployeeReprository employeeReprository,
                                IWebHostEnvironment hostingEnvironment,
                                RoleManager<IdentityRole> roleManager,
                                UserManager<IdentityUser> userManager,
                                IGuarantorRepo guarantor,
                                IPayment payment)
        {
            _employeeReprository = employeeReprository;
            this.hostingEnvironment = hostingEnvironment;
            this.roleManager = roleManager;
            this.userManager = userManager;
            this._guarantor = guarantor;
            this._payment = payment;
        }

        [Route("")]
        [Route("~/")]
        [Route("~/Home")]
        [AllowAnonymous]
        public ViewResult Index()
        {
            var model = _employeeReprository.GetEmployees();
            var appUsers = userManager.Users;
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel()
            {
                Student = model.ToList(),
                StudentNo = model.Count(),
                UserNo = appUsers.Count(),
                VisitorNo = model.Count() + appUsers.Count()


            };

            return View(homeIndexViewModel);
        }

        // This would surfice for a web API application
        //public JsonResult Details()
        //{
        //    Employee model = _employeeReprository.GetEmployee(1);
        //    return Json(model);
        //}


        public double BalancePayment(List<Payment>payments, Employee std)
        {
            
            double TotalPaid = 0;
            foreach (var payment in payments)
            {
                TotalPaid = TotalPaid + payment.AmouontPaid;
            }

            if (std.AdmissionType == 0)
            {
                double TotalPackage = 350000;
                double Balance = TotalPackage - TotalPaid;
                return Balance;
            }
            else
            {
                double TotalPackage = 1000000;
                double Balance = TotalPackage - TotalPaid;
                return Balance;
            }

            
            
        }

       

        [Route("{id?}")]
        [AllowAnonymous]
        public ViewResult Details(int? Id)
        {

            Employee employeeTest = _employeeReprository.GetEmployee(Id.Value);
            List<Guarantor> guarantorcollect = _guarantor.GetSpecifiedGuarantor(Id.Value).ToList();
            List<Payment> paymentcollect = _payment.GetSpecifiedPayment(Id.Value).ToList();

            double Balancepay = BalancePayment(paymentcollect, employeeTest);
            
            if (employeeTest == null)
            {
                Response.StatusCode = 404;
                return View("EmployeeNotFound", Id.Value);
            }
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                employee = employeeTest,
                Guarantor = guarantorcollect,
                Payment = paymentcollect,
                Balance = Balancepay,
                PageTitle = "Developer Details"

            };

            return View(homeDetailsViewModel);
        }


        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {

                //int maxi = _employeeReprository.GetEmployees().Max(e => e.Id) + 1;
                string uniqueFileName = ProcessPhoto(model);
                Employee NewEmployee = new Employee
                {
                    //Id = maxi,
                    
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    OtherName = model.OtherName,
                    Email = model.Email,
                    AdmissionBatch = model.AdmissionBatch,
                    AdmissionType = model.AdmissionType,
                    Gender = model.Gender,
                    MaritalStatus = model.MaritalStatus,
                    PhoneNumber = model.PhoneNumber,
                    Photo = uniqueFileName,
                    Status = model.Status,
                    Nationalty = model.Nationalty,
                    Identification = model.Identification,
                    HealthCondition = model.HealthCondition,
                    DateOfBirth = model.DateOfBirth,
                    NextOFKinName = model.NextOFKinName,
                    NextOfKinNumber = model.NextOfKinNumber,
                };
                _employeeReprository.Add(NewEmployee);
                return RedirectToAction("details", new { id = NewEmployee.EmployeeId });
            }
            return View();
        }

        private string ProcessPhoto(EmployeeCreateViewModel model)
        {
            string uniqueFileName = null;
            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(hostingEnvironment.WebRootPath, "img");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var filestream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(filestream);
                }
            }

            return uniqueFileName;
        }


        [Route("Delete/{id?}")]
        public IActionResult Delete(int Id)
        {
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                employee = _employeeReprository.Delete(Id),
                PageTitle = "Employee Details"
            };
            return RedirectToAction("index", homeDetailsViewModel);
        }


        [Route("Edit/{id?}")]
        [HttpGet]
        public ViewResult Edit(int id)
        {
            Employee employee = _employeeReprository.GetEmployee(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel()
            {
                Id = employee.EmployeeId,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                OtherName = employee.OtherName,
                Email = employee.Email,
                AdmissionBatch = employee.AdmissionBatch,
                AdmissionType = employee.AdmissionType,
                Gender = employee.Gender,
                MaritalStatus = employee.MaritalStatus,
                PhoneNumber = employee.PhoneNumber,
                Status = employee.Status,
                fotopath = employee.Photo,
                Nationalty = employee.Nationalty,
                Identification = employee.Identification,
                HealthCondition = employee.HealthCondition,
                DateOfBirth = employee.DateOfBirth,
                NextOFKinName = employee.NextOFKinName,
                NextOfKinNumber = employee.NextOfKinNumber
            };

            return View(employeeEditViewModel);
        }


        [Route("Edit/{id?}")]
        [HttpPost]
        public IActionResult Edit(EmployeeEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFileName = ProcessPhoto(model);
                Employee employee = _employeeReprository.GetEmployee(model.Id);
                {
                    employee.FirstName = model.FirstName;
                    employee.LastName = model.LastName;
                    employee.OtherName = model.OtherName;
                    employee.Email = model.Email;
                    employee.AdmissionBatch = model.AdmissionBatch;
                    employee.AdmissionType = model.AdmissionType;
                    employee.Gender = model.Gender;
                    employee.MaritalStatus = model.MaritalStatus;
                    employee.PhoneNumber = model.PhoneNumber;
                    if (employee.Photo != null)
                    {
                        if (model.fotopath != null)
                        {
                            string filepath = Path.Combine(hostingEnvironment.WebRootPath, "img", model.fotopath);
                            System.IO.File.Delete(filepath);
                        }
                        employee.Photo = uniqueFileName;
                    }
                    employee.Status = model.Status;
                    employee.Nationalty = model.Nationalty;
                    employee.Identification = model.Identification;
                    employee.HealthCondition = model.HealthCondition;
                    employee.DateOfBirth = model.DateOfBirth;
                    employee.NextOFKinName = model.NextOFKinName;
                    employee.NextOfKinNumber = model.NextOfKinNumber;
                };
                _employeeReprository.Update(employee);
                return RedirectToAction("index");
            }
            return View();
        }
    }
}
