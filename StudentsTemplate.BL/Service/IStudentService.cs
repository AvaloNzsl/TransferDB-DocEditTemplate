using StudentsTemplate.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTemplate.BL.Service
{
    public interface IStudentService
    {
        IEnumerable<StudentModel> GetAllStudents();
        StudentModel GetStudentById(int id);

        void Save();
    }
}
