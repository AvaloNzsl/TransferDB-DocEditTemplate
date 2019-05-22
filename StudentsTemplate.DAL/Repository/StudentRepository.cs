using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsTemplate.DAL.Entities;

namespace StudentsTemplate.DAL.Repository
{
    public class StudentRepository : IStudentRepository
    {
        //extract data from the database using an instance class UniversityContext
        internal UniversityContext _contextUniver = new UniversityContext();
        public StudentRepository(UniversityContext contextUniver)
        {
            _contextUniver = contextUniver;
        }

        //public IEnumerable<Student> Students
        //{
        //    get { return _contextUniver.Students; }
        //}

        public IEnumerable<Student> GetAllStudents()
        {
            return _contextUniver.Students;
        }

        public Student GetStudentById(int id)
        {
            return _contextUniver.Students.Find(id);
        }

        public void Save()
        {
            _contextUniver.SaveChanges();
        }
    }
}
