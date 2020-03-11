using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagment.models
{
    public interface IProgrammes
    {
        //----------------------------- Programmes --------------------------
        IEnumerable<AcademyProgram> GetSpecifiedProgrammes(int Id);
        IEnumerable<AcademyProgram> GetProgrammes();
        AcademyProgram AddProgramme(AcademyProgram academyProgram);
        AcademyProgram UpdateProgramme(AcademyProgram academyProgram);
        AcademyProgram DeleteProgramme(int id);


        //--------------------------- Courses --------------------------------

        IEnumerable<Courses> GetSpecifiedCourses(int Id);
        IEnumerable<Courses> GetCourses();
        Courses AddCourse(Courses courses);
        Courses UpdateCourse(Courses courses);
        Courses DeleteCourses(int id);


        //----------------------------Program and Courses--------------------------

        AcademyProgram GetAcademyProgram(int id);
        IEnumerable<ProgrammeCourse> GetListOfProgram(int id);
        IEnumerable<ProgrammeCourse> GetListOfCourses(int id);
        IEnumerable<ProgrammeCourse> GetProgCourses();
        ProgrammeCourse AddProgCourses(ProgrammeCourse progCourse);

        //----------------------------Batches--------------------------

        Batches AddBatch(Batches batches);
        Batches GetABatch(int id);
        IEnumerable<Batches> GetABatch();
        Batches UpdateBatch(Batches batches);
        Batches DeleteBatch(int id);


        //----------------------------Students In Batches--------------------------

        StudentInBatch AssignStudentToBatch(StudentInBatch SinB);
        StudentInBatch GetOneStudentInBatch(int id);
        IEnumerable<StudentInBatch> GetAllStudentInBatch();



    }
}
