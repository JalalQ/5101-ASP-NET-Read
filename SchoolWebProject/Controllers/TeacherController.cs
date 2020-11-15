using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SchoolWebProject.Models;

namespace SchoolWebProject.Controllers
{
    public class TeacherController : Controller
    {

        public ActionResult List()
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers();
            return View(Teachers);
        }

        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<TeacherCourses> TCourses = controller.FindTeacher(id);
            return View(TCourses);
        }

        public ActionResult ListStudent()
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Student> Student = controller.ListStudent();
            return View(Student);
        }


        public ActionResult SearchResult(string name)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.SearchName(name);
            return View(NewTeacher);
        }

        public ActionResult SearchTeacher()
        {
            return View();
        }

    }
}