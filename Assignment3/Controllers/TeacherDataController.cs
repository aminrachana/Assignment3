using Assignment3.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment3.Controllers
{
    public class TeacherDataController : ApiController
    {
        private SchoolDbContext school = new SchoolDbContext();

        ///<summary>
        ///Returns a list of Teachers in the system
        ///</summary>
        ///<example>GET api/TeacherData/ListTeachers</example>
        ///<returns>
        ///Alist of teachers (first names and last names)
        ///</returns>
        [HttpGet]
        [Route("api/TeacherData/ListTeachers/{SearchKey?}")]
        public IEnumerable<Teacher> ListTeachers(string SearchKey = null)
        {
         
            MySqlConnection Conn = school.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Select * from Teachers where teacherfname like lower ('%"+SearchKey+"%') or teacherlname like lower('%"+SearchKey+ "%') or teacherid like lower('%"+SearchKey+"%') or lower (concat(teacherfname, ' ', teacherlname)) like lower('%"+SearchKey+"%') ";

            cmd.Parameters.AddWithValue("@key", "%" + SearchKey + "%");
            
            
            MySqlDataReader ResultSet = cmd.ExecuteReader();   

            List<Teacher> Teachers = new List<Teacher> {};

            while (ResultSet.Read())
            {
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = (string)ResultSet["teacherfname"];
                string TeacherLname = (string)ResultSet["teacherlname"];
                string EmployeeNumber = (string)ResultSet["employeenumber"];
                DateTime HireDate = (DateTime)ResultSet["hiredate"];
                decimal Salary = (decimal)ResultSet["salary"];
               
                Teacher NewTeacher = new Teacher();
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname; 
                NewTeacher.TeacherLname = TeacherLname; 
                NewTeacher.EmployeeNumber = EmployeeNumber; 
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;
                               

                Teachers.Add(NewTeacher);
            }

            Conn.Close();

            return Teachers;    

        }

        [HttpGet]
        public Teacher FindTeacher(int id)
        {
            Teacher NewTeacher = new Teacher();

            MySqlConnection Conn = school.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            cmd.CommandText = "Select * from Teachers where teacherid = " + id;

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            while (ResultSet.Read())
            {
                int TeacherId = (int)ResultSet["teacherid"];
                string TeacherFname = (string)ResultSet["teacherfname"];
                string TeacherLname = (string)ResultSet["teacherlname"];
                string EmployeeNumber = (string)ResultSet["employeenumber"];
                DateTime HireDate = (DateTime)ResultSet["hiredate"];
                decimal Salary = (decimal)ResultSet["salary"];
                
                NewTeacher.TeacherId = TeacherId;
                NewTeacher.TeacherFname = TeacherFname;
                NewTeacher.TeacherLname = TeacherLname;
                NewTeacher.EmployeeNumber = EmployeeNumber;
                NewTeacher.HireDate = HireDate;
                NewTeacher.Salary = Salary;
               
            }

            return NewTeacher;
        }
    }
}
