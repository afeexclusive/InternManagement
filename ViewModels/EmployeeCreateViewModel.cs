using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static EmployeeManagment.models.Selector;

namespace EmployeeManagment.ViewModels
{
    public class EmployeeCreateViewModel
    {
       
        //[Required]
        //[MaxLength(50, ErrorMessage = "Name cannot Exceed 50 characters")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        //[Required]
        public Gender? Gender { get; set; }
        //[Required]
        public DateTime DateOfBirth { get; set; }
        //[Required]
        //[RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$", ErrorMessage = "Invalid Email Format")]
        //[Display(Name = "Office Email")]
        public string Email { get; set; }
        //[Required]
        public string Address { get; set; }
        //[Required]
        public string Identification { get; set; }
        //[Required]
        public Nationality? Nationalty { get; set; }
        //[Required]
        public string PhoneNumber { get; set; }

        public Batch? AdmissionBatch { get; set; }

        public IFormFile Photo { get; set; }

        public string HealthCondition { get; set; }
        //[Required]
        public Marital? MaritalStatus { get; set; }
        //[Required]
        public Status? Status { get; set; }
        //[Required]
        public AddmissionType? AdmissionType { get; set; }
        //[Required]
        //[MaxLength(50, ErrorMessage = "Name cannot Exceed 50 characters")]
        public string NextOFKinName { get; set; }
        //[Required]
        public string NextOfKinNumber { get; set; }
        public string NextOfKinAddress { get; set; }
        public string NextOfKinDocuments { get; set; }
    }
}
