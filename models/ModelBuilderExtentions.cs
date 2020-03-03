using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.models
{
    public static class ModelBuilderExtentions
    {
        //public static void Seed(this ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Employee>().HasData(
        //        new Employee 
        //        {
        //            Id = 85,
        //            systemId = Guid.NewGuid(),
        //            Name = "Mary Jane",
        //            AdmissionBatch = Selector.Batch.Jul2016,
        //            Email = "maryjane@me.com",
        //            DateOfBirth = DateTime.Now,
        //            Address = "dfdsdsf",
        //            MaritalStatus = Selector.Marital.Single,
        //            Gender = Selector.Gender.Female,
        //            PhoneNumber = "576757677",
        //            AdmissionType = Selector.AddmissionType.IncomeSharing,
        //            HealthCondition = "No allegies",
        //            Identification = "num",
        //            Nationalty = Selector.Nationality.Indonesia,
        //            NextOfKinAddress = "jkfdfdhj",
        //            NextOfKinDocuments = "hjgfdjh",
        //            NextOFKinName = "ayo",
        //            NextOfKinNumber = "09087655",
        //            Status = Selector.Status.InTraining
        //        });
        //}

        //public static void SeedGua(this ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Guarantor>().HasData(
        //        new Guarantor
        //        {
        //            id = 50,
        //            studentId = 20,
        //            GuarantId = Guid.NewGuid(),
        //            Name = "Mary G",
        //            Email = "maryjane@me.com",
        //            Address = "dfdsdsf",
        //            HomePhone = "576757677",
        //            OfficePhone = "80967867978",
        //            CompanyName = "jkfdfdhj",
        //            Position = "hjgfdjh"
        //        });
        //}

        //public static void SeedProg(this ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<AcademyProgram>().HasData(
        //        new AcademyProgram
        //        {
        //            Id = 1,
        //            ProgSystemId = Guid.NewGuid(),
        //            ProgramName = "Defualt Program",
        //            StudentId = 85,
        //            Batch = Selector.Batch.Jul2016
        //        });
        //}
        
    }
}
