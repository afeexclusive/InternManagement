using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.models
{
    public class SQLEmployeeRepository : IEmployeeReprository, IGuarantorRepo, IManageEmployment, IPayment, IProgrammes
    {
        private readonly AppDbContext context;

        public SQLEmployeeRepository(AppDbContext context)
        {
            this.context = context;
        }

        //------------------------------Students------------------------------------------------
        public Employee Add(Employee employee)
        {
            context.Add(employee);
            context.SaveChanges();
            return employee;

        }

        public Employee Delete(int id)
        {
            Employee employee = context.Employees.Find(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                context.SaveChanges();
            }
            return employee;
        }

        public Employee GetEmployee(int Id)
        {
            return context.Employees.Find(Id);
            
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return context.Employees;
        }

        
        public Employee Update(Employee employeeChanges)
        {
            var employee = context.Employees.Attach(employeeChanges);
            employee.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employeeChanges;
        }

       
        //---------------------------------------Guarantor----------------------------------------------------

        public Guarantor AddGuarantor(Guarantor guarantor)
        {
            context.Add(guarantor);
            context.SaveChanges();
            return guarantor;
        }

        public IEnumerable<Guarantor> GetSpecifiedGuarantor(int Id)
        {
            return context.Guarantors.Where(g => g.EmployeeId == Id);
        }

        public IEnumerable<Guarantor> GetGuarantors()
        {
            return context.Guarantors;
        }

        public Guarantor UpdateGuarantor(Guarantor guarantorChanges)
        {
            var guarantor = context.Guarantors.Attach(guarantorChanges);
            guarantor.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return guarantorChanges;
        }

        public Guarantor DeleteGuarantor(int id)
        {
            Guarantor guarantor = context.Guarantors.Find(id);
            if (guarantor != null)
            {
                context.Guarantors.Remove(guarantor);
                context.SaveChanges();
            }
            return guarantor;
        }

        //--------------------------------------------- Employement-----------------------------------------
        public Company AddCompany(Company company)
        {
            context.Add(company);
            context.SaveChanges();
            return company;
        }

        public Company GetCompany(int Id)
        {
            return context.Companys.Find(Id);
        }
        public IEnumerable<Company> GetCompanies()
        {
            return context.Companys;
        }

        public Company UpdateCompany(Company company)
        {
            var companyChanges = context.Companys.Attach(company);
            companyChanges.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return company;
        }

        public Employement AddEmployment(Employement employment)
        {
            context.Employements.Add(employment);
            context.SaveChanges();
            return employment;
        }

        public Employement UpdateEmployment(Employement employment)
        {
            var employmentChanges = context.Employements.Attach(employment);
            employmentChanges.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return employment;
        }

        public IEnumerable<Employement> AllEmployments()
        {
            return context.Employements;
        }

        public IEnumerable<Employement> StudentEmployment(int Id)
        {
            return context.Employements.Where(s => s.EmployeeId == Id);
        }

        public Salary AddSalary(Salary salary)
        {
            context.Salaries.Add(salary);
            context.SaveChanges();
            return salary;
        }

        public IEnumerable<Salary> GetSalaries()
        {
            return context.Salaries;
        }

        //--------------------------------------------- Payment-----------------------------------------
        public IEnumerable<Payment> GetSpecifiedPayment(int Id)
        {
            return context.Payments.Where(p => p.EmployeeId == Id);
        }

        public IEnumerable<Payment> GetPayments()
        {
            return context.Payments;
        }

        public Payment AddPayment(Payment payment)
        {
            context.Payments.Add(payment);
            context.SaveChanges();
            return payment;
        }

        public Payment UpdatePayment(Payment paymentChanges)
        {
            var comingPayment = context.Payments.Attach(paymentChanges);
            comingPayment.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return paymentChanges;
        }

        public Payment DeletePayment(int id)
        {
            Payment payment = context.Payments.Find(id);
            if (payment != null)
            {
                context.Payments.Remove(payment);
                context.SaveChanges();
            }
            return payment;
        }


        //----------------------------------------- Programmes and Courses-----------------------------

        public IEnumerable<AcademyProgram> GetSpecifiedProgrammes(int Id)
        {
            return context.AcademyPrograms.Where(p => p.AcademyProgramId == Id);
        }

        public IEnumerable<AcademyProgram> GetProgrammes()
        {
            return context.AcademyPrograms;
        }

        public AcademyProgram GetAcademyProgram(int id)
        {
            return context.AcademyPrograms.Find(id);
        }

        public AcademyProgram AddProgramme(AcademyProgram academyProgram)
        {
            context.AcademyPrograms.Add(academyProgram);
            context.SaveChanges();
            return academyProgram;
        }

        public AcademyProgram UpdateProgramme(AcademyProgram academyProgram)
        {
            var newAcadaProg = context.AcademyPrograms.Attach(academyProgram);
            newAcadaProg.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return academyProgram;
        }

        public AcademyProgram DeleteProgramme(int id)
        {
            AcademyProgram academyProg = context.AcademyPrograms.Find(id);
            if (academyProg != null)
            {
                context.AcademyPrograms.Remove(academyProg);
                context.SaveChanges();
            }
            return academyProg;
        }

        public IEnumerable<Courses> GetSpecifiedCourses(int Id)
        {
            return context.Courses.Where(c => c.CoursesId == Id);
        }

        public IEnumerable<Courses> GetCourses()
        {
            return context.Courses;
        }

        public Courses AddCourse(Courses courses)
        {
            context.Courses.Add(courses);
            context.SaveChanges();
            return courses;
        }

        public Courses UpdateCourse(Courses courses)
        {
            var newCourse = context.Courses.Attach(courses);
            newCourse.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return courses;
        }

        public Courses DeleteCourses(int id)
        {
            Courses courses = context.Courses.Find(id);
            if (courses != null)
            {
                context.Courses.Remove(courses);
                context.SaveChanges();
            }
            return courses;
        }

        public IEnumerable<ProgrammeCourse> GetListOfProgram(int id)
        {
            return context.ProgramAndCourses.Where(pc => pc.CoursesId == id);
        }

        public IEnumerable<ProgrammeCourse> GetListOfCourses(int id)
        {
            return context.ProgramAndCourses.Where(pc => pc.AcademyProgramId == id);
        }

        public IEnumerable<ProgrammeCourse> GetProgCourses()
        {
            return context.ProgramAndCourses;
        }
        public ProgrammeCourse AddProgCourses(ProgrammeCourse progCourse)
        {
            context.ProgramAndCourses.Add(progCourse);
            context.SaveChanges();
            return progCourse;
        }


        //----------------------------Batches--------------------------
        public Batches AddBatch(Batches batches)
        {
            context.Batches.Add(batches);
            context.SaveChanges();
            return batches;
        }

        public Batches GetABatch(int id)
        {
            return context.Batches.Find(id);
        }

        public IEnumerable<Batches> GetABatch()
        {
            return context.Batches;
        }

        public Batches UpdateBatch(Batches batches)
        {
            var newBatch = context.Batches.Attach(batches);
            newBatch.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return batches;
        }

        public Batches DeleteBatch(int id)
        {
            Batches batches = context.Batches.Find(id);
            context.Remove(batches);
            context.SaveChanges();
            return batches;
        }


        //----------------------------Student In Batches--------------------------

        public StudentInBatch AssignStudentToBatch(StudentInBatch SinB)
        {
            context.StudentsInBatches.Add(SinB);
            context.SaveChanges();
            return SinB;
        }

        public StudentInBatch GetOneStudentInBatch(int id)
        {
            return context.StudentsInBatches.Find(id);
        }

        public IEnumerable<StudentInBatch> GetAllStudentInBatch()
        {
            return context.StudentsInBatches;
        }

    }
}













