using AutoMapper;
using StudentsTemplate.DAL.Entities;
using StudentsTemplate.ViewModel;
using System;

namespace StudentsTemplate.BL.AutoMapperConfiguration
{
    public class StudentMapping : IStudentMapping
    {
        public void MapConfigDB()
        {
            //
            Mapper.Initialize(config =>
            {
                //configuration for mapping fields by name and type 'one module to another'
                config.CreateMap<Student, StudentModel>();
            });
        }
    }
}
