using StudentsTemplate.DAL.Entities;
using System.Collections.Generic;

namespace StudentsTemplate.DAL.Repository
{
    //create a plan
    public interface IStudentRepository
    {
        //IEnumerable<Student> Students { get; }

        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int id);

        void Save();
    }
}
