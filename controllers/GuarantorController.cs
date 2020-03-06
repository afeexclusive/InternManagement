using EmployeeManagment.models;
using EmployeeManagment.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.controllers
{
    [Route("[controller]/[action]")]
    public class GuarantorController : Controller
    { 
        private readonly IGuarantorRepo _guarantorRepo;
        private readonly IEmployeeReprository _employeeReprository;
        private readonly IWebHostEnvironment hostingEnv;

        

       
 

        public GuarantorController(IGuarantorRepo guarantorRepo, IEmployeeReprository employeeReprository, IWebHostEnvironment hostingEnv)
        {
            _guarantorRepo = guarantorRepo;
            _employeeReprository = employeeReprository;
            this.hostingEnv = hostingEnv;
        }

            
        [Route("~/Guarantor")]
        public ViewResult Index()
        {
            var model = _guarantorRepo.GetGuarantors();

            return View(model);
        }

            
        [Route("{id?}")]
        public ViewResult Details(int? Id)
        {
            IEnumerable<Guarantor> guarantorTest = _guarantorRepo.GetSpecifiedGuarantor(Id.Value);
            if (guarantorTest == null)
            {
                Response.StatusCode = 404;
                return View("GuarantorNotFound", Id.Value);
            }
            GuarantorDetailsViewModel guarantorDetailsViewModel = new GuarantorDetailsViewModel()
            {
                guarantor = guarantorTest,
                PageTitle = "Student Details"

            };

            return View(guarantorDetailsViewModel);
        }

         
        [Route("{id}")]
        [HttpGet]
        public ViewResult Create(int id)
        {
            
            GuarantorCreateViewModel gcv = new GuarantorCreateViewModel(){
                studentId = id,
                Name = "defaultName",
                Email = "defaultEmail",
                Address = "defaultAddress",
                CompanyName = "defaultCname",
                HomePhone = "defaultHome",
                OfficePhone = "defaultOff",
                Position = "defaultPos"
            };
            return View(gcv);
        }

         
        [Route("{id?}")]
        [HttpPost]
        public IActionResult Create(GuarantorCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                //int maxi = _guarantorRepo.GetGuarantors().Max(e => e.id) + 1;
                //string uniqueFileName = ProcessPhoto(model);

                Guarantor Newguarantor = new Guarantor
                {
                   
                    //id = maxi,
                    EmployeeId = model.studentId,
                    Name = model.Name,
                    Email = model.Email,
                    HomePhone = model.HomePhone,
                    //Photo = uniqueFileName,
                    OfficePhone = model.OfficePhone,
                    CompanyName = model.CompanyName,
                    Position = model.Position,
                    Address = model.Address,
                };
                _guarantorRepo.AddGuarantor(Newguarantor);
                return RedirectToAction("index", "home");
            }
            return View();
        }

        //private string ProcessPhoto(GuarantorCreateViewModel model)
        //{
        //    string uniqueFileName = null;
        //    if (model.Photo != null)
        //    {
        //        string uploadsFolder = Path.Combine(hostingEnv.WebRootPath, "img");
        //        uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
        //        string filePath = Path.Combine(uploadsFolder, uniqueFileName);
        //        using (var filestream = new FileStream(filePath, FileMode.Create))
        //        {
        //            model.Photo.CopyTo(filestream);
        //        }
        //    }

        //    return uniqueFileName;
        //}

         
        //[Route("Delete/{id?}")]
        //public IActionResult Delete(int Id)
        //{
        //GuarantorDetailsViewModel guarantorDetailsViewModel = new GuarantorDetailsViewModel()
        //    {
        //        guarantor = _guarantorRepo.DeleteGuarantor(Id),
        //        PageTitle = "Guarantor Details"
        //    };
        //    return RedirectToAction("index", guarantorDetailsViewModel);
        //}

         
        //[Route("Edit/{id?}")]
        //[HttpGet]
        //public ViewResult Edit(int id)
        //{
        //    Guarantor guarantor = _guarantorRepo.GetSpecifiedGuarantor(id);
        //    GuarantorEditViewModel guarantorEditViewModel = new GuarantorEditViewModel()
        //    {
        //        Name = guarantor.Name,
        //        Email = guarantor.Email,
        //        HomePhone = guarantor.HomePhone,
        //        //fotopath = guarantor.Photo,
        //        OfficePhone = guarantor.OfficePhone,
        //        CompanyName = guarantor.CompanyName,
        //        Position = guarantor.Position,
        //        Address = guarantor.Address,
        //    };

        //    return View(guarantorEditViewModel);
        //}

         
        //[Route("Edit/{id?}")]
        //[HttpPost]
        //public IActionResult Edit(GuarantorEditViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //string uniqueFileName = ProcessPhoto(model);
        //        Guarantor guarantor = _guarantorRepo.GetGuarantor(model.Id);
        //        {
        //            guarantor.Name = model.Name;
        //            guarantor.Email = model.Email;
        //            guarantor.HomePhone = model.HomePhone;
        //            //if (guarantor.Photo != null)
        //            //{
        //            //    if (model.fotopath != null)
        //            //    {
        //            //        string filepath = Path.Combine(hostingEnv.WebRootPath, "img", model.fotopath);
        //            //        System.IO.File.Delete(filepath);
        //            //    }
        //            //    guarantor.Photo = uniqueFileName;
        //            //}
        //            guarantor.OfficePhone = model.OfficePhone;
        //            guarantor.CompanyName = model.CompanyName;
        //            guarantor.Position = model.Position;
        //            guarantor.Address = model.Address;

        //        };
        //        _guarantorRepo.UpdateGuarantor(guarantor);
        //        return RedirectToAction("index");
        //    }
        //    return View();
        //}


    }
}

