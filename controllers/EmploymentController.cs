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
    public class EmploymentController: Controller
    {
        private readonly IEmployeeReprository _student;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly IManageEmployment _manageEmployment;

        public EmploymentController(IEmployeeReprository student, IWebHostEnvironment hostingEnvironment, IManageEmployment manageEmployment)
        {
           this._student = student;
            this._hostingEnvironment = hostingEnvironment;
            this._manageEmployment = manageEmployment;
        }

        [HttpGet]
        public ViewResult CreateCompany()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCompany(CreateCompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                Company newCompany = new Company
                {
                    CompanyName = model.CompanyName,
                    Address = model.Address,
                    ContactName = model.ContactName,
                    ContactEmail = model.ContactEmail,
                    ContactPhone = model.ContactPhone
                };
                _manageEmployment.AddCompany(newCompany);
                return RedirectToAction("index", "home");

            }
            return View();
        }

        [HttpGet]
        public ViewResult ListCompany()
        {
            var companies = _manageEmployment.GetCompanies();
            return View(companies);
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            Company company = _manageEmployment.GetCompany(id);

            EditCompanyViewModel editCompanyViewModel = new EditCompanyViewModel()
            {
                Address = company.Address,
                CompanyName = company.CompanyName,
                ContactEmail = company.ContactEmail,
                ContactName = company.ContactName,
                ContactPhone = company.ContactPhone
            };

            return View(editCompanyViewModel);
        }


        [Route("Edit/{id?}")]
        [HttpPost]
        public IActionResult Edit(EditCompanyViewModel model)
        {
            if (ModelState.IsValid)
            {

                Company company = _manageEmployment.GetCompany(model.Id);
                {
                    company.Address = model.Address;
                    company.CompanyName = model.CompanyName;
                    company.ContactEmail = model.ContactEmail;
                    company.ContactPhone = model.ContactPhone;
                    company.ContactName = model.ContactName;
                };
                _manageEmployment.UpdateCompany(company);
                return RedirectToAction("listcompany");
            }
            return View();
        }

        [HttpGet]
        public ViewResult CreateEmployment()
        {
            List<Employee> studentys = _student.GetEmployees().ToList();
            List<Company> companys = _manageEmployment.GetCompanies().ToList();
            CreateEmploymentViewModel createEmploymentViewModel = new CreateEmploymentViewModel()
            {
                students = studentys,
                companies = companys
            };
            
            return View(createEmploymentViewModel);
        }

        [HttpPost]
        public IActionResult CreateEmployment(CreateEmploymentViewModel model)
        {
            if (ModelState.IsValid)
            {


                Employement Newemployment = new Employement
                {
                    CompanyId = int.Parse(model.SelectedCompany),
                    EmployeeId = int.Parse(model.SelectedStudent),
                    StartDate = model.StartDate,
                    EndDate = model.EndDate
                };
                _manageEmployment.AddEmployment(Newemployment);

                Salary NewSalary = new Salary
                {
                     Amount = model.Amount,
                     Role = model.Role,
                     PayDay = model.PayDay,
                     EmployeeId = int.Parse(model.SelectedStudent)
                };
                _manageEmployment.AddSalary(NewSalary);
                return RedirectToAction("index", "home");
            }

            return View();

        }
    }
}
