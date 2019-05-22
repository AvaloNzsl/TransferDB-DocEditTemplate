using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTemplate.BL.TransferService
{
    public class ExcelSQLTransfer
    {
        //Initializes a new instance of the SqlConnection class contains 'connectionstring'
        //connection to my data student
        SqlConnection conToData = new SqlConnection(
            ConfigurationManager.ConnectionStrings["UniversityContext"].ConnectionString);
        //For initialize a new instance class with specified 'connectionstring'
        OleDbConnection newConnection;

        //Create a full path for Excel file to connect to the database
        //using 'OleDbCommand' and working in it. Data Transfer
        private void ExcelConnection(string filePath)
        {
            //12.0 - connect to Excel 2007 (and later) files with the Xlsx file extension. 
            //8.0  - connect to Excel 97-2003
            //"HDR=Yes;" - the first row contains columnnames, not data.
            //HDR=No;" indicates the opposite.
            string connectionStringExcel =
                string.Format(
                    @"Provider=Microsoft.ACE.OLEDB.12.0;
                    Data Source={0};Extended Properties=""Excel 12.0 Xml;
                    HDR=YES;""", filePath);

            //object with Excel 'connectionstring'
            newConnection = new OleDbConnection(connectionStringExcel);
        }

        //Excel data transfer to my DB SQL
        public void InsertExcelDataFile(string filePath, string fullPath)
        {
            ExcelConnection(fullPath);
            //query for SQL
            string query = string.Format("Select * from [{0}]", "Лист1$");
            //new instance class with text of 'query'  and 'connectionstring'
            OleDbCommand queryConnection = new OleDbCommand(query, newConnection);

            newConnection.Open();

            //cache data in-memory
            DataSet cacheData = new DataSet();

            //represents data commands and database connection
            //which used with DataSet and update data source
            OleDbDataAdapter queryConnectionCashe = new OleDbDataAdapter(query, newConnection);
            newConnection.Close();
            queryConnectionCashe.Fill(cacheData);

            DataTable cacheTable = cacheData.Tables[0];

            //create data table in SQL
            //chek one build // create DB
            //var stud = new Student() { };
            //_sc.Students.Add(stud);
            //_contextDB.SaveChanges();

            //effective loading a SQL Server table with data from another source
            SqlBulkCopy objbulk = new SqlBulkCopy(conToData);
            objbulk.DestinationTableName = "Students";
            //column mapping [Table Excel] to [Students]
            objbulk.ColumnMappings.Add("ФИО", "FullName");
            objbulk.ColumnMappings.Add("Пол", "Sex");
            objbulk.ColumnMappings.Add("Дата поступления", "DateEnter");
            objbulk.ColumnMappings.Add("Курс", "YearStudy");
            objbulk.ColumnMappings.Add("Специальность", "Speciality");
            objbulk.ColumnMappings.Add("Факультет", "Faculty");
            objbulk.ColumnMappings.Add("Форма обучения", "EducationForm");

            //open the data and write to server
            conToData.Open();
            objbulk.WriteToServer(cacheTable);
            //transfer complete
            conToData.Close();
        }
    }
}
