using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SchoolWebProject.Models;
using MySql.Data.MySqlClient;

// API Controller file.

//Code based on code from:
//https://github.com/christinebittle/BlogProject_2/blob/master/BlogProject/Controllers/AuthorDataController.cs

namespace SchoolWebProject.Controllers
{

    public class TeacherDataController : ApiController
    {

        // The database context class which allows us to access our MySQL Database.
        private SchoolDbContext School = new SchoolDbContext();

        /// <summary>
        /// Connects to the database.
        /// Fetches all the data from the teachers table
        /// </summary>
        /// <returns>Data Fetched from the database (Array of Teacher's record)</returns>
        [HttpGet]
        public IEnumerable<Teacher> ListTeachers()
        {
            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query to select all the rows from the teachers table of School database.
            cmd.CommandText = "Select * from teachers";

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            List<Teacher> teachers = new List<Teacher> { };

            // read each of the row line by line using a while loop which loops until the end of line.
            while (ResultSet.Read())
            {

                int teacherid = (int)ResultSet["teacherid"];
                string teacherfname = ResultSet["teacherfname"].ToString();
                string teacherlname = ResultSet["teacherlname"].ToString();
                string employeenumber = ResultSet["employeenumber"].ToString();
                string hiredate = ResultSet["hiredate"].ToString();
                decimal salary = (decimal)ResultSet["salary"];

                Teacher NewTeacher = new Teacher();
                NewTeacher.teacherid = teacherid;
                NewTeacher.teacherfname = teacherfname;
                NewTeacher.teacherlname = teacherlname;
                NewTeacher.employeenumber = employeenumber;
                NewTeacher.hiredate = hiredate;
                NewTeacher.salary = salary;

                //Object added to the array.
                teachers.Add(NewTeacher);

            }

            Conn.Close();

            return teachers;

        }

        [HttpGet]
        public IEnumerable<Student> ListStudent()
        {
            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query to select all the rows from the teachers table of School database.
            cmd.CommandText = "Select * from students";

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            List<Student> students = new List<Student> { };

            // read each of the row line by line using a while loop which loops until the end of line.
            while (ResultSet.Read())
            {
                //int teacherid = (int)ResultSet["teacherid"];
                string studentfname = ResultSet["studentfname"].ToString();
                string studentlname = ResultSet["studentlname"].ToString();
                string studentnumber = ResultSet["studentnumber"].ToString();
                string enroldate = ResultSet["enroldate"].ToString();

                Student NewStudent = new Student();
                NewStudent.studentfname = studentfname;
                NewStudent.studentlname = studentlname;
                NewStudent.studentnumber = studentnumber;
                NewStudent.enroldate = enroldate;

                //Object added to the array.
                students.Add(NewStudent);

            }

            Conn.Close();

            return students;

        }

        /// <summary>
        /// Searches for the list of courses taught by a teacher specified by teacherid.
        /// </summary>
        /// <param name="id">teacherid</param>
        /// <returns>List of courses taught by a teacher</returns>
        [HttpGet]
        public IEnumerable<TeacherCourses> FindTeacher(int id)
        {

            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query to select a row from the table with specified id.
            cmd.CommandText = "SELECT teacherfname, teacherlname, classcode, classname " +
                            "FROM `classes` INNER JOIN `teachers` ON classes.teacherid = teachers.teacherid " +
                            "WHERE teachers.teacherid =" + id;
            //"Select * from teachers where teacherid = " + id;

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            List<TeacherCourses> Courses = new List<TeacherCourses> { };

            while (ResultSet.Read())
            {

                string teacherfname = ResultSet["teacherfname"].ToString();
                string teacherlname = ResultSet["teacherlname"].ToString();
                string classcode = ResultSet["classcode"].ToString();
                string classname = ResultSet["classname"].ToString();

                TeacherCourses TCourses = new TeacherCourses();
                TCourses.teacherfname = teacherfname;
                TCourses.teacherlname = teacherlname;
                TCourses.classcode = classcode;
                TCourses.classname = classname;

                Courses.Add(TCourses);
            }

            Conn.Close();

            return Courses;
        }

        /// <summary>
        /// User provided name is used to perform search to find more information about a teacher.
        /// </summary>
        /// <param name="name">The first name of the teacher</param>
        /// <returns>Full details stored about the teacher.</returns>
        [HttpGet]
        public Teacher SearchName(string name)
        {
            Teacher NewTeacher = new Teacher();

            MySqlConnection Conn = School.AccessDatabase();

            Conn.Open();

            MySqlCommand cmd = Conn.CreateCommand();

            //SQL query to select a row from the table with specified id.
            cmd.CommandText = "Select * from teachers where teacherfname LIKE '" + name + "'";

            MySqlDataReader ResultSet = cmd.ExecuteReader();

            //List<Teacher> teachers = new List<Teacher> { };

            while (ResultSet.Read())
            {

                int teacherid = (int)ResultSet["teacherid"];
                string teacherfname = ResultSet["teacherfname"].ToString();
                string teacherlname = ResultSet["teacherlname"].ToString();
                string employeenumber = ResultSet["employeenumber"].ToString();
                string hiredate = ResultSet["hiredate"].ToString();
                decimal salary = (decimal)ResultSet["salary"];

                NewTeacher.teacherid = teacherid;
                NewTeacher.teacherfname = teacherfname;
                NewTeacher.teacherlname = teacherlname;
                NewTeacher.employeenumber = employeenumber;
                NewTeacher.hiredate = hiredate;
                NewTeacher.salary = salary;

            }

            Conn.Close();

            return NewTeacher;

        }

    }
}
