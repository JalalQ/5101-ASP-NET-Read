using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolWebProject.Models
{
    /// <summary>
    /// This class is store data about teachers which is fetched from the database.
    /// </summary>
    public class Teacher
    {
        public int teacherid;
        public string teacherfname;
        public string teacherlname;
        public string employeenumber;
        public string hiredate;
        public decimal salary;
    }

}