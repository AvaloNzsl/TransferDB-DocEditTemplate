using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsTemplate.ViewModel;
using StudentsTemplate.DAL.UnitService;
using StudentsTemplate.BL.AutoMapperConfiguration;
using AutoMapper;
using StudentsTemplate.DAL.Entities;

namespace StudentsTemplate.BL.Service
{
    public class StudentService : IStudentService
    {
        //initialize mapping
        private StudentMapping _studentMap = new StudentMapping();
        //access to database
        private UnitOfWork _contextUnit;
        public StudentService(UnitOfWork contextUnit)
        {
            _contextUnit = contextUnit;
        }
        //get all students
        public IEnumerable<StudentModel> GetAllStudents()
        {
            //create a list with syudents, then mapping their data model to view model
            var studModel = new List<StudentModel>();
            _studentMap.MapConfigDB();
            var studDB = _contextUnit.Students.GetAllStudents();
            //comparsion time
            studModel = Mapper.Map<IEnumerable<Student>, List<StudentModel>>(studDB);
            return studModel;
        }
        //get student by id
        public StudentModel GetStudentById(int id)
        {
            StudentModel student = new StudentModel();
            var getById = _contextUnit.Students.GetStudentById(id);
            //settings mapper and comparsion
            _studentMap.MapConfigDB();
            student = Mapper.Map<Student, StudentModel>(getById);
            return student;
        }

        public void Save()
        {
            _contextUnit.Save();
        }
    }
}
