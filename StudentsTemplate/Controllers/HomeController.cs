using StudentsTemplate.BL.Service;
using StudentsTemplate.BL.TransferService;
using StudentsTemplate.BL.WordTemplate;
using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace StudentsTemplate.Controllers
{
    public class HomeController : Controller
    {   
        private IStudentService _studentService;
        private ExcelSQLTransfer _transfer = new ExcelSQLTransfer();
        private DocEditTemplate _edit = new DocEditTemplate();

        public HomeController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        // GET: Home
        public ActionResult Index()
        {
            var students = _studentService.GetAllStudents();
            return View(students);
        }
        //Take excel data file for import to SQL
        [HttpPost]
        public ActionResult Index(HttpPostedFileBase file)
        {
            //Create a unique excel file witch unique identifier-name 
            //with extension of the specified path (including the period ".")
            string fileName = Guid.NewGuid()
               /* DateTime.Now.Day + "." + DateTime.Now.Month + "." + DateTime.Now.Year*/
                + "." + Path.GetExtension(file.FileName);
            string filePath = "/ExcelFolder/" + fileName;

            //save backup file in Project Folder - 'ExcelFolder'
            file.SaveAs(Path.Combine(Server.MapPath("/ExcelFolder"), fileName));

            //Insert Excel data file into Data SQL table - 'Students'
            string fullPath = Server.MapPath("/ExcelFolder/") + fileName;
            _transfer.InsertExcelDataFile(filePath, fullPath);

            var students = _studentService.GetAllStudents();
            return View(students);
        }
        //preview of student details
        public ActionResult Details(int id)
        {
            var student = _studentService.GetStudentById(id);
            return View(student);
        }
        [HttpPost]
        //open the word file for printing
        public ActionResult Details(int id, HttpPostedFileBase file)
        {
            var student = _studentService.GetStudentById(id);

            //Create a unique word file witch unique identifier-name -> FullName.DateTime
            string fileName =
                student.FullName + "." +
                DateTime.Now.Day +"."+ DateTime.Now.Month +"."+ DateTime.Now.Year
                + Path.GetExtension(file.FileName);

            string filePath = "/WordFolder/" + fileName;

            //save backup file in 'WordFolder'
            file.SaveAs(Path.Combine(Server.MapPath("/WordFolder"), fileName));

            //full path to feature work 
            string fullPath = Server.MapPath("/WordFolder/") + fileName;
            _edit.WordEditFile(fullPath, student);


            return View(student);
        }
    }
}