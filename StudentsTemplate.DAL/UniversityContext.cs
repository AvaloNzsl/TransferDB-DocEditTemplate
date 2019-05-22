using StudentsTemplate.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTemplate.DAL
{
    public class UniversityContext : DbContext
    {
        //Enter name my new DB using by base class constructor
        //the first words - dots [Database of the student]
        public UniversityContext() : base("dotsDataStudent")
        { }

        //Displaying data table to properties with DbSet
        public DbSet<Student> Students { get; set; }
    }
}
