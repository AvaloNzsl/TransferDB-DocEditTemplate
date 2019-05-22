using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTemplate.DAL.UniversityBDInitializer
{
    public class UniversityInitializer : DropCreateDatabaseIfModelChanges<UniversityContext>
    {
        protected override void Seed(UniversityContext context)
        {
            context.Students.Add(new Entities.Student
            {
                ID = 1,
                FullName = "Admin",
                Sex = "m",
                DateEnter = "04.11.2017",
                EducationForm = "Och",
                Faculty = "FRKT",
                Speciality = "FE",
                YearStudy = "5"
            });
            context.SaveChanges();
        }
    }
}
