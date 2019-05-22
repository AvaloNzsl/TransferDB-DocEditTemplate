using DocumentFormat.OpenXml.Packaging;
using StudentsTemplate.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace StudentsTemplate.BL.WordTemplate
{
    public class DocEditTemplate
    {
        public void WordEditFile(string fullpath, StudentModel student)
        {
            //open the word document by instanting the class 
            //by using 'Open' method with 'true' bool-parametr to enable editing the document
            using (WordprocessingDocument wordDoc = 
                WordprocessingDocument.Open(fullpath, true))
            {
                string docText = null;
                using (StreamReader streamRead = 
                    new StreamReader(wordDoc.MainDocumentPart.GetStream()))
                {
                    docText = streamRead.ReadToEnd();
                }
                //after open the file for editing to create a regular expression object,
                // which contains a model of type string student, then replacing text
                string data = Convert.ToString(DateTime.Now.Day) + "."
                    + Convert.ToString(DateTime.Now.Month) + "."
                    + Convert.ToString(DateTime.Now.Year);

                Regex regexText = new Regex("data");
                docText = regexText.Replace(docText, data);

                regexText = new Regex("number");
                docText = regexText.Replace(docText, Convert.ToString(student.ID));

                regexText = new Regex("FIO");
                docText = regexText.Replace(docText, student.FullName);

                regexText = new Regex("date");
                docText = regexText.Replace(docText, student.DateEnter);

                regexText = new Regex("sex");
                if (student.Sex == "f")
                {
                    docText = regexText.Replace(docText, "она");
                }
                else
                {
                    docText = regexText.Replace(docText, "он");
                }

                regexText = new Regex("trueStudy");
                if (student.YearStudy != null)
                {
                    docText = regexText.Replace(docText, "обучающимся");
                }

                regexText = new Regex("yearStudy");
                docText = regexText.Replace(docText, student.YearStudy);

                regexText = new Regex("Speciality");
                docText = regexText.Replace(docText, student.Speciality);

                regexText = new Regex("Faculty");
                docText = regexText.Replace(docText, student.Faculty);

                regexText = new Regex("formStudy");
                docText = regexText.Replace(docText, student.EducationForm);

                regexText = new Regex("lastDate");
                docText = regexText.Replace(docText, "01.08.2020");

                regexText = new Regex("@");
                docText = regexText.Replace(docText, "Tarazevich 25 954 38 55");


                using (StreamWriter streamWrite =
                    new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
                {
                    streamWrite.Write(docText);
                }
                Console.WriteLine("Check");
            }
        }
    }
}
