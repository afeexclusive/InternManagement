using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace EmployeeManagment.models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Guarantor> Guarantors { get; set; }
        public DbSet<AcademyProgram> AcademyPrograms { get; set; }
        public DbSet<Batches> Batches { get; set; }
        public DbSet<StudentInBatch> StudentsInBatches { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<ProgrammeCourse> ProgramAndCourses { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<Employement> Employements { get; set; }
        public DbSet<Salary> Salaries { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
            //modelBuilder.SeedGua();
            //modelBuilder.SeedProg();

            // Fluent API Relationships

            // -----------------------------------------------ManyToMany(AcademyProgram and Courses)
            //modelBuilder.Entity<ProgramCourses>()
            //    .HasKey(p => new {p.AcademyProgramId, p.CoursesId });

            //modelBuilder.Entity<ProgramCourses>()
            //    .HasOne(pc => pc.Programme)
            //    .WithMany(ap => ap.ProgrammeCourses)
            //    .HasForeignKey(pc => pc.AcademyProgramId);

            //modelBuilder.Entity<ProgramCourses>()
            //    .HasOne(pc => pc.Course)
            //    .WithMany(c => c.Programmes)
            //    .HasForeignKey(pc => pc.CoursesId);

            // -----------------------------------------------ManyToMany(Student and Batch)
            modelBuilder.Entity<StudentInBatch>()
                .HasKey(s => new {s.EmployeeId, s.BatchesId });

            //modelBuilder.Entity<StudentInBatch>()
            //    .HasOne(sb => sb.Student)
            //    .WithMany(s => s.BatchesIn)
            //    .HasForeignKey(sb => sb.StudentId);

            //modelBuilder.Entity<StudentInBatch>()
            //    .HasOne(sb => sb.Batch)
            //    .WithMany(b => b.StudentsIn)
            //    .HasForeignKey(sb => sb.BatchId);

            // ------------------------------------------OneToMany(Student and Projects)
            //modelBuilder.Entity<Project>()
            //    .HasOne(p => p.Student)
            //    .WithMany(s => s.Projects);

            //----------------------------------------- OneToMany(Student and Guarantor)
            //modelBuilder.Entity<Guarantor>()
            //    .HasOne(g => g.Student)
            //    .WithMany(s => s.Guarantors);

            // --------------------------------------------ManyToMany(Student and Company)****** Not Needed******
            //modelBuilder.Entity<EmployeeCompany>()
            //    .HasKey(k => new { k.CompanyId, k.EmployeeId});

            //modelBuilder.Entity<EmployeeCompany>()
            //   .HasOne(e => e.Company)
            //   .WithMany(c => c.EmployeeCompany)
            //   .HasForeignKey(e => e.CompanyId);

            //modelBuilder.Entity<EmployeeCompany>()
            //    .HasOne(e => e.Employee)
            //    .WithMany(s => s.EmployeeCompany)
            //    .HasForeignKey(e => e.EmployeeId);
        }
    }
}
