using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTemplate.ViewModel
{
    public class StudentModel
    {
        public int ID { get; set; }
        public string FullName { get; set; }
        public string Sex { get; set; }
        //public Nullable<DateTime> DateEnter { get; set; }
        public string DateEnter { get; set; }
        public string YearStudy { get; set; }
        //public int YearStudy { get; set; }
        public string Speciality { get; set; }
        public string Faculty { get; set; }
        public string EducationForm { get; set; }
    }
}
